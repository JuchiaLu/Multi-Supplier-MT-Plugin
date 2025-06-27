using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.DeepLBuiltIn
{

    class DeepLResponse
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonProperty("Result")]
        public DeepLResult Result { get; set; }
    }

    class DeepLResult
    {
        [JsonProperty("Texts")]
        public DeepLTextResult[] Texts { get; set; }

        [JsonProperty("Lang")]
        public string Lang { get; set; }
    }

    class DeepLTextResult
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }
}
