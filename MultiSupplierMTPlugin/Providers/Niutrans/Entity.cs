using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.Niutrans
{
    class TransRequest
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("apikey")]
        public string Apikey { get; set; }

        [JsonProperty("src_text")]
        public string SrcText { get; set; }

        [JsonProperty("dictNo")]
        public string DictNo { get; set; }

        [JsonProperty("memoryNo")]
        public string MemoryNo { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("apikey")]
        public string Apikey { get; set; }

        [JsonProperty("src_text")]
        public string SrcText { get; set; }

        [JsonProperty("tgt_text")]
        public string TgtText { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_msg")]
        public string ErrorMsg { get; set; }
    }
}
