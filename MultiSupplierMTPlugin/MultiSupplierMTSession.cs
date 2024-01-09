using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoQ.Addins.Common.DataStructures;
using MemoQ.Addins.Common.Utils;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Services;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTSession : ISessionWithMetadata, ISessionForStoringTranslations
    {
        private readonly MTServiceInterface mtService;

        private readonly string srcLangCode;

        private readonly string trgLangCode;

        private readonly MultiSupplierMTOptions options;

        private static readonly ConcurrentDictionary<string, string> cache = new ConcurrentDictionary<string, string>();

        public MultiSupplierMTSession(MultiSupplierMTOptions options, MTServiceInterface mtService, string srcLangCode, string trgLangCode)
        {
            this.options = options;
            this.mtService = mtService;
            this.srcLangCode = srcLangCode;
            this.trgLangCode = trgLangCode;
        }

        #region ISessionWithMetadata Members

        public TranslationResult TranslateCorrectSegment(Segment segm, Segment tmSource, Segment tmTarget)
        {
            return TranslateCorrectSegment(segm, tmSource, tmTarget, null);
        }

        public TranslationResult[] TranslateCorrectSegment(Segment[] segs, Segment[] tmSources, Segment[] tmTargets)
        {
            return TranslateCorrectSegment(segs, tmSources, tmTargets, null);
        }

        public TranslationResult TranslateCorrectSegment(Segment segm, Segment tmSource, Segment tmTarget, MTRequestMetadata metaData)
        {
            return TranslateCorrectSegment(new Segment[] { segm }, new Segment[] { tmSource }, new Segment[] { tmTarget }, metaData)[0];
        }

        public TranslationResult[]  TranslateCorrectSegment(Segment[] segs, Segment[] tmSources, Segment[] tmTargets, MTRequestMetadata metaData)
        {
            TranslationResult[] results = new TranslationResult[segs.Length];

            List<string> texts = segs.Select(s => convertSegment2String(s)).ToList();

            List<int> noInCacheIndex = new List<int>();
            List<string> noInCacheTexts = new List<string>();
            for (int i = 0; i < texts.Count; i++)
            {
                if (this.options.GeneralSettings.EnableCache && tryGetInCache(texts[i], out string translationInCache))
                {
                    results[i] = new TranslationResult();
                    try
                    {
                        results[i].Translation = convertString2Segment(segs[i], translationInCache);
                    }
                    catch (Exception e)
                    {
                        results[i].Exception = new MTException(e.Message, e.Message, e);
                    }
                }
                else
                {
                    noInCacheIndex.Add(i);
                    noInCacheTexts.Add(texts[i]);
                }
            }

            if (noInCacheTexts.Count != 0)
            {
                Task.Run(async () => {

                    int batchSize = mtService.MaxBatchSize();

                    RateLimitHelper rateLimitHelper = new RateLimitHelper(mtService.MaxQueriesPerSecond(), mtService.MaxThreadHold());

                    List<Task> tasks = new List<Task>();
                    for (int i = 0; i < noInCacheTexts.Count; i += batchSize)
                    {
                        List<string> batchTexts = noInCacheTexts.Skip(i).Take(batchSize).ToList();

                        int startIndex = i;
                        int endIndex = startIndex + batchTexts.Count;

                        tasks.Add(Task.Run(async () =>
                        {
                            try
                            {
                                await rateLimitHelper.ThreadHoldWaitting();

                                int waittingMs;
                                while ((waittingMs = rateLimitHelper.GetQpwWaittingMs()) > 0)
                                {
                                    await Task.Delay(waittingMs);
                                }

                                List<string> batchTranslatedTexts = await mtService.BatchTranslate(options, batchTexts, srcLangCode, trgLangCode, null, null, metaData);
                                for (int j = startIndex; j < endIndex; j++)
                                {
                                    if (this.options.GeneralSettings.EnableCache)
                                    {
                                        storeToCache(noInCacheTexts[j], batchTranslatedTexts[j - startIndex]);
                                    }

                                    results[noInCacheIndex[j]] = new TranslationResult();
                                    try
                                    {
                                        results[noInCacheIndex[j]].Translation = convertString2Segment(segs[noInCacheIndex[j]], batchTranslatedTexts[j - startIndex]);
                                    }
                                    catch (Exception e)
                                    {
                                        results[noInCacheIndex[j]].Exception = new MTException(e.Message, e.Message, e);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                for (int j = startIndex; j < endIndex; j++)
                                {
                                    results[noInCacheIndex[j]] = new TranslationResult();
                                    results[noInCacheIndex[j]].Exception = new MTException(e.Message, e.Message, e);
                                    //results[noInCacheIndex[j]].Translation = convertString2Segment(segs[noInCacheIndex[j]], "Exception" + (j + 1).ToString());
                                }
                            }
                            finally
                            {
                                rateLimitHelper.ThreadHoldRelease();
                            }
                        }));
                    }

                    await Task.WhenAll(tasks);

                }).GetAwaiter().GetResult();
            }
            
            return results;
        }

        #endregion

        private string convertSegment2String(Segment segment)
        {
            switch (this.options.GeneralSettings.RequestType)
            {
                case RequestType.OnlyFormattingWithXml:
                    return SegmentXMLConverter.ConvertSegment2Xml(segment, false, true);
                case RequestType.OnlyFormattingWithHtml:
                    return SegmentHtmlConverter.ConvertSegment2Html(segment, false);
                case RequestType.BothFormattingAndTagsWithXml:
                    return SegmentXMLConverter.ConvertSegment2Xml(segment, true, true);
                case RequestType.BothFormattingAndTagsWithHtml:
                    return SegmentHtmlConverter.ConvertSegment2Html(segment, true);
                default:
                    return segment.PlainText;
            }
        }

        private Segment convertString2Segment(Segment originalSegment, string translatedText)
        {
            RequestType requestType = this.options.GeneralSettings.RequestType;

            Segment segment;
            if (requestType == RequestType.Plaintext)
            {
                segment = SegmentBuilder.CreateFromString(translatedText);
            }
            else if (requestType == RequestType.OnlyFormattingWithXml || requestType == RequestType.BothFormattingAndTagsWithXml)
            {
                segment = SegmentXMLConverter.ConvertXML2Segment(translatedText, originalSegment.ITags);
            }
            else
            {
                segment = SegmentHtmlConverter.ConvertHtml2Segment(translatedText, originalSegment.ITags);
            }

            if (requestType == RequestType.Plaintext || requestType == RequestType.OnlyFormattingWithXml || requestType == RequestType.OnlyFormattingWithHtml)
            {
                if (this.options.GeneralSettings.InsertRequiredTagsToEnd)
                {
                    SegmentBuilder sb = new SegmentBuilder();
                    sb.AppendSegment(segment);

                    foreach (InlineTag it in originalSegment.ITags)
                        sb.AppendInlineTag(it);

                    segment = sb.ToSegment();
                }
            }
            else
            {
                if (this.options.GeneralSettings.NormalizeWhitespaceAroundTags)
                {
                    segment = TagWhitespaceNormalizer.NormalizeWhitespaceAroundTags(originalSegment, segment, this.srcLangCode, this.trgLangCode);
                }
            }

            return segment;
        }

        private void storeToCache(string source, string target)
        {
            cache[getKey(source)] = target;
        }

        private bool tryGetInCache(string source, out string translationInCache)
        {
            return cache.TryGetValue(getKey(source), out translationInCache);
        }

        private string getKey(string source)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.options.GeneralSettings.CurrentServiceProvider).Append("_")
              .Append(this.options.GeneralSettings.RequestType).Append("_")
              .Append(this.srcLangCode).Append("_")
              .Append(this.trgLangCode).Append(":")
              .Append(source);

            return sb.ToString();
        }

        #region ISessionForStoringTranslations

        public void StoreTranslation(TranslationUnit transunit)
        {
            StoreTranslation(new TranslationUnit[] { transunit });
        }

        public int[] StoreTranslation(TranslationUnit[] transunits)
        {
            int[] indicesAdded = new int[transunits.Length];
            for (int i = 0; i < transunits.Length; i++)
            {
                //string sourceText = createTextFromSegment(transunits[i].Source);
                //string targetText = createTextFromSegment(transunits[i].Target);
                //storeToCache(sourceText, targetText);

                indicesAdded[i] = i;
            }

            return indicesAdded;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
