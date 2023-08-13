using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceXunfei : MultiSupplierMTServiceInterface
    {
        private class TransRequest
        {
            [JsonProperty("common")]
            public Common Common { get; set; }

            [JsonProperty("Business")]
            public Business Business { get; set; }

            [JsonProperty("data")]
            public RequestData Data { get; set; }

        }

        private class Common
        {
            [JsonProperty("app_id")]
            public string AppId { get; set; }
        }

        private class Business
        {
            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }


            [JsonProperty("infmt", NullValueHandling = NullValueHandling.Ignore)]
            public string Infmt { get; set; }
        }

        private class RequestData
        {
            [JsonProperty("text")]
            public string Text { get; set; }
        }

        private class TransResponse
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


        private class ResponseData
        {
            [JsonProperty("result")]
            public Result Result { get; set; }
        }

        private class Result
        {
            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("trans_result")]
            public TransResult TransResult { get; set; }

        }

        private class TransResult 
        {
            [JsonProperty("dst")]
            public string Dst { get; set; }

            [JsonProperty("src")]
            public string Src { get; set; }

        }

        private static readonly string baseUrl = "https://ntrans.xfyun.cn/v2/ots";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "cht"},
            {"eng", "en"},
            {"jpn", "ja"},
            {"kor", "ko"},
            {"fre", "fr"},
            {"spa", "es"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"tur", "tr"},
            {"por-PT", "pt"},
            {"por", "pt"},
            {"vie", "vi"},
            {"ind", "id"},
            {"tha", "th"},
            {"msa", "ms"},
            {"ara", "ar"},
            {"hin", "hi"},
        };

        private static readonly HttpClient httpClient = new HttpClient();


        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            new OptionsFormXunfei(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.XunfeiGeneralOptions.Checked;
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return supportLanguages.ContainsKey(srcLangCode) && supportLanguages.ContainsKey(trgLangCode);
        }

        public override int MaxBatchSize()
        {
            return 1;
        }

        public override int MaxQueriesPerSecond()
        {
            return 3;
        }

        public override int MaxThreadHold()
        {
            return 10;
        }

        public override string UniqueName()
        {
            return "Xunfei";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string[] result = new string[texts.Count];

            string appId = options.SecureSettings.XunfeiSecureOptions.AppId;
            string apiKey = options.SecureSettings.XunfeiSecureOptions.ApiKey;
            string apiSecret = options.SecureSettings.XunfeiSecureOptions.ApiSecret;

            var formatType = (options.GeneralSettings.RequestType == RequestType.Plaintext) ?  null : "xml";

            TransRequest transRequest = new TransRequest()
            {
                Common = new Common()
                {
                    AppId = appId
                },

                Business = new Business()
                {
                    From = supportLanguages[srcLangCode],
                    To = supportLanguages[trgLangCode],
                    Infmt = formatType
                },

                Data = new RequestData()
                {
                    Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(texts[0]))
                }
            };
            string jsonRequest = JsonConvert.SerializeObject(transRequest);

            Uri url = new Uri(baseUrl);
            string date = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", System.Globalization.CultureInfo.InvariantCulture);
            string digestBase64 = "SHA-256=" + SignBody(jsonRequest);
            
            var builder = new StringBuilder($"host: {url.Host}\n");
            builder.Append($"date: {date}\n");
            builder.Append($"POST {url.AbsolutePath} HTTP/1.1\n");
            builder.Append($"digest: {digestBase64}");

            string sha = HmacSign(builder.ToString(), apiSecret);
            string authorization = $"api_key=\"{apiKey}\", algorithm=\"hmac-sha256\", headers=\"host date request-line digest\", signature=\"{sha}\"";

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.TryAddWithoutValidation("Authorization", authorization);
            requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json,version=1.0");
            requestMessage.Headers.Host = url.Host;
            requestMessage.Headers.TryAddWithoutValidation("Date", date);
            requestMessage.Headers.Add("Digest", digestBase64);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            requestMessage.Content = content;

            var response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.Code != 0)
            {
                throw new Exception(transResponse.Message);
            }

            result[0] = transResponse.Data.Result.TransResult.Dst;

            return result.ToList();
        }


        public static async Task<bool> Check(string appId, string apiKey, string apiSecret)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.XunfeiSecureOptions.AppId = appId;
            tempOptions.SecureSettings.XunfeiSecureOptions.ApiKey = apiKey;
            tempOptions.SecureSettings.XunfeiSecureOptions.ApiSecret = apiSecret;

            var service = new ServiceXunfei();
            try
            {
                await service.BatchTranslate(tempOptions, new List<string>() { "test" }, "eng", "zho-CN", null, null, null);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private static string SignBody(string body)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private static string HmacSign(string signature, string apiSecret)
        {
            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecret)))
            {
                byte[] hashBytes = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(signature));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
