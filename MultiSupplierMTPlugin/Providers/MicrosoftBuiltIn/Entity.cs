using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.MicrosoftBuiltIn
{
    class TranslationRequestItem
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    class TranslationResponseItem
    {
        [JsonProperty("Translations")]
        public List<Translation> Translations { get; set; }
    }

    class Translation
    {
        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("To")]
        public string To { get; set; }

        [JsonProperty("SentLen")]
        public SentenceLength SentLen { get; set; }
    }

    class SentenceLength
    {
        [JsonProperty("SrcSentLen")]
        public List<int> SrcSentLen { get; set; }

        [JsonProperty("TransSentLen")]
        public List<int> TransSentLen { get; set; }
    }
}
