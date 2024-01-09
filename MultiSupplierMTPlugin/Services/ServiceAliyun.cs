using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.Services;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceAliyun : MTServiceInterface
    {
        private class TransRequest
        {
            
            [JsonProperty("Action")]
            public string Action { get; set; }

            [JsonProperty("FormatType")]
            [JsonConverter(typeof(StringEnumConverter))]
            public FormatType FormatType { get; set; }

            [JsonProperty("TargetLanguage")]
            public string TargetLanguage { get; set; }

            [JsonProperty("SourceLanguage")]
            public string SourceLanguage { get; set; }

            [JsonProperty("Scene")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Scene Scene { get; set; }

            [JsonProperty("ApiType")]
            [JsonConverter(typeof(StringEnumConverter))]
            public ApiType ApiType { get; set; }

            [JsonProperty("SourceText")]
            public Dictionary<string, string> SourceText { get; set; }
        }

        private class TransResponse
        {
            [JsonProperty("Code")]
            public int Code { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("RequestId")]
            public string RequestId { get; set; }

            [JsonProperty("TranslatedList")]
            public List<Data> TranslatedList { get; set; }
        }

        private class Data
        {
            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("wordCount")]
            public string WordCount { get; set; }

            [JsonProperty("detectedLanguage")]
            public string DetectedLanguage { get; set; }

            [JsonProperty("index")]
            public string Index { get; set; }

            [JsonProperty("translated")]
            public string Translated { get; set; }
        }

        private enum Scene 
        {
            general,
            title,
            description,
            communication,
            medical,
            social,
            finance
        }

        private enum ApiType 
        {
            translate_standard,
            translate_ecommerce
        }

        private enum FormatType
        { 
            text,
            html,
        }


        private static readonly string baseUrl = "https://mt.cn-hangzhou.aliyuncs.com/api/translate/web";
        
        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "zh-tw"},
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
            new OptionsFormAliyun(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.AliyunGeneralOptions.Checked;
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
            return 10;
        }

        public override int MaxThreadHold()
        {
            return 50;
        }

        public override string UniqueName()
        {
            return "Aliyun";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string accessKeyId = options.SecureSettings.AliyunSecureOptions.AccessKeyId;
            string accessKeySecret = options.SecureSettings.AliyunSecureOptions.AccessKeySecret;
            string serviceType = options.GeneralSettings.AliyunGeneralOptions.ServiceType;

            var formatType = (options.GeneralSettings.RequestType == RequestType.Plaintext) ? FormatType.text : FormatType.html;
            var apiType = "general".Equals(serviceType) ? ApiType.translate_standard : ApiType.translate_ecommerce;
            var sourceText = texts.Select((text, index) => new { Index = index, Text = text }).ToDictionary(item => item.Index.ToString(), item => item.Text);

            var queryParameters = new Dictionary<string, string>()
            {
                {"FormatType", formatType.ToString()},
                {"TargetLanguage", supportLanguages[trgLangCode]},
                {"SourceLanguage", supportLanguages[srcLangCode]},
                {"Scene", Scene.general.ToString()},
                {"ApiType", apiType.ToString()},
                {"SourceText", JsonConvert.SerializeObject(sourceText)},
            };

            var baseUrl = ServiceAliyun.baseUrl + "/" + serviceType;
            var requestUrl = generateRequestUrl(baseUrl, HttpMethod.Get, accessKeyId, accessKeySecret, queryParameters);

            var response = await httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
  
            var jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.Code != 200)
            {
                throw new Exception(transResponse.Message);
            }

            var result = new string[texts.Count];
            foreach (var data in transResponse.TranslatedList)
            {
                result[int.Parse(data.Index)] = data.Translated;
            }

            return result.ToList();
        }


        public static async Task<bool> Check(string serviceType, string appId, string appKey)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.GeneralSettings.AliyunGeneralOptions.ServiceType = serviceType;
            tempOptions.SecureSettings.AliyunSecureOptions.AccessKeyId = appId;
            tempOptions.SecureSettings.AliyunSecureOptions.AccessKeySecret = appKey;

            var service = new ServiceAliyun();
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


        private static string generateRequestUrl(string baseUrl, HttpMethod httpMethod, string accessKeyId, string accessKeySecret, Dictionary<string, string> queryParameters)
        {
            // 添加公共请求参数
            queryParameters.Add("Action", "GetBatchTranslate"); //取决于调用的服务
            queryParameters.Add("Version", "2018-10-12"); //取决于调用的服务
            queryParameters.Add("Format", "JSON"); //或 XML
            queryParameters.Add("SignatureVersion", "1.0"); //目前固定 1.0
            queryParameters.Add("SignatureMethod", "HMAC-SHA1"); //目前固定 HMAC-SHA1
            queryParameters.Add("SignatureNonce", Guid.NewGuid().ToString()); //随机数，防止重放攻击
            queryParameters.Add("Timestamp", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            queryParameters.Add("AccessKeyId", accessKeyId);

            //构造规范化请求字符串：
            //1、根据参数排序。
            //2、对参数和参数值编码。
            //3、使用等号（=）连接参数和参数值
            //4、使用与号（&）连接参数对。
            var canonicalizedQueryString = string.Join("&", queryParameters.OrderBy(x => x.Key).Select(x => percentEncode(x.Key) + "=" + percentEncode(x.Value)));

            //构造待签名字符串：
            var stringToSign =
                httpMethod.ToString().ToUpper() + "&"
                + percentEncode("/") + "&"
                + percentEncode(canonicalizedQueryString);
            
            //生成签名
            var keyBytes = Encoding.UTF8.GetBytes(accessKeySecret + "&");
            var signatureBytes = new HMACSHA1(keyBytes).ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
            var signature = Convert.ToBase64String(signatureBytes);

            //将生成的签名添加到参数
            queryParameters.Add("Signature", signature);

            //生成 url 并返回
            return baseUrl + "?" + string.Join("&", queryParameters.Select(x => x.Key + "=" + System.Web.HttpUtility.UrlEncode(x.Value)));
        }

        private static string percentEncode(string value)
        {
            var stringBuilder = new StringBuilder();
            var text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            var bytes = Encoding.GetEncoding("UTF-8").GetBytes(value);
            foreach (char c in bytes)
            {
                if (text.IndexOf(c) >= 0)
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    stringBuilder.Append("%").Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)c));
                }
            }

            return stringBuilder.ToString();
        }
    }
}