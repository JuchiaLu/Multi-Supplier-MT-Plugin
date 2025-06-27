using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin.Providers.Youdao
{
    class TransRequest
    {
        [JsonProperty("q")]
        public List<string> Q { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("SignType")]
        public string SignType { get; set; }


        [JsonProperty("ext")]
        public string Ext { get; set; }

        [JsonProperty("voice")]
        public string Voice { get; set; }

        [JsonProperty("detectLevel")]
        public string DetectLevel { get; set; }

        [JsonProperty("detectFilter")]
        public string DetectFilter { get; set; }

        [JsonProperty("verifyLang")]
        public string VerifyLang { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("l")]
        public string L { get; set; }

        [JsonProperty("errorIndex")]
        public List<int> ErrorIndex { get; set; }

        [JsonProperty("translateResults")]
        public List<TransResult> TranslateResults { get; set; }
    }

    class TransResult
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("translation")]
        public string Translation { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
