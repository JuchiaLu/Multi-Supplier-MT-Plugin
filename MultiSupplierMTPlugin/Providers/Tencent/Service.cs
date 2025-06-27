using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Tencent
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://tmt.tencentcloudapi.com";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Tencent;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = false;

        public override bool IsBatchSupported { get; set; } = true;

        public override int MaxSegments { get; set; } = 10;

        public override int MaxCharacters { get; set; } = 3000;

        public override int MaxQueriesPerWindow { get; set; } = 4;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 5;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://console.cloud.tencent.com/cam/capi";

        public override string ApiDocLink { get; set; } = "https://cloud.tencent.com/document/product/551/40566";

        public override Dictionary<string, string> SupportLangDic { get; set; } = SupportLang.Dic;

        public override ProviderOptions ShowConfig()
        {
            using (var form = new OptionsForm(this, _generalSettings, _secureSettings, _mtGeneralSettings, _mtSecureSettings))
            {
                form.ShowDialog();
            }

            return new Options(_generalSettings, _secureSettings);
        }

        public override async Task<List<string>> TranslateAsync(List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken, ProviderOptions tempOptions)
        {
            var (g, s) = ResolveOptions(tempOptions);

            var transRequest = new TransRequest()
            {
                Source = SupportLang.Dic[srcLangCode],
                Target = SupportLang.Dic[trgLangCode],
                ProjectId = 0,
                SourceTextList = texts
            };

            var jsonRequest = JsonConvert.SerializeObject(transRequest);
            var headers = BuildHeaders(s.SecretId, s.SecretKey, jsonRequest);
            
            var transResponse = await _httpClient.Post(_baseUrl)
                .AddHeaders(headers)               
                .SetBodyJsonString(jsonRequest)
                .ReceiveJson<TransResponse>(cToken);
            
            if (transResponse.Response.Error != null)
            {
                throw new Exception(transResponse.Response.Error.Message);
            }
            
            return transResponse.Response.TargetTextList;
        }


        private Dictionary<string, string> BuildHeaders(string secretId, string secretKey, string requestPayload)
        {
            //string secretId = "";
            //string secretKey = "";

            string host = "tmt.tencentcloudapi.com";
            string region = "ap-guangzhou";
            string service = "tmt";
            string version = "2018-03-21";
            string action = "TextTranslateBatch";

            //云 API 支持 GET 和 POST 请求。
            //对于GET方法，只支持 Content-Type: application/x-www-form-urlencoded 协议格式。
            //对于POST方法，目前支持 Content-Type: application/json 以及 Content-Type: multipart/form-data 两种协议格式，
            //json 格式绝大多数接口均支持，multipart 格式只有特定接口支持，此时该接口不能使用 json 格式调用，参考具体业务接口文档说明。
            string httpRequestMethod = "POST"; //HTTP 请求方法（GET、POST ）。
            string contentType = "application/json; charset=utf-8";
            string canonicalQueryString = ""; //查询字符串（不包括问号），参数需要进行 URLEncode，对于 POST 请求，固定为空字符串""。
            //string requestPayload = ""; //请求正文（body），对于 GET 请求，固定为空字符串""。

            string canonicalURI = "/"; //URI 参数，API 3.0 固定为正斜杠（/）。

            //1. 拼接规范请求串
            //参与签名的头部信息，至少包含 host 和 content-type 两个头部
            //头部 key 和 value 统一转成小写，并去掉首尾空格，按照 key:value\n 格式拼接；
            //多个头部，按照头部 key（小写）的 ASCII 升序进行拼接。
            string canonicalHeaders = 
                "content-type:" + contentType + "\n"
                +"host:" + host + "\n"
                +"x-tc-action:" + action.ToLower() + "\n";
            //参与签名的头部信息，说明此次请求有哪些头部参与了签名，
            //和 CanonicalHeaders 包含的头部内容是一一对应的。
            string signedHeaders = "content-type;host;x-tc-action";
            //即对 HTTP 请求正文做 SHA256 哈希，然后十六进制编码，最后编码串转换成小写字母。
            string hashedRequestPayload = SHA256Hex(requestPayload);
            string canonicalRequest = 
                httpRequestMethod + "\n"
                + canonicalURI + "\n"
                + canonicalQueryString + "\n"
                + canonicalHeaders + "\n"
                + signedHeaders + "\n"
                + hashedRequestPayload;

            //2. 拼接待签名字符串
            string algorithm = "TC3-HMAC-SHA256"; //签名算法，目前固定为 TC3-HMAC-SHA256。
            DateTime nowTime = DateTime.UtcNow;
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            //请求时间戳，即请求头部的公共参数 X-TC-Timestamp 取值，取当前时间 UNIX 时间戳，精确到秒。
            string timestamp = ((long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero) / 1000).ToString();
            string date = nowTime.ToString("yyyy-MM-dd");
            //凭证范围，格式为 Date/service/tc3_request，包含日期、所请求的服务和终止字符串（tc3_request）
            string credentialScope = date + "/" + service + "/" + "tc3_request";
            string hashedCanonicalRequest = SHA256Hex(canonicalRequest); //前述步骤拼接所得规范请求串的哈希值，
            string stringToSign = 
                algorithm + "\n"
                + timestamp + "\n"
                + credentialScope + "\n"
                + hashedCanonicalRequest;

            //3. 计算签名
            byte[] tc3SecretKey = Encoding.UTF8.GetBytes("TC3" + secretKey);
            byte[] secretDate = HmacSHA256(tc3SecretKey, Encoding.UTF8.GetBytes(date));
            byte[] secretService = HmacSHA256(secretDate, Encoding.UTF8.GetBytes(service));
            byte[] secretSigning = HmacSHA256(secretService, Encoding.UTF8.GetBytes("tc3_request"));
            byte[] signatureBytes = HmacSHA256(secretSigning, Encoding.UTF8.GetBytes(stringToSign));
            string signature = BitConverter.ToString(signatureBytes).Replace("-", "").ToLower();

            //4. 拼接 Authorization
            string authorization = 
                algorithm + " "
                + "Credential=" + secretId + "/" + credentialScope + ", "
                + "SignedHeaders=" + signedHeaders + ", "
                + "Signature=" + signature;

            //5. 构建必须携带的请求头
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", authorization },
                { "Content-Type", contentType },
                { "Host", host },
                { "X-TC-Action", action },
                { "X-TC-Region", region },
                { "X-TC-Timestamp", timestamp },
                { "X-TC-Version", version }
            };

            return headers;
        }

        private static string SHA256Hex(string s)
        {
            using (SHA256 algo = SHA256.Create())
            {
                byte[] hashbytes = algo.ComputeHash(Encoding.UTF8.GetBytes(s));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashbytes.Length; ++i)
                {
                    builder.Append(hashbytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private static byte[] HmacSHA256(byte[] key, byte[] msg)
        {
            using (HMACSHA256 mac = new HMACSHA256(key))
            {
                return mac.ComputeHash(msg);
            }
        }
    }
}
