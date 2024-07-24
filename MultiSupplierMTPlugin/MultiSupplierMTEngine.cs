using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Services;
using System;
using System.Drawing;
using System.Reflection;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTEngine : EngineBase
    {
        private readonly string srcLangCode;

        private readonly string trgLangCode;

        private readonly MultiSupplierMTOptions options;

        private readonly MultiSupplierMTService mtService;

        private readonly LimitHelper rateLimitHelper;

        private readonly RetryHelper retryHelper;

        private readonly LoggingHelper loggingHelper;

        public MultiSupplierMTEngine(string srcLangCode, string trgLangCode, MultiSupplierMTOptions options, MultiSupplierMTService mtService,
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
            return new MultiSupplierMTSession(srcLangCode, trgLangCode, options, mtService, rateLimitHelper, retryHelper, loggingHelper);
        }

        public override ISessionForStoringTranslations CreateStoreTranslationSession()
        {
            return new MultiSupplierMTSession(srcLangCode, trgLangCode, options, mtService, rateLimitHelper, retryHelper, loggingHelper);
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
        }

        #endregion
    }
}
