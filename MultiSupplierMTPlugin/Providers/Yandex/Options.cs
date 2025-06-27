using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;

namespace MultiSupplierMTPlugin.Providers.Yandex
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : NMTBaseGeneralSettings
    {
        public AuthorizationType AuthorizationType { get; set; } = AuthorizationType.ApiKey;

        public string FolderId { get; set; } = string.Empty;

        public string GlossaryDelimiter { get; set; } = ",";

        public string GlossaryFilePath { get; set; } = string.Empty;

        public bool GlossaryExact { get; set; } = false;

        public string Model { get; set; } = string.Empty;

        public bool Speller { get; set; } = false;   
    }

    class SecureSettings : NMTBaseSecureSettings
    {
        public string KeyOrToken { get; set; } = string.Empty;
    }

    public enum AuthorizationType
    {
        ApiKey,
        IamToken,
    }
}
