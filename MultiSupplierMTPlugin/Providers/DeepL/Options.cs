using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.DeepL
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : NMTBaseGeneralSettings
    {
        public string Server { get; set; } = "https://api-free.deepl.com/v2/translate";

        public string GlossaryId { get; set; } = string.Empty;
    }

    class SecureSettings : NMTBaseSecureSettings
    {
        public string AuthKey { get; set; } = string.Empty;        
    }
}
