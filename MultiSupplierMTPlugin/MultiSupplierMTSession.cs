using MemoQ.Addins.Common.DataStructures;
using MemoQ.Addins.Common.Utils;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTSession : ISessionWithMetadata, ISessionForStoringTranslations
    {
        private readonly string srcLangCode;

        private readonly string trgLangCode;

        private readonly MultiSupplierMTOptions options;

        private readonly MultiSupplierMTService mtService;

        private readonly LimitHelper rateLimitHelper;

        private readonly RetryHelper retryHelper;

        private readonly LoggingHelper loggingHelper;

        public MultiSupplierMTSession(string srcLangCode, string trgLangCode, MultiSupplierMTOptions options, MultiSupplierMTService mtService,
            LimitHelper rateLimitHelper, RetryHelper retryHelper, LoggingHelper loggingHelper)
        {
            this.srcLangCode = srcLangCode;
            this.trgLangCode = trgLangCode;
            this.options = options;
            this.mtService = mtService;

            this.rateLimitHelper = rateLimitHelper;
            this.retryHelper = retryHelper;
            this.loggingHelper = loggingHelper;
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

        public TranslationResult[] TranslateCorrectSegment(Segment[] segs, Segment[] tmSources, Segment[] tmTargets, MTRequestMetadata metaData)
        {
            TranslationResult[] results = new TranslationResult[segs.Length];

            // 这里如果抛出异常，只能说是编码错误，不处理这里的异常。
            List<string> texts = segs.Select(s => convertSegment2String(s)).ToList(); 

            List<int> noInCacheIndexes = new List<int>();
            List<string> noInCacheTexts = new List<string>();
            for (int i = 0; i < texts.Count; i++)
            {
                if (this.options.GeneralSettings.EnableCache && CacheHelper.TryGet(generateKey(texts[i]), out string translationInCache))
                {
                    results[i] = new TranslationResult();
                    // 这里不会抛出异常，保存到缓存时，转换出错的没有存进入。
                    results[i].Translation = convertString2Segment(segs[i], translationInCache); 
                }
                else
                {
                    noInCacheIndexes.Add(i);
                    noInCacheTexts.Add(texts[i]);
                }
            }

            if (noInCacheTexts.Count != 0)
            {
                int batchSize = determineBatchSize(noInCacheTexts.Count);

                List<Task> tasks = new List<Task>();
                for (int i = 0; i < noInCacheTexts.Count; i += batchSize)
                {
                    List<string> batchTexts = noInCacheTexts.Skip(i).Take(batchSize).ToList();

                    int startIndex = i;
                    int endIndex = startIndex + batchTexts.Count;

                    tasks.Add(Task.Run(async () => {
                        try
                        {
                            List<string> batchTranslatedTexts = await translateCoreAsync(batchTexts, null, null, metaData);
                            for (int j = startIndex; j < endIndex; j++)
                            {
                                results[noInCacheIndexes[j]] = new TranslationResult();
                                try
                                {
                                    results[noInCacheIndexes[j]].Translation = convertString2Segment(segs[noInCacheIndexes[j]], batchTranslatedTexts[j - startIndex]);
                                    if (this.options.GeneralSettings.EnableCache)
                                    {
                                        CacheHelper.Store(generateKey(noInCacheTexts[j]), batchTranslatedTexts[j - startIndex]);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    results[noInCacheIndexes[j]].Exception = new MTException(ex.Message, ex.Message, ex);
                                    
                                    if (options.GeneralSettings.EnableStatsAndLog && loggingHelper != null)
                                    {
                                        loggingHelper.Log(LLH.G(LLK.MultiSupplierMTSession_String2SegmentFail));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            for (int j = startIndex; j < endIndex; j++)
                            {
                                results[noInCacheIndexes[j]] = new TranslationResult();
                                results[noInCacheIndexes[j]].Exception = new MTException(ex.Message, ex.Message, ex);
                            }

                            if (options.GeneralSettings.EnableStatsAndLog && loggingHelper != null)
                            {
                                StringBuilder sb = new StringBuilder();
                                
                                sb.AppendLine(LLH.G(LLK.MultiSupplierMTSession_AllSegmentsTranslateFail, batchTexts.Count));
                                sb.Append("\t").AppendLine(ex.Message);
                                if (ex is AggregateException aggregate)
                                {
                                    foreach (var ie in aggregate.InnerExceptions)
                                    {
                                        sb.Append("\t\t").AppendLine(ie.Message);
                                    }
                                }

                                loggingHelper.Log(sb.ToString());
                            }
                        }
                    }));
                }

                Task.WhenAll(tasks).GetAwaiter().GetResult();
            }

            return results;
        }

        #endregion

        #region Helper Function

        private async Task<List<string>> translateCoreAsync(List<string> batchTexts, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            return await retryHelper.ExecWithRetryAsync(async (cToken) =>
            {
                try
                {
                    await rateLimitHelper.ThreadHoldWaitting();

                    int waittingMs;
                    while ((waittingMs = rateLimitHelper.GetRateWaittingMs()) > 0)
                    {
                        await Task.Delay(waittingMs);
                    }

                    if (options.GeneralSettings.EnableStatsAndLog)
                    {
                        StatsHelper.IncrementRequestTotal();
                    }

                    return await mtService.TranslateAsync(options, batchTexts, srcLangCode, trgLangCode, tmSources, tmTargets, metaData, cToken);
                }
                catch (Exception ex)
                {
                    if(options.GeneralSettings.EnableStatsAndLog)
                    {
                        StatsHelper.IncrementRequestFailed();
                    }
                    
                    throw ex;
                }
                finally
                {
                    rateLimitHelper.ThreadHoldRelease();
                }
            });
        }

        private int determineBatchSize(int noInCacheTextsCount)
        {
            int batchSize;

            if (!mtService.IsBatchSupported())
            {
                batchSize = 1;
            }
            else if (options.GeneralSettings.EnableCustomRequestLimit)
            {
                if (options.GeneralSettings.MaxSegmentsPerRequest <= 0)
                {
                    batchSize = noInCacheTextsCount;
                }
                else
                {
                    batchSize = options.GeneralSettings.MaxSegmentsPerRequest;
                }
            }
            else
            {
                batchSize = mtService.MaxBatchSize();
            }

            return batchSize;
        }

        private string generateKey(string source)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.options.GeneralSettings.CurrentServiceProvider).Append("_")
              .Append(this.options.GeneralSettings.RequestType).Append("_")
              .Append(this.srcLangCode).Append("_")
              .Append(this.trgLangCode).Append(":")
              .Append(source);

            return sb.ToString();
        }

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
            if (options.GeneralSettings.CurrentServiceProvider.Equals("TestBuiltIn"))
            {
                return SegmentBuilder.CreateFromString(translatedText);
            }
            else if (requestType == RequestType.Plaintext)
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

        #endregion

        #region ISessionForStoringTranslations

        public void StoreTranslation(TranslationUnit transunit)
        {
            StoreTranslation(new TranslationUnit[] { transunit });
        }

        public int[] StoreTranslation(TranslationUnit[] transunits)
        {
            int[] stored = new int[transunits.Length];
            for (int i = 0; i < transunits.Length; i++)
            {
                try
                {
                    CacheHelper.Store(generateKey(convertSegment2String(transunits[i].Source)), convertSegment2String(transunits[i].Target));
                    stored[i] = i;
                }
                catch
                {
                    // do nothing
                }
            }
            return stored;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
