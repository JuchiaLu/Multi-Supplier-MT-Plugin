using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.Papago
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
        public string ClientID { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;
    }
}
