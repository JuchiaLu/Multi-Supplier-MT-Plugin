namespace MultiSupplierMTPlugin.ProvidersCommon.Options.LLM
{
    class LLMBaseGeneralSettings : ProviderGeneralSettings
    {
        public virtual string BaseURL { get; set; } = string.Empty;
        public virtual string Path { get; set; } = "/chat/completions";

        public virtual int MaxTokens { get; set; } = 4096;
        public virtual double Temperature { get; set; } = 1.0;

        public virtual string Model { get; set; } = string.Empty;        
        public virtual ModelItem[] UserModels { get; set; } = new ModelItem[0];
        public virtual string[] HidenBuildInModels { get; set; } = new string[0];

        public virtual bool PromptCache { get; set; } = false;

        public virtual string PromptTemplateId { get; set; } = "Default";
        public virtual string SystemPrompt { get; set; } = string.Empty;
        public virtual string UserPrompt { get; set; } = string.Empty;
        public virtual string BathTranslateSystemPrompt { get; set; } = string.Empty;
        public virtual string BathTranslateUserPrompt { get; set; } = string.Empty;

        public virtual bool EnableBathTranslate { get; set; } = false;
        public virtual int BathTranslateMaxSegments { get; set; } = 10;
        public virtual int BathTranslateMaxCharacters { get; set; } = 3000;
        public virtual BathTranslateSchema BathTranslateSchema { get; set; } = BathTranslateSchema.Shorter;
        public virtual BathTranslateResponseFormat BathTranslateResponseFormat { get; set; } = BathTranslateResponseFormat.JSON_Object;        
    }

    class LLMBaseSecureSettings : ProviderSecureSettings
    {
        public virtual string ApiKey { get; set; } = string.Empty;

        public virtual string Organization { get; set; } = string.Empty;
    }


    enum BathTranslateSchema
    {
        Shorter,
        Longer
    }

    enum BathTranslateResponseFormat
    {
        Text,
        JSON_Object,
        JSON_Schema
    }

    class ModelItem
    {
        public string UniqueName { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;
    }

}
