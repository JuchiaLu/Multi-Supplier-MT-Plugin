using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.Xunfei
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : NMTBaseGeneralSettings
    {
    }

    class SecureSettings : NMTBaseSecureSettings
    {
        public string AppId { get; set; } = string.Empty;

        public string ApiKey { get; set; } = string.Empty;

        public string ApiSecret { get; set; } = string.Empty;
    }
}
