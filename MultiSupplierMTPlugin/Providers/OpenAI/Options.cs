using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;

namespace MultiSupplierMTPlugin.Providers.OpenAI
{
    class Options : ProviderOptions
    {
        public Options() : base(new GeneralSettings(), new SecureSettings()) { }

        public Options(GeneralSettings generalOptions, SecureSettings secureOptions) : base(generalOptions, secureOptions) { }
    }


    class GeneralSettings : LLMBaseGeneralSettings
    {
        public override string BaseURL { get; set; } = "https://api.openai.com/v1";

        public override string Path { get; set; } = "/chat/completions";

        public override int MaxTokens { get; set; } = 4096;

        public override double Temperature { get; set; } = 1.0;

        public override string Model { get; set; } = "gpt-4o-mini";
    }

    class SecureSettings : LLMBaseSecureSettings
    {
        public override string ApiKey { get; set; } = string.Empty;

        public override string Organization { get; set; } = string.Empty;
    }
}
