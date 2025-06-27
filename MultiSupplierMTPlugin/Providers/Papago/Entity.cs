using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.Papago
{
    class TransRequest
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("message")]
        public Message Message { get; set; }
    }

    class Message
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    class Result
    {
        [JsonProperty("srcLangType")]
        public string SrcLangType { get; set; }

        [JsonProperty("tarLangType")]
        public string TarLangType { get; set; }

        [JsonProperty("translatedText")]
        public string TranslatedText { get; set; }
    }
}
