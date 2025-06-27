using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;

namespace MultiSupplierMTPlugin.Providers.Anthropic
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }

    class GeneralSettings : LLMBaseGeneralSettings
    {
        private double _temperature = 1.0;

        public override string BaseURL { get; set; } = "https://api.anthropic.com/v1";

        public override string Path { get; set; } = "/messages";        

        public override int MaxTokens { get; set; } = 4096;

        public override double Temperature
        {
            get => _temperature;
            set => _temperature = value > 1.0 ? 1.0 : value;
        }

        public override string Model { get; set; } = "claude-3-7-sonnet-latest";

        public override bool PromptCache { get; set; } = true;
    }

    class SecureSettings : LLMBaseSecureSettings
    {
        public override string ApiKey
        {
            get => XApiKey;
            set => XApiKey = value;
        }

        public string XApiKey { get; set; } = string.Empty;
    }
}
