using MemoQ.Addins.Common.Utils;
using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceHuoshan : MultiSupplierMTServiceInterface
    {
        private class Sign
        {
            private readonly string _region;
            private readonly string _service;
            private readonly string _schema;
            private readonly string _host;
            private readonly string _path;
            private readonly string _ak;
            private readonly string _sk;

            private static readonly Encoding Utf8 = Encoding.UTF8;

            private readonly HttpClient _httpClient;

            public Sign(string region, string service, string schema, string host, string path, string ak, string sk, HttpClient httpClient)
            {
                _region = region;
                _service = service;
                _schema = schema;
                _host = host;
                _path = path;
                _ak = ak;
                _sk = sk;
                _httpClient = httpClient;
            }

            public async Task<HttpResponseMessage> Request(HttpMethod method, List<KeyValuePair<string, string>> queryList, byte[] body, string contentType,
                DateTimeOffset date, string action, string version)
            {
                body = body ?? Array.Empty<byte>();
                if (string.IsNullOrWhiteSpace(contentType))
                {
                    contentType = "application/x-www-form-urlencoded";
                }

                string xContentSha256 = ToHexString(HashSha256(body));
                string xDate = date.UtcDateTime.ToString("yyyyMMdd'T'HHmmss'Z'");
                string shortXDate = xDate.Substring(0, 8);
                string signHeader = "host;x-date;x-content-sha256;content-type";

                var realQueryDict = new Dictionary<string, List<string>>();
                foreach (var kvp in queryList)
                {
                    if (!realQueryDict.TryGetValue(kvp.Key, out List<string> values))
                    {
                        values = new List<string>();
                        realQueryDict[kvp.Key] = values;
                    }
                    values.Add(kvp.Value);
                }

                realQueryDict.Add("Action", new List<string> { action });
                realQueryDict.Add("Version", new List<string> { version });

                var queryBuilder = new StringBuilder();
                foreach (var kvp in realQueryDict)
                {
                    foreach (var value in kvp.Value)
                    {
                        if (queryBuilder.Length > 0)
                        {
                            queryBuilder.Append('&');
                        }
                        queryBuilder.Append(HttpUtility.UrlEncode(kvp.Key));
                        queryBuilder.Append('=');
                        queryBuilder.Append(HttpUtility.UrlEncode(value));
                    }
                }
                string query = queryBuilder.ToString();

                string canonicalStringBuilder =
                    $"{method}\n" +
                    $"{_path}\n" +
                    $"{query}\n" +
                    $"host:{_host}\n" +
                    $"x-date:{xDate}\n" +
                    $"x-content-sha256:{xContentSha256}\n" +
                    $"content-type:{contentType}\n" +
                    $"\n" +
                    $"{signHeader}\n" +
                    $"{xContentSha256}";

                string hashCanonicalString = ToHexString(HashSha256(Utf8.GetBytes(canonicalStringBuilder)));
                string credentialScope = $"{shortXDate}/{_region}/{_service}/request";
                string signString = $"HMAC-SHA256\n{xDate}\n{credentialScope}\n{hashCanonicalString}";

                byte[] signKey = GenSigningSecretKeyV4(_sk, shortXDate, _region, _service);
                string signature = ToHexString(HmacSha256(signKey, signString));

                Uri url = new Uri($"{_schema}://{_host}{_path}?{query}");
                var request = new HttpRequestMessage();
                request.Method = method;
                request.RequestUri = url;
                request.Headers.TryAddWithoutValidation("Host", _host);
                request.Headers.Add("X-Date", xDate);
                request.Headers.Add("X-Content-Sha256", xContentSha256);
                request.Headers.TryAddWithoutValidation("Authorization",
                    $"HMAC-SHA256 Credential={_ak}/{credentialScope}, SignedHeaders={signHeader}, Signature={signature}");
                HttpContent content = new ByteArrayContent(body);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                request.Content = content;

                return await _httpClient.SendAsync(request);
            }

            private byte[] GenSigningSecretKeyV4(string secretKey, string date, string region, string service)
            {
                byte[] kDate = HmacSha256(Utf8.GetBytes(secretKey), date);
                byte[] kRegion = HmacSha256(kDate, region);
                byte[] kService = HmacSha256(kRegion, service);
                return HmacSha256(kService, "request");
            }

            private static byte[] HmacSha256(byte[] secret, string text)
            {
                using (HMACSHA256 mac = new HMACSHA256(secret))
                {
                    var hash = mac.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return hash;
                }
            }

            private static byte[] HashSha256(byte[] data)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    var hash = sha.ComputeHash(data);
                    return hash;
                }
            }

            private static string ToHexString(byte[] bytes)
            {
                if (bytes == null)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                foreach (var t in bytes)
                {
                    sb.Append(t.ToString("X2"));
                }

                return sb.ToString().ToLower();
            }
        }
       

        private class TransRequest
        {
            [JsonProperty("SourceLanguage")]
            public string SourceLanguage { get; set; }

            [JsonProperty("TargetLanguage")]
            public string TargetLanguage { get; set; }

            [JsonProperty("TextList")]
            public List<string> TextList { get; set; }
        }

        private class TransResponse
        {
            [JsonProperty("ResponseMetadata")]
            public ResponseMetadata ResponseMetadata { get; set; }

            [JsonProperty("TranslationList")]
            public List<TranslationItem> TranslationList { get; set; }
        }

        private class TranslationItem
        {
            [JsonProperty("Translation")]
            public string Translation { get; set; }

            [JsonProperty("DetectedSourceLanguage")]
            public string DetectedSourceLanguage { get; set; }
        }

        private class ResponseMetadata
        {
            [JsonProperty("Error")]
            public Error Error { get; set; }

            [JsonProperty("RequestId")]
            public string RequestId { get; set; }

            [JsonProperty("Action")]
            public string Action { get; set; }

            [JsonProperty("Version")]
            public string Version { get; set; }

            [JsonProperty("Service")]
            public string Service { get; set; }

            [JsonProperty("Region")]
            public string Region { get; set; }
        }

        private class Error
        {
            [JsonProperty("Code")]
            public string Code { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }
        }


        private static readonly string baseUrl = "https://translate.volcengineapi.com";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "zh-Hant"},
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
            new OptionsFormHuoshan(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.HuoshanGeneralOptions.Checked; ;
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return supportLanguages.ContainsKey(srcLangCode) && supportLanguages.ContainsKey(trgLangCode);
        }

        public override int MaxBatchSize()
        {
            return 10;
        }

        public override int MaxQueriesPerSecond()
        {
            return 5;
        }

        public override int MaxThreadHold()
        {
            return 10;
        }

        public override string UniqueName()
        {
            return "Huoshan";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            
            string region = "cn-north-1";
            string service = "translate";

            string schema = "https";
            string host = "translate.volcengineapi.com";
            string path = "/";

            string k_access_key = options.SecureSettings.HuoshanSecureOptions.AccessKey;
            string k_secret_key = options.SecureSettings.HuoshanSecureOptions.SecretKey;


            var sign = new Sign(region, service, schema,  host, path, k_access_key, k_secret_key, httpClient);

            var transRequest = new TransRequest()
            {
                SourceLanguage = supportLanguages[srcLangCode],
                TargetLanguage = supportLanguages[trgLangCode],
                TextList = texts,
            };
            var jsonRequestBody = JsonConvert.SerializeObject(transRequest);
            byte[] jsonRequestBytes = Encoding.UTF8.GetBytes(jsonRequestBody);

            string action = "TranslateText";
            string version = "2020-06-01";
            string contentType = "application/json";
            HttpResponseMessage response = await sign.Request(HttpMethod.Post, new List<KeyValuePair<string, string>>(),
                    jsonRequestBytes, contentType: contentType, DateTimeOffset.Now, action, version);

            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.ResponseMetadata.Error != null)
            {
                throw new Exception(transResponse.ResponseMetadata.Error.Message);
            }

            return transResponse.TranslationList.Select(item => item.Translation).ToList();
        }


        public static async Task<bool> Check(string appId, string appKey)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.HuoshanSecureOptions.AccessKey = appId;
            tempOptions.SecureSettings.HuoshanSecureOptions.SecretKey = appKey;

            var service = new ServiceHuoshan();
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
    }
}
