using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.ModernmtBuiltIn
{
    class TransResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("initialValue")]
        public InitialValue InitialValue { get; set; }

        [JsonProperty("fields")]
        public string[] Fields { get; set; }

        [JsonProperty("value")]
        public Value Value { get; set; }
    }

    class InitialValue
    {
        [JsonProperty("sourceLanguage")]
        public string SourceLanguage { get; set; }

        [JsonProperty("targetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    class Value
    {
        [JsonProperty("translation")]
        public string Translation { get; set; }
    }
}
