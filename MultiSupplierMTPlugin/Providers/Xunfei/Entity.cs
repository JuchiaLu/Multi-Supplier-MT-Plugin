using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.Providers.Xunfei
{
    class TransRequest
    {
        [JsonProperty("common")]
        public Common Common { get; set; }

        [JsonProperty("Business")]
        public Business Business { get; set; }

        [JsonProperty("data")]
        public RequestData Data { get; set; }
    }

    class Common
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }

    class Business
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("infmt", NullValueHandling = NullValueHandling.Ignore)]
        public string Infmt { get; set; }
    }

    class RequestData
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    class TransResponse
    {
        [JsonProperty("sid")]
        public string Sid { get; set; }

        [JsonProperty("data")]
        public ResponseData Data { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    class ResponseData
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    class Result
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("trans_result")]
        public TransResult TransResult { get; set; }
    }

    class TransResult
    {
        [JsonProperty("dst")]
        public string Dst { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }
    }
}
