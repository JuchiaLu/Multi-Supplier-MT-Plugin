using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.Aliyun
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()){ }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : NMTBaseGeneralSettings
    {
        public string ServiceType { get; set; } = "general";
    }

    class SecureSettings : NMTBaseSecureSettings
    {
        public string AccessKeyId { get; set; } = string.Empty;

        public string AccessKeySecret { get; set; } = string.Empty;
    }
}
