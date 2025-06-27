using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.DeepL
{
    class TransRequest
    {
        [JsonProperty("text")]
        public string[] Text { get; set; }

        [JsonProperty("source_lang")]
        public string SourceLang { get; set; }

        [JsonProperty("target_lang")]
        public string TargetLang { get; set; }


        [JsonProperty("context")]
        public string Context { get; set; } //✔


        [JsonProperty("show_billed_characters")]
        public bool ShowBilledCharacters { get; set; }

        [JsonProperty("split_sentences")]
        public string SplitSentences { get; set; }


        [JsonProperty("preserve_formatting")]
        public bool PreserveFormatting { get; set; } //✔


        [JsonProperty("formality")]
        public string Formality { get; set; } //✔

        [JsonProperty("model_type")]
        public string ModelType { get; set; }

        [JsonProperty("glossary_id")]
        public string GlossaryId { get; set; } //✔


        [JsonProperty("tag_handling")]
        public string TagHandling { get; set; } //✔

        [JsonProperty("outline_detection")]
        public bool OutlineDetection { get; set; }

        [JsonProperty("non_splitting_tags")]
        public string[] NonDplittingTags { get; set; }

        [JsonProperty("splitting_tags")]
        public string[] SplittingTags { get; set; }

        [JsonProperty("ignore_tags")]
        public string[] IgnoreTags { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("translations")]
        public Translation[] Translations { get; set; }
    }

    class Translation
    {
        [JsonProperty("detected_source_language")]
        public string DetectedSourceLanguage { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("billed_characters")]
        public int BilledCharacters { get; set; }

        [JsonProperty("model_type_used")]
        public string ModelTypeUsed { get; set; }
    }
}
