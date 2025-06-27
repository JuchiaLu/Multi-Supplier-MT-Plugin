using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Drawing;
using System.Reflection;

namespace MultiSupplierMTPlugin
{
    class MultiSupplierMTEngine : EngineBase
    {
        private readonly MultiSupplierMTOptions _mtOptions;

        private readonly LimitHelper _limitHelper;

        private readonly RetryHelper _retryHelper;

        private readonly MultiSupplierMTService _providerService;

        private readonly RequestType _requestType;

        private readonly string _srcLangCode;

        private readonly string _trgLangCode;

        public MultiSupplierMTEngine(MultiSupplierMTOptions mtOptions, LimitHelper rateLimitHelper, RetryHelper retryHelper,
            MultiSupplierMTService providerService, RequestType _requestType, string srcLangCode, string trgLangCode)
        {
            this._mtOptions = mtOptions;

            this._limitHelper = rateLimitHelper;
            this._retryHelper = retryHelper;

            this._providerService = providerService;
            this._requestType = _requestType;

            this._srcLangCode = srcLangCode;
            this._trgLangCode = trgLangCode;
        }

        #region IEngine Members

        public override bool SupportsFuzzyCorrection
        {
            get { return true; }
        }

        public override void SetProperty(string name, string value)
        {
            throw new NotImplementedException();
        }

        public override Image SmallIcon
        {
            get 
            {
                return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MultiSupplierMTPlugin.Icon.png"));
            }
        }

        public override ISession CreateLookupSession()
        {
            return new MultiSupplierMTSession(_mtOptions, _limitHelper, _retryHelper, _providerService, _requestType, _srcLangCode, _trgLangCode);
        }

        public override ISessionForStoringTranslations CreateStoreTranslationSession()
        {
            return new MultiSupplierMTSession(_mtOptions, _limitHelper, _retryHelper, _providerService, _requestType, _srcLangCode, _trgLangCode);
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
        }

        #endregion
    }
}
