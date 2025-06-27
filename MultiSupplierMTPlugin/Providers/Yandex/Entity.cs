using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSupplierMTPlugin.Providers.Yandex
{
    class TransRequest
    {
        [JsonProperty("texts")]
        public string[] Texts { get; set; }

        [JsonProperty("sourceLanguageCode")]
        public string SourceLanguageCode { get; set; }

        [JsonProperty("targetLanguageCode")]
        public string TargetLanguageCode { get; set; }

        [JsonProperty("folderId")]
        public string FolderId { get; set; }

        [JsonProperty("glossaryConfig")]
        public GlossaryConfig GlossaryConfig { get; set; }

        [JsonProperty("speller")]
        public bool Speller { get; set; }

        [JsonProperty("format")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Format Format { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }

    public enum Format
    {
        FORMAT_UNSPECIFIED,
        PLAIN_TEXT,
        HTML
    }

    class GlossaryConfig
    {
        [JsonProperty("glossaryData")]
        public GlossaryData GlossaryData { get; set; }         
    }

    class GlossaryData
    {
        [JsonProperty("glossaryPairs")]
        public GlossaryPairs[] GlossaryPairs { get; set; }
    }

    class GlossaryPairs
    {
        [JsonProperty("sourceText")]
        public string SourceText { get; set; }

        [JsonProperty("translatedText")]
        public string TranslatedText { get; set; }

        [JsonProperty("exact")]
        public bool Exact { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("translations")]
        public Translation[] Translations { get; set; }
    }

    class Translation
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("detectedLanguageCode")]
        public string DetectedLanguageCode { get; set; }
    }
}
