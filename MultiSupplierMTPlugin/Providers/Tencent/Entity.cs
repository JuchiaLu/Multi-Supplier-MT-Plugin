using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.Tencent
{
    class TransRequest
    {
        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("ProjectId")]
        public int ProjectId { get; set; }

        [JsonProperty("SourceTextList")]
        public List<string> SourceTextList { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("Response")]
        public Response Response { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }
    }

    class Response
    {
        [JsonProperty("Error")]
        public Error Error { get; set; }

        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("TargetTextList")]
        public List<string> TargetTextList { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }
    }

    class Error
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

    }
}
