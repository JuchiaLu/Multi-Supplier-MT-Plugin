using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.Caiyun
{
    class TransRequest
    {
        [JsonProperty("source")]
        public List<string> Source { get; set; }

        [JsonProperty("trans_type")]
        public string TransType { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("detect")]
        public bool Detect { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("target")]
        public List<string> Target { get; set; }

        [JsonProperty("rc")]
        public int Rc { get; set; }

        [JsonProperty("confidence")]
        public float Confidence { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
