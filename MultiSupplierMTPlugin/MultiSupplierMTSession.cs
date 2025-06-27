using MemoQ.Addins.Common.DataStructures;
using MemoQ.Addins.Common.Utils;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin
{
    class MultiSupplierMTSession : ISessionWithMetadata, ISessionForStoringTranslations
    {
        private readonly MultiSupplierMTGeneralSettings _mtGeneralSettings;
        private readonly MultiSupplierMTSecureSettings _mtSecureSettings;

        private readonly LimitHelper _limitHelper;
        private readonly RetryHelper _retryHelper;

        private readonly MultiSupplierMTService _providerService;
        private readonly RequestType _requestType;

        private readonly string _srcLangCode;
        private readonly string _trgLangCode;

        public MultiSupplierMTSession(MultiSupplierMTOptions mtOptions, LimitHelper limitHelper, RetryHelper retryHelper,
            MultiSupplierMTService providerService, RequestType requestType, string srcLangCode, string trgLangCode)
        {
            this._mtGeneralSettings = mtOptions.GeneralSettings;
            this._mtSecureSettings = mtOptions.SecureSettings;

            this._limitHelper = limitHelper;
            this._retryHelper = retryHelper;

            this._providerService = providerService;
            this._requestType = requestType;

            this._srcLangCode = srcLangCode;
            this._trgLangCode = trgLangCode;
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

        public TranslationResult[] TranslateCorrectSegment(Segment[] srcSegms, Segment[] tmSrcSegms, Segment[] tmTgtSegms, MTRequestMetadata metaData)
        {
            //memoQ 10.0 之前的版本不支持这两个参数
            var hasTm = tmSrcSegms != null && tmTgtSegms != null;

            //记录未翻译文本在原始列表中的位置，翻译后才能将结果放入原始位置
            var untransOriginalIndices = new List<int>();  
            
            var untransSrcTexts = new List<string>();                  //未翻译的句段纯文本列表
            var untransTmSrcTexts = hasTm ? new List<string>() : null; //未翻译句段关联的翻译记忆原文纯文本列表
            var untransTmTgtTexts = hasTm ? new List<string>() : null; //未翻译句段关联的翻译记忆译文纯文本列表

            //最终翻译结果列表
            TranslationResult[] results = new TranslationResult[srcSegms.Length];

            //将句段分成两部分（同时转换成纯文本）：缓存中存在的转换到结果列表，缓存中未存在的转换到未翻译列表
            DivideCachedAndUncached(srcSegms, tmSrcSegms, tmTgtSegms, untransSrcTexts, untransTmSrcTexts, untransTmTgtTexts, untransOriginalIndices, results);

            //翻译缓存中未存在的
            if (untransSrcTexts.Count > 0)
            {
                ProcessUncachedTranslations(srcSegms, untransSrcTexts, untransTmSrcTexts, untransTmTgtTexts, metaData, untransOriginalIndices, results);
            }

            return results;
        }

        #endregion

        #region Helper Function 1

        // 将句段分成两部分（同时转换成纯文本）：缓存中存在的转换到结果列表，缓存中未存在的转换到未翻译列表
        private void DivideCachedAndUncached(
            Segment[] srcSegms, Segment[] tmSrcSegms, Segment[] tmTgtSegms,
            List<string> untransSrcTexts, List<string> untransTmSrcTexts, List<string> untransTmTgtTexts,
            List<int> untransOriginalIndices, TranslationResult[] results)
        {
            bool hasTm = tmSrcSegms != null && tmTgtSegms != null;
            List<string> srcTexts = srcSegms.Select(ConvertSegment2String).ToList();            

            for (int i = 0; i < srcTexts.Count; i++)
            {
                var inCache = CacheHelper.TryGet(_providerService.UniqueName, _requestType.ToString(), _srcLangCode, _trgLangCode, srcTexts[i], out string cachedTgtText);

                if (_mtGeneralSettings.EnableCache && inCache)
                {
                    results[i] = new TranslationResult { Translation = ConvertString2Segment(srcSegms[i], cachedTgtText) };
                }
                else
                {
                    untransOriginalIndices.Add(i);

                    untransSrcTexts.Add(srcTexts[i]);
                    if (hasTm)
                    {
                        untransTmSrcTexts?.Add(tmSrcSegms[i] != null ? ConvertSegment2String(tmSrcSegms[i]) : "");
                        untransTmTgtTexts?.Add(tmTgtSegms[i] != null ? ConvertSegment2String(tmTgtSegms[i]) : "");
                    }
                }
            }
        }

        // 主翻译逻辑
        private void ProcessUncachedTranslations(
            Segment[] srcSegms,
            List<string> untransSrcTexts, List<string> untransTmSrcTexts, List<string> untransTmTgtTexts, MTRequestMetadata metaData,
            List<int> untransOriginalIndices, TranslationResult[] results)
        {
            var tasks = new List<Task>();
            var batches = splitIntoBatches(untransSrcTexts);

            foreach (var (startIndex, count) in batches)
            {
                var batchSrcTexts = untransSrcTexts.Skip(startIndex).Take(count).ToList();
                var batchTmSrcTexts = untransTmSrcTexts?.Skip(startIndex).Take(count).ToList();
                var batchTmTgtTexts = untransTmTgtTexts?.Skip(startIndex).Take(count).ToList();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        var batchTgtTexts = await TranslateCoreAsync(batchSrcTexts, batchTmSrcTexts, batchTmTgtTexts, metaData);
                        
                        for (int i = 0; i < batchSrcTexts.Count; i++)
                        {
                            int untransIndex = startIndex + i;                        // 在未翻译列表中的索引
                            int originalIndex = untransOriginalIndices[untransIndex]; // 在原始列表中的索引

                            var srcSegm = srcSegms[originalIndex];
                            var srcText = batchSrcTexts[i];
                            var tgtText = batchTgtTexts[i];

                            results[originalIndex] = new TranslationResult();
                            try
                            {
                                results[originalIndex].Translation = ConvertString2Segment(srcSegm, tgtText);

                                if (_mtGeneralSettings.EnableCache)
                                    CacheHelper.Store(_providerService.UniqueName, _requestType.ToString(), _srcLangCode, _trgLangCode, srcText, tgtText);
                            }
                            catch (Exception ex)
                            {
                                SetSingleExecption(results, originalIndex, ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SetBatchException(results, untransOriginalIndices, startIndex, count, ex);
                    }
                }));
            }

            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }

        // 大小限制（句段、字符限制）
        private List<(int StartIndex, int Count)> splitIntoBatches(List<string> untransTexts)
        {
            var batches = new List<(int StartIndex, int Count)>();

            // 不支持批量翻译，总是忽略句段限制和字符限制，逐个句段翻译
            if (!_providerService.IsBatchSupported)
            {
                for (int i = 0; i < untransTexts.Count; i++)
                {
                    batches.Add((i, 1));
                }
                return batches;
            }

            int maxSegments = _mtGeneralSettings.EnableCustomRequestLimit
                ? _mtGeneralSettings.MaxSegmentsPerRequest
                : _providerService.MaxSegments;

            int maxCharacters = _mtGeneralSettings.EnableCustomRequestLimit
                ? _mtGeneralSettings.MaxCharactersPerRequest
                : _providerService.MaxCharacters;

            bool limitSegments = maxSegments > 0;
            bool limitCharacters = maxCharacters > 0;

            int startIndex = 0;
            while (startIndex < untransTexts.Count)
            {
                int segmCount = 0;
                int charCount = 0;
                
                for (int i = startIndex; i < untransTexts.Count; i++)
                {
                    int nextLength = untransTexts[i]?.Length ?? 0;

                    // 总是确保有一个句段，无论句段限制、字符限制是多少
                    bool isNotFirstSegment = segmCount > 0;
                    
                    bool wouldExceedSegmentLimit = limitSegments && (segmCount + 1) > maxSegments;
                    bool wouldExceedCharLimit = limitCharacters && (charCount + nextLength) > maxCharacters;
                    
                    if (isNotFirstSegment && (wouldExceedSegmentLimit || wouldExceedCharLimit))
                        break;

                    segmCount++;
                    charCount += nextLength;
                }

                batches.Add((startIndex, segmCount));
                startIndex += segmCount;
            }

            return batches;
        }

        // 并发限制、速率限制、重试限制
        private async Task<List<string>> TranslateCoreAsync(List<string> batchTexts, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            // 重试限制放在外部缺点：请求还没真正发起，就可能会超时失败
            // 重试限制放在内部缺点：失败重试时，并发限制、速率限制不再起作用
            // TODO：拆分超时和重试限制
            // TOOD：失败重试时，也要受到并发限制、速率限制
            // TODO: 重新实现生产者消费者模型限流，而不是直接就启动一个线程空转等待
            try
            {
                await _limitHelper.ThreadHoldWaitting();

                int waittingMs;
                while ((waittingMs = _limitHelper.GetRateWaittingMs()) > 0)
                {
                    await Task.Delay(waittingMs);
                }

                return await _retryHelper.ExecWithRetryAsync(async (cToken) =>
                {
                    List<string> result;
                    try
                    {
                        result = await _providerService.TranslateAsync(batchTexts, _srcLangCode, _trgLangCode, tmSources, tmTargets, metaData, cToken);
                    }
                    catch (Exception ex)
                    {
                        if (_mtGeneralSettings.EnableStatsAndLog) StatsHelper.IncrementRequestFailed();

                        throw ex;
                    }

                    if (_mtGeneralSettings.EnableStatsAndLog) StatsHelper.IncrementRequestSuccess();

                    return result;
                });
            }
            finally
            {
                _limitHelper.ThreadHoldRelease();
            }
        }
        #endregion

        #region Helper Function 2
        private void SetSingleExecption(TranslationResult[] results, int originalIndex, Exception ex)
        {
            string msg = LLH.G(LLK.MultiSupplierMTSession_String2SegmentFail);
            results[originalIndex].Exception = new MTException(msg, msg, ex);
            LoggingHelper.Warn(msg);
        }

        private void SetBatchException(TranslationResult[] results, List<int> untransOriginalIndices, int BatchStartIndex, int BatchCount, Exception ex)
        {
            var msgBuilder = new StringBuilder();
            msgBuilder.AppendLine(LLH.G(LLK.MultiSupplierMTSession_AllSegmentsTranslateFail, BatchCount));
            msgBuilder.AppendLine("\t" + ex.Message);

            if (ex is AggregateException agEx)
            {
                foreach (var inner in agEx.InnerExceptions)
                    msgBuilder.AppendLine("\t\t" + inner.Message);
            }

            string finalMsg = msgBuilder.ToString().TrimEnd();

            for (int i = 0; i < BatchCount; i++)
            {
                int untransIndex = BatchStartIndex + i;
                int originalIndex = untransOriginalIndices[untransIndex];

                results[originalIndex] = new TranslationResult
                {
                    Exception = new MTException(finalMsg, finalMsg, ex)
                };
            }

            LoggingHelper.Warn(finalMsg);
        }

        private string ConvertSegment2String(Segment segment)
        {
            switch (_requestType)
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

        private Segment ConvertString2Segment(Segment originalSegment, string translatedText)
        {
            Segment segment;
            if (_requestType == RequestType.OnlyFormattingWithXml || _requestType == RequestType.BothFormattingAndTagsWithXml)
            {
                segment = SegmentXMLConverter.ConvertXML2Segment(translatedText, originalSegment.ITags);
            }
            else if(_requestType == RequestType.OnlyFormattingWithHtml || _requestType == RequestType.BothFormattingAndTagsWithHtml)
            {
                segment = SegmentHtmlConverter.ConvertHtml2Segment(translatedText, originalSegment.ITags);
            }
            else
            {
                segment = SegmentBuilder.CreateFromString(translatedText);
            }

            if (_requestType == RequestType.BothFormattingAndTagsWithXml || _requestType == RequestType.BothFormattingAndTagsWithHtml)
            {
                if (_mtGeneralSettings.NormalizeWhitespaceAroundTags)
                {
                    segment = TagWhitespaceNormalizer.NormalizeWhitespaceAroundTags(originalSegment, segment, this._srcLangCode, this._trgLangCode);
                }
            }
            else
            {
                if (_mtGeneralSettings.InsertRequiredTagsToEnd)
                {
                    SegmentBuilder sb = new SegmentBuilder();
                    sb.AppendSegment(segment);

                    foreach (InlineTag it in originalSegment.ITags)
                        sb.AppendInlineTag(it);

                    segment = sb.ToSegment();
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
                    CacheHelper.Store(_providerService.UniqueName, _requestType.ToString(), _srcLangCode, _trgLangCode, 
                        ConvertSegment2String(transunits[i].Source), ConvertSegment2String(transunits[i].Target));
                    
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
