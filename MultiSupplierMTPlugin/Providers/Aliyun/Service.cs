using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Aliyun
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://mt.cn-hangzhou.aliyuncs.com/api/translate/web";

        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options){ }


        public override string UniqueName { get; set; } = ServiceNames.Aliyun;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = true;

        public override bool IsBatchSupported { get; set; } = true;

        public override int MaxSegments { get; set; } = 10;

        public override int MaxCharacters { get; set; } = 3000;

        public override int MaxQueriesPerWindow { get; set; } = 45;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 50;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://ram.console.aliyun.com/users/detail";

        public override string ApiDocLink { get; set; } = "https://help.aliyun.com/zh/machine-translation/developer-reference/api-alimt-2018-10-12-translategeneral";

        public override Dictionary<string, string> SupportLangDic { get; set; } = SupportLang.Dic;

        public override ProviderOptions ShowConfig()
        {
            using (var form = new OptionsForm(this, _generalSettings, _secureSettings, _mtGeneralSettings, _mtSecureSettings))
            {
                form.ShowDialog();
            }

            return new Options(_generalSettings, _secureSettings);
        }

        public override async Task<List<string>> TranslateAsync(List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken, ProviderOptions tempOptions = null)
        {
            var (g, s) = ResolveOptions(tempOptions);

            var formatType = (_mtGeneralSettings.RequestType == RequestType.Plaintext) ? FormatType.text : FormatType.html;
            var apiType = "general".Equals(g.ServiceType) ? ApiType.translate_standard : ApiType.translate_ecommerce;
            var sourceText = texts.Select((text, index) => new { Index = index, Text = text }).ToDictionary(item => item.Index.ToString(), item => item.Text);

            var queryParameters = new Dictionary<string, string>()
            {
                {"FormatType", formatType.ToString()},
                {"TargetLanguage", SupportLang.Dic[trgLangCode]},
                {"SourceLanguage", SupportLang.Dic[srcLangCode]},
                {"Scene", Scene.general.ToString()},
                {"ApiType", apiType.ToString()},
                {"SourceText", JsonConvert.SerializeObject(sourceText)},
            };

            var baseUrl = _baseUrl + "/" + g.ServiceType;
            var requestUrl = GenerateRequestUrl(baseUrl, HttpMethod.Get, s.AccessKeyId, s.AccessKeySecret, queryParameters);

            var transResponse = await _httpClient.Get(requestUrl)
                .ReceiveJson<TransResponse>(cToken);

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


        private static string GenerateRequestUrl(string baseUrl, HttpMethod httpMethod, string accessKeyId, string accessKeySecret, Dictionary<string, string> queryParameters)
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
            var canonicalizedQueryString = string.Join("&", queryParameters.OrderBy(x => x.Key).Select(x => PercentEncode(x.Key) + "=" + PercentEncode(x.Value)));

            //构造待签名字符串：
            var stringToSign =
                httpMethod.ToString().ToUpper() + "&"
                + PercentEncode("/") + "&"
                + PercentEncode(canonicalizedQueryString);
            
            //生成签名
            var keyBytes = Encoding.UTF8.GetBytes(accessKeySecret + "&");
            var signatureBytes = new HMACSHA1(keyBytes).ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
            var signature = Convert.ToBase64String(signatureBytes);

            //将生成的签名添加到参数
            queryParameters.Add("Signature", signature);

            //生成 url 并返回
            return baseUrl + "?" + string.Join("&", queryParameters.Select(x => x.Key + "=" + System.Web.HttpUtility.UrlEncode(x.Value)));
        }

        private static string PercentEncode(string value)
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