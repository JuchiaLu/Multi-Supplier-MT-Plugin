using System;
using System.Drawing;
using System.Reflection;
using MemoQ.MTInterfaces;


namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTEngine : EngineBase
    {
        private readonly MultiSupplierMTServiceInterface mtService;

        private readonly string srcLangCode;

        private readonly string trgLangCode;

        private readonly MultiSupplierMTOptions options;

        public MultiSupplierMTEngine(MultiSupplierMTOptions options, MultiSupplierMTServiceInterface mtService, string srcLangCode, string trgLangCode)
        {
            this.options = options;
            this.mtService = mtService;
            this.srcLangCode = srcLangCode;
            this.trgLangCode = trgLangCode;
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
            get { return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MultiSupplierMTPlugin.Icon.bmp")); }
        }

        public override ISession CreateLookupSession()
        {
            return new MultiSupplierMTSession(this.options, this.mtService, this.srcLangCode, this.trgLangCode);
        }

        public override ISessionForStoringTranslations CreateStoreTranslationSession()
        {
            return new MultiSupplierMTSession(this.options, this.mtService, this.srcLangCode, this.trgLangCode);
        }

        #endregion

        #region IDisposable Members

        public override void Dispose()
        {
        }

        #endregion
    }
}
