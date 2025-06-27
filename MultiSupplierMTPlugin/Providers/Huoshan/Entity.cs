using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.Huoshan
{
    class TransRequest
    {
        [JsonProperty("SourceLanguage")]
        public string SourceLanguage { get; set; }

        [JsonProperty("TargetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonProperty("TextList")]
        public List<string> TextList { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("ResponseMetadata")]
        public ResponseMetadata ResponseMetadata { get; set; }

        [JsonProperty("TranslationList")]
        public List<TranslationItem> TranslationList { get; set; }
    }

    class TranslationItem
    {
        [JsonProperty("Translation")]
        public string Translation { get; set; }

        [JsonProperty("DetectedSourceLanguage")]
        public string DetectedSourceLanguage { get; set; }
    }

    class ResponseMetadata
    {
        [JsonProperty("Error")]
        public Error Error { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Service")]
        public string Service { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }
    }

    class Error
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
