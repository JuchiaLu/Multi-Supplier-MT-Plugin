using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Helpers
{
    class ContextHelper : IPreviewToolCallback
    {
        // 单例
        private static volatile ContextHelper _instance = null;
        private static readonly object _singleLockObj = new object();

        // 记录文档的内容
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<int, Content>> _docDic = new ConcurrentDictionary<string, ConcurrentDictionary<int, Content>>();
        
        // 记录文档的最大索引
        private readonly ConcurrentDictionary<string, int> _lastIndexDic = new ConcurrentDictionary<string, int>(); // TODO：应该和 docDic 合并，否则两者不是同步的
        
        // 记录文档当前激活的索引
        private readonly ConcurrentDictionary<string, CurrentIndex> _currentIndexDic = new ConcurrentDictionary<string, CurrentIndex>();
        
        // 记录文档的原始名字
        private readonly ConcurrentDictionary<string, string> _docNameDic = new ConcurrentDictionary<string, string>();

        // 发送请求
        private readonly MemoqRequest _request = null;


        private ContextHelper(string dllFileName)
        {
            // 初始化请求对象
            _request = new MemoqRequest(this, dllFileName);

            Task.Run(() => 
            {
                try
                {
                    Thread.Sleep(new Random().Next(3000, 10000));

                    _request.ConnetOrRegister();
                }
                catch
                {
                    // Do Nothing.
                }
            });
        }

        public static ContextHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        public static void Init(string dllFileName)
        {
            if (_instance == null)
            {
                lock (_singleLockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new ContextHelper(dllFileName);
                    }
                }
            }
        }


        public CurrentIndex GetCurrentIndex(string prjGuid, string docGuid, string srcLang, string tgtLang)
        {
            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);
                
            if (!_currentIndexDic.TryGetValue(key, out var currentIndex))
                throw new Exception("Wait for the document to reload and reactivate the current segment, or document load fails, reopen the document."); 
            
            return currentIndex;
        }

        public void ResetCurrentIndex(string prjGuid, string docGuid, string srcLang, string tgtLang)
        {
            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);

            if (!_currentIndexDic.ContainsKey(key))
                throw new Exception("document load fails, reopen the document.");
              
            _currentIndexDic[key] = new CurrentIndex()
            {
                IndexStart = -1,
                IndexEnd = -1,
                UtcMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
        }

        public string GetTargetText(string prjGuid, string docGuid, string srcLang, string tgtLang,
            int segmIndex)
        {
            CheckConnect();

            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);

            if (!_docDic.TryGetValue(key, out var doc) || !doc.TryGetValue(segmIndex, out Content content))
                throw new Exception("document load fails, reopen the document.");

            return content.Target;
        }

        public string GetAboveContext(string prjGuid, string docGuid, string srcLang, string tgtLang,
            int segmIndex, int maxSegm, int maxChar, bool includeSrc, bool includeTgt)
        {
            CheckConnect();

            return GetContext(prjGuid, docGuid, srcLang, tgtLang, 
                segmIndex, maxSegm, maxChar, includeSrc, includeTgt, true);
        }

        public string GetBelowContext(string prjGuid, string docGuid, string srcLang, string tgtLang,
            int segmIndex, int maxSegm, int maxChar, bool includeSrc, bool includeTgt)
        {
            CheckConnect();

            return GetContext(prjGuid, docGuid, srcLang, tgtLang, 
                segmIndex, maxSegm, maxChar, includeSrc, includeTgt, false);
        }

        public string GetDocName(string prjGuid, string docGuid, string srcLang, string tgtLang)
        {
            CheckConnect();

            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);

            if (!_docNameDic.TryGetValue(key, out var name))
                throw new Exception("document load fails, reopen the document.");

            return name;
        }

        public string GetFullText(string prjGuid, string docGuid, string srcLang, string tgtLang)
        {
            CheckConnect();

            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);

            if (!_docDic.TryGetValue(key, out var doc) || !_lastIndexDic.TryGetValue(key, out var lastIndex))
                throw new Exception("document load fails, reopen the document.");

            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= lastIndex; i++)
            {
                if (!doc.TryGetValue(i, out Content content))
                    throw new Exception("document load fails, reopen the document.");

                result.Append(content.Source);
            }

            return result.ToString();
        }

        public void SetContext(string prjGuid, string docGuid, string srcLang, string tgtLang,
           int segmIndex, string srcContent, string tgtContent)
        {
            CheckConnect();

            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);

            SetContext(key, segmIndex, srcContent, tgtContent);
        }


        private void SetDocName(PreviewPart previewPart)
        {
            string key = GetKey(previewPart);

            _docNameDic[key] = previewPart.SourceDocument.DocumentName;
        }

        private string GetContext(string prjGuid, string docGuid, string srcLang, string tgtLang,
           int segmIndex, int maxSegm, int maxChar, bool includeSrc, bool includeTgt, bool isAbove)
        {
            string key = GetKey(prjGuid, docGuid, srcLang, tgtLang);

            if (!_docDic.TryGetValue(key, out var doc) || !_lastIndexDic.TryGetValue(key, out var lastIndex))
                throw new Exception("document load fails, reopen the document.");
            
            if ((!includeSrc && !includeTgt) || (maxSegm <= 0 && maxChar <= 0)) return "";

            int direction = isAbove ? -1 : 1;
            int current = segmIndex + direction;

            int charCount = 0;
            int segmCount = 0;
            List<string> results = new List<string>();
            while ((maxSegm <= 0 || segmCount < maxSegm) && current >= 1 && current <= lastIndex)
            {
                if (!doc.TryGetValue(current, out Content content))
                    throw new Exception("document load fails, reopen the document.");
                
                // 跳过空白句段
                bool srcWhiteSpace = string.IsNullOrWhiteSpace(content.Source);
                bool tgtWhiteSpace = string.IsNullOrWhiteSpace(content.Target);
                bool noSkip = (includeSrc && !srcWhiteSpace) || (includeTgt && !tgtWhiteSpace);
                if (!noSkip)
                {
                    current += direction;
                    continue;
                }

                // 字符计算，不包括额外添加的换行符。
                charCount += includeSrc ? content.Source.Length: 0;
                charCount += includeTgt ? content.Target.Length: 0;
                if (maxChar > 0 && charCount > maxChar) break;

                if (isAbove)
                {
                    if (includeTgt) results.Insert(0, content.Target);
                    if (includeSrc) results.Insert(0, content.Source);
                }
                else
                {
                    if (includeSrc) results.Add(content.Source);
                    if (includeTgt) results.Add(content.Target);
                }
                segmCount++;

                current += direction;
            }

            return string.Join(Environment.NewLine, results);
        }


        private void SetContext(PreviewPart previewPart)
        {
            string key = GetKey(previewPart);

            int segmIndex = int.Parse(previewPart.PreviewPartId.Split('-').Last());
            string srcContent = previewPart.SourceContent.Content;
            string tgtContent = previewPart.TargetContent.Content;

            SetContext(key, segmIndex, srcContent, tgtContent);
        }

        private void SetContext(string key, int segmIndex, string srcContent, string tgtContent)
        {
            if (!_docDic.TryGetValue(key, out var doc))
            {
                doc = new ConcurrentDictionary<int, Content>();
                _docDic[key] = doc;
            }
            doc[segmIndex] = new Content(srcContent, tgtContent);

            if (!_lastIndexDic.TryGetValue(key, out var lastIndex))
            {
                lastIndex = 0;
            }
            if (segmIndex > lastIndex)
            {
                _lastIndexDic[key] = segmIndex;
            }
        } 


        private string GetKey(PreviewPart previewPart)
        {
            string prjGuid = string.Empty;
            string docGuid = previewPart.SourceDocument.DocumentGuid.ToString();
            string srcLang = previewPart.SourceLangCode;
            string tgtLang = previewPart.TargetLangCode;

            return GetKey(prjGuid, docGuid, srcLang, tgtLang);
        }

        private string GetKey(string projectGuid, string docGuid, string srcLang, string tgtLang)
        {
            // 暂时不使用 project guid，因为只有 MT SDK 中能获取到，Preview SDK 中获取不到。
            return $"{docGuid}|{srcLang}|{tgtLang}";
        }

        #region memoQ 回调

        // 以下回调方法不会被并发调用，会被以队列顺序调用，请勿向外抛出异常，貌似上层不会处理，导致之后的回调异常。

        // 1. 用户在 memoQ 中切换了行, 我们把当前行保留下来, 翻译的时候知道当前行是哪一行
        public void HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest)
        {
            try
            {
                //LoggingHelper.Log($"HandleChangeHighlightRequest: {changeHighlighRequest.ActivePreviewParts.Length}");
                var activeParts = changeHighlighRequest.ActivePreviewParts;
                if (activeParts.Length <= 0) return;

                var firstPart = activeParts.First();
                var lastPart = activeParts.Last();

                string key = GetKey(firstPart);

                //if (currentIndexDic.ContainsKey(key))
                    //LoggingHelper.Log($"HandleChangeHighlightRequest 修改前：{currentIndexDic[key].IndexStart}, {currentIndexDic[key].IndexEnd}");

                _currentIndexDic[key] = new CurrentIndex()
                {
                    IndexStart = int.Parse(firstPart.PreviewPartId.Split('-').Last()),
                    IndexEnd = int.Parse(lastPart.PreviewPartId.Split('-').Last()),
                    UtcMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                };

                //LoggingHelper.Log($"HandleChangeHighlightRequest 修改前：{currentIndexDic[key].IndexStart}, {currentIndexDic[key].IndexEnd}");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        // 2. 用于获取全部句段的 ID
        public void HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest)
        {
            try
            {
                //LoggingHelper.Log($"HandlePreviewPartIdUpdateRequest（主动）: {previewPartIdUpdateRequest.PreviewPartIds.Length}");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        // 3. 用于获取全部句段的内容
        public void HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest)
        {
            try
            {
                //LoggingHelper.Log($"HandleContentUpdateRequest（主动）: {contentUpdateRequest.PreviewParts.Length}");

                foreach (var previewPart in contentUpdateRequest.PreviewParts)
                {
                    SetDocName(previewPart);

                    SetContext(previewPart);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        // 4. 断开连接
        public void HandleDisconnect()
        {
            try
            {
                //LoggingHelper.Log($"HandleDisconnect");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        #endregion


        #region 其他

        private void CheckConnect()
        {
            try
            {
                _request.RequestRuntimeSettingsChange(new ChangeRuntimeSettingsRequest(ContentComplexityLevel.Minimal, new string[] { }));

                //LoggingHelper.Log("测试连接成功！");
            }
            catch
            {
                try
                {
                    _request.ConnetOrRegister();
                }
                catch (Exception ex)
                {
                    if (ex is PreviewToolAlreadyConnectedException)
                    {
                        // Do Nothing.
                    }
                    else
                    {
                        throw new Exception("The connection with the Preview Helper still fails after reconnecting, please try to restart the software");
                    }
                }

                throw new Exception("The connection with the preview Helper has been disconnected and reconnected successfully. Please reactivate the current segment");
            }
        }

        private void ExceptionHandler(Exception ex)
        {
            LoggingHelper.Warn("preview helper exception message: " + ex.Message);
            LoggingHelper.Warn("preview helper exception stack trace: \r\n" + ex.StackTrace);
        }

        #endregion
    }

    class CurrentIndex 
    {
        public int IndexStart { get; set; }

        public int IndexEnd { get; set; }

        public long UtcMs { get; set; }
    }

    class Content
    {
        public string Source { get; set; }

        public string Target { get; set; }

        public Content(string source, string target)
        {
            this.Source = source;
            this.Target = target;
        }

    }

    class MemoqRequest
    {
        private PreviewServiceProxy _proxy = null;

        private readonly ContextHelper _callbackHandler = null;
        private readonly string _baseAddress = "MQ_PREVIEW_PIPE";
        private readonly CommunicationProtocols _communicationProtocol = CommunicationProtocols.NamedPipe;

        private readonly Guid _previewToolId;
        //多供应商机器翻译插件助手
        private readonly string _previewToolName = "Multi Supplier MT Plugin Helper";
        //为多供应商机器翻译插件提供全文文本、全文摘要、上下文功能。
        private readonly string _previewToolDescription;
        private readonly string _autoStartupCommand = " ";
        private readonly string _previewPartIdRegex = ".*";
        private readonly bool _requiresWebPreviewBaseUrl = false;
        private readonly ContentComplexityLevel _contentComplexity = ContentComplexityLevel.Minimal;
        private readonly string[] _requiredProperties = new string[] { };

        public MemoqRequest(ContextHelper callbackHandler, String dllFileName)
        {
            this._callbackHandler = callbackHandler;
            
            var guidSuffix = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(dllFileName))).Replace("-", "").ToLower().Substring(0, 12);
            
            this._previewToolId = Guid.Parse($"c6f2be44-e33c-478e-ba23-{guidSuffix}");

            this._previewToolDescription = $"{dllFileName}, Provides full-text, summary-text, above-text, below-text, and target-text feature for Multi Supplier MT Plugin";
        }

        // 1 创建代理、2 注册、3 连接
        public void ConnetOrRegister()
        {
            if (_proxy == null)
            {
                _proxy = new PreviewServiceProxy(_callbackHandler, _baseAddress, _communicationProtocol);
            }

            var requestStatus = _proxy.Connect(_previewToolId);
            if (!requestStatus.RequestAccepted)
            {
                // NoEnabledPreviewToolWithThisId 可能是未开启，也有可能是未注册，尝试进行注册
                if (requestStatus.ErrorCode == ErrorCodes.NoEnabledPreviewToolWithThisId)
                {
                    var request = new RegistrationRequest(_previewToolId, _previewToolName, _previewToolDescription, _autoStartupCommand,
                                                                _previewPartIdRegex, _requiresWebPreviewBaseUrl, _contentComplexity, _requiredProperties);
                    requestStatus = _proxy.Register(request);
                    if (!requestStatus.RequestAccepted)
                    {
                        throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
                    }
                }
                else
                {
                    throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
                }
            }
        }

        // 4 修改文本复杂度
        public void RequestRuntimeSettingsChange(ChangeRuntimeSettingsRequest changeRuntimeSettingsRequest)
        {
            var requestStatus = _proxy.RequestRuntimeSettingsChange(changeRuntimeSettingsRequest);
            if (!requestStatus.RequestAccepted)
            {
                throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
            }
        }

        // 5 预览 ID 更新
        public void RequestPreviewPartIdUpdate()
        {
            var requestStatus = _proxy.RequestPreviewPartIdUpdate();

            if (!requestStatus.RequestAccepted)
            {
                throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
            }
        }

        // 6 预览内容更新
        public void RequestContentUpdate(ContentUpdateRequestFromPreviewTool contentUpdateRequest)
        {
            var requestStatus = _proxy.RequestContentUpdate(contentUpdateRequest);

            if (!requestStatus.RequestAccepted)
            {
                throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
            }
        }

        // 7 改变高亮
        public void RequestHighlightChange(ChangeHighlightRequestFromPreviewTool changeHighlightRequest)
        {
            var requestStatus = _proxy.RequestHighlightChange(changeHighlightRequest);

            if (!requestStatus.RequestAccepted)
            {
                throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
            }
        }

        // 8 断开连接
        public void Disconnect()
        {
            var requestStatus = _proxy.Disconnect();

            if (!requestStatus.RequestAccepted)
            {
                throw new ResponseException(requestStatus.ErrorMessage, requestStatus.ErrorCode);
            }
        }
    }

    class ResponseException : Exception
    {
        public ErrorCodes? ErrorCode { get; }

        public ResponseException(string message, ErrorCodes? errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
