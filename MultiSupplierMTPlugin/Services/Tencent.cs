using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class Tencent : MultiSupplierMTService
    {
        private class TransRequest
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

        private class TransResponse
        {
            [JsonProperty("Response")]
            public Response Response { get; set; }

            [JsonProperty("RequestId")]
            public string RequestId { get; set; }
        }

        private class Response
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

        private class Error 
        {
            [JsonProperty("Code")]
            public string Code { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

        }

        private static readonly string baseUrl = "https://tmt.tencentcloudapi.com";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "zh-TW"},
            {"eng", "en"},
            {"jpn", "jp"},
            {"kor", "ko"},
            {"fre", "fr"},
            {"spa", "es"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"tur", "tr"},
            {"por-PT", "pt"}, //?
            {"por", "pot"}, //?
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
            using (var form = new Forms.FormTencent(options, environment))
            {
                form.ShowDialog(parentForm);
            }

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.TencentGeneralOptions.Checked;
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return supportLanguages.ContainsKey(srcLangCode) && supportLanguages.ContainsKey(trgLangCode);
        }

        public override bool IsBatchSupported()
        {
            return true;
        }

        public override bool IsXmlSupported()
        {
            return false;
        }

        public override bool IsHtmlSupported()
        {
            return false;
        }

        public override bool IsBuiltIn()
        {
            return false;
        }

        public override int MaxBatchSize()
        {
            return 10;
        }

        public override int MaxQueriesPerWindow()
        {
            return 4;
        }

        public override int WindowSizeMs()
        {
            return 1000;
        }

        public override double Smoothness()
        {
            return 1.0;
        }

        public override int MaxThreadHold()
        {
            return 5;
        }

        public override int FailedTimeoutMs()
        {
            return 0;
        }

        public override int RetryWaitingMs()
        {
            return 0;
        }

        public override int NumberOfRetries()
        {
            return 0;
        }

        public override string UniqueName()
        {
            return "Tencent";
        }
        
        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken) 
        {
            var secretId = options.SecureSettings.TencentSecureOptions.SecretId;
            var secretKey = options.SecureSettings.TencentSecureOptions.SecretKey;

            var transRequest = new TransRequest() 
            {
                Source = supportLanguages[srcLangCode],
                Target=supportLanguages[trgLangCode],
                ProjectId = 0,
                SourceTextList = texts
            };
            var jsonRequest = JsonConvert.SerializeObject(transRequest);

            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            var headers = BuildHeaders(secretId, secretKey, jsonRequest);
            foreach (var header in headers)
            {
                if (header.Key.Equals("Content-Type"))
                {
                   request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                }
                else if (header.Key.Equals("Host"))
                {
                    request.Headers.Host = header.Value;
                }
                else if (header.Key.Equals("Authorization"))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("TC3-HMAC-SHA256", header.Value.Substring("TC3-HMAC-SHA256".Length));
                }
                else
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await httpClient.SendAsync(request, cToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.Response.Error != null) 
            {
                throw new Exception(transResponse.Response.Error.Message);
            }

            return transResponse.Response.TargetTextList;
        }


        public static async Task<bool> Check(string appId, string appKey)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.TencentSecureOptions.SecretId = appId;
            tempOptions.SecureSettings.TencentSecureOptions.SecretKey = appKey;

            var service = new Tencent();
            try
            {
                await service.TranslateAsync(tempOptions, new List<string>() { "test" }, "eng", "zho-CN", null, null, null, new CancellationToken());
                return true;
            }
            catch
            {
                return false;
            }
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
