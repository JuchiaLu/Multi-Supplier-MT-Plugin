using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.Aliyun
{
    class TransRequest
    {

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("FormatType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FormatType FormatType { get; set; }

        [JsonProperty("TargetLanguage")]
        public string TargetLanguage { get; set; }

        [JsonProperty("SourceLanguage")]
        public string SourceLanguage { get; set; }

        [JsonProperty("Scene")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Scene Scene { get; set; }

        [JsonProperty("ApiType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiType ApiType { get; set; }

        [JsonProperty("SourceText")]
        public Dictionary<string, string> SourceText { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("Code")]
        public int Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }

        [JsonProperty("TranslatedList")]
        public List<Data> TranslatedList { get; set; }
    }

    class Data
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("wordCount")]
        public string WordCount { get; set; }

        [JsonProperty("detectedLanguage")]
        public string DetectedLanguage { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("translated")]
        public string Translated { get; set; }
    }

    enum Scene
    {
        general,
        title,
        description,
        communication,
        medical,
        social,
        finance
    }

    enum ApiType
    {
        translate_standard,
        translate_ecommerce
    }

    enum FormatType
    {
        text,
        html,
    }
}