using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.DeepLX
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : NMTBaseGeneralSettings
    {
        public string Server { get; set; } = "http://localhost:1188";

        public string Endpoint { get; set; } = "Free";
    }

    class SecureSettings : NMTBaseSecureSettings
    {
        public string AuthKey { get; set; } = string.Empty;        
    }
}
