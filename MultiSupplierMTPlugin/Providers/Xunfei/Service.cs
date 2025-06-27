using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Xunfei
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://ntrans.xfyun.cn/v2/ots";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Xunfei;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = false;

        public override bool IsBatchSupported { get; set; } = false;

        public override int MaxSegments { get; set; } = 1;

        public override int MaxCharacters { get; set; } = 0;

        public override int MaxQueriesPerWindow { get; set; } = 5;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 5;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://console.xfyun.cn/app/myapp";

        public override string ApiDocLink { get; set; } = "https://www.xfyun.cn/doc/nlp/xftrans/API.html";

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

            var formatType = (_mtGeneralSettings.RequestType == RequestType.Plaintext) ? null : "xml";

            TransRequest transRequest = new TransRequest()
            {
                Common = new Common()
                {
                    AppId = s.AppId
                },

                Business = new Business()
                {
                    From = SupportLang.Dic[srcLangCode],
                    To = SupportLang.Dic[trgLangCode],
                    Infmt = formatType
                },

                Data = new RequestData()
                {
                    Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(texts[0]))
                }
            };



            string jsonRequest = JsonConvert.SerializeObject(transRequest);

            Uri url = new Uri(_baseUrl);
            string date = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", System.Globalization.CultureInfo.InvariantCulture);
            string digestBase64 = "SHA-256=" + SignBody(jsonRequest);

            var builder = new StringBuilder($"host: {url.Host}\n");
            builder.Append($"date: {date}\n");
            builder.Append($"POST {url.AbsolutePath} HTTP/1.1\n");
            builder.Append($"digest: {digestBase64}");

            string sha = HmacSign(builder.ToString(), s.ApiSecret);
            string authorization = $"api_key=\"{s.ApiKey}\", algorithm=\"hmac-sha256\", headers=\"host date request-line digest\", signature=\"{sha}\"";

            var transResponse = await _httpClient.Post(url.AbsoluteUri)
                .AddHeader("Authorization", authorization)
                .AddHeader("Accept", "application/json,version=1.0")
                .AddHeader("Host", url.Host)
                .AddHeader("Date", date)
                .AddHeader("Digest", digestBase64)
                .SetBodyJson(transRequest)
                .ReceiveJson<TransResponse>(cToken);

            if (transResponse.Code != 0)
            {
                throw new Exception(transResponse.Message);
            }

            string[] result = new string[texts.Count];
            result[0] = transResponse.Data.Result.TransResult.Dst;

            return result.ToList();
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
