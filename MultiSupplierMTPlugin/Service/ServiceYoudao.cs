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
using System.Web;


namespace MultiSupplierMTPlugin.Service
{
    public class ServiceYoudao : MultiSupplierMTServiceInterface
    {
        private class TransRequest
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


        private class TransResponse
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


        private class TransResult
        {
            [JsonProperty("query")]
            public string Query { get; set; }

            [JsonProperty("translation")]
            public string Translation { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }


        private static readonly string baseUrl = "https://openapi.youdao.com/v2/api";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh-CHS"},
            {"zho-TW", "zh-CHT"},
            {"eng", "en"},
            {"jpn", "jp"},
            {"kor", "kor"},
            {"fre", "fra"},
            {"spa", "spa"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"tur", "tr"},
            {"por-PT", "pt"},
            {"por", "pt"},
            {"vie", "vie"},
            {"ind", "id"},
            {"tha", "th"},
            {"msa", "may"},
            {"ara", "ar"},
            {"hin", "hi"},
        };

        private static readonly HttpClient httpClient = new HttpClient();


        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            new OptionsFormYoudao(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.YoudaoGeneralOptions.Checked;
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
            return 1;
        }

        public override int MaxThreadHold()
        {
            return 50;
        }

        public override string UniqueName()
        {
            return "Youdao";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string[] result = new string[texts.Count];

            string appKey = options.SecureSettings.YoudaoSecureOptions.AppKey;
            string appSecret = options.SecureSettings.YoudaoSecureOptions.AppSecret;

            Dictionary<String, String> formParameters = new Dictionary<String, String>();
            formParameters.Add("from", supportLanguages[srcLangCode]);
            formParameters.Add("to", supportLanguages[trgLangCode]);
            formParameters.Add("signType", "v3");
            formParameters.Add("appKey", appKey);

            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long millis = (long)ts.TotalMilliseconds;
            string curtime = Convert.ToString(millis / 1000);
            formParameters.Add("curtime", curtime);

            string salt = Guid.NewGuid().ToString();
            formParameters.Add("salt", salt);

            string signStr = appKey + truncate(string.Join("", texts)) + salt + curtime + appSecret; ;
            string sign = getSign(signStr);
            formParameters.Add("sign", sign);

            var builder = new StringBuilder();
            int i = 0;
            foreach (var item in formParameters)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }

            foreach (var item in texts)
            {
                builder.Append("&");
                builder.AppendFormat("q={0}", HttpUtility.UrlEncode(item));
            }

            string content = builder.ToString();
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var requestContent = new ByteArrayContent(contentBytes);
            requestContent.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.PostAsync(baseUrl, requestContent);
            response.EnsureSuccessStatusCode();
            
            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (!("0".Equals(transResponse.ErrorCode)))
            {
                throw new Exception("Error Code: " + transResponse.ErrorCode);
            }

            int j = 0;
            foreach (TransResult t in transResponse.TranslateResults)
            {
                result[j] = t.Translation;
                j++;
            }

            return result.ToList();
        }


        public static async Task<bool> Check(string appKey, string appSecre)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.YoudaoSecureOptions.AppKey = appKey;
            tempOptions.SecureSettings.YoudaoSecureOptions.AppSecret = appSecre;

            var service = new ServiceYoudao();
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
       
        private static string truncate(string q)
        {
            int len = q.Length;
            return len <= 20 ? q : (q.Substring(0, 10) + len + q.Substring(len - 10, 10));
        }

        private static string getSign(string input)
        {
            HashAlgorithm algorithm = new SHA256CryptoServiceProvider();
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}
