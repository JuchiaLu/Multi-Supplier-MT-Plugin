using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.Baidu
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

        public string AppKey { get; set; } = string.Empty;
    }
}
