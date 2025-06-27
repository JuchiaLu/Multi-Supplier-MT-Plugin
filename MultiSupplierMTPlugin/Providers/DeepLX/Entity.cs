using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.DeepLX
{
    class TransRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("source_lang")]
        public string SourceLang { get; set; }

        [JsonProperty("target_lang")]
        public string TargetLang { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("alternatives")]
        public string[] Alternatives { get; set; }

        //[JsonProperty("code")]
        //public int Code { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        //[JsonProperty("id")]
        //public int Id { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("source_lang")]
        public string SourceLang { get; set; }

        [JsonProperty("target_lang")]
        public string TargetLang { get; set; }
    }
}
