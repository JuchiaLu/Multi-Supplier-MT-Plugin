using MemoQ.Addins.Common.Utils;
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

namespace MultiSupplierMTPlugin.Providers.Huoshan
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://translate.volcengineapi.com";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Huoshan;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = false;

        public override bool IsBatchSupported { get; set; } = true;

        public override int MaxSegments { get; set; } = 10;

        public override int MaxCharacters { get; set; } = 3000;

        public override int MaxQueriesPerWindow { get; set; } = 9;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 10;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://console.volcengine.com/iam/keymanage/";

        public override string ApiDocLink { get; set; } = "https://www.volcengine.com/docs/4640/65067";

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
                SourceLanguage = SupportLang.Dic[srcLangCode],
                TargetLanguage = SupportLang.Dic[trgLangCode],
                TextList = texts,
            };
            var jsonRequestBody = JsonConvert.SerializeObject(transRequest);
            byte[] jsonRequestBytes = Encoding.UTF8.GetBytes(jsonRequestBody);

            HttpMethod method = HttpMethod.Post;
            
            string _host = "translate.volcengineapi.com";
            string _path = "/";
            string query = Signer.GetQueryString(new List<KeyValuePair<string, string>>() 
            { 
                new KeyValuePair<string, string>("Action", "TranslateText"),
                new KeyValuePair<string, string>("Version", "2020-06-01")
            });

            string contentType = "application/json"; //或 application/x-www-form-urlencoded
            string xContentSha256 = Signer.ToHexString(Signer.HashSha256(jsonRequestBytes ?? Array.Empty<byte>()));

            string _region = "cn-north-1";
            string _service = "translate";

            string xDate = DateTimeOffset.Now.UtcDateTime.ToString("yyyyMMdd'T'HHmmss'Z'");
            string shortXDate = xDate.Substring(0, 8);

            string credentialScope = $"{shortXDate}/{_region}/{_service}/request";
            string signHeader = "host;x-date;x-content-sha256;content-type";

            string signature = Signer.GetSign
                (
                _region,
                _service,

                method.ToString(),
                _host,
                _path,
                query,

                contentType,
                xContentSha256,

                xDate,
                shortXDate,

                signHeader,
                credentialScope,

                s.SecretKey
                );

            var transResponse = await _httpClient.Post($"https://{_host}{_path}") //?{query}
                .AddHeader("Host", _host)
                .AddHeader("X-Date", xDate)
                .AddHeader("X-Content-Sha256", xContentSha256)
                .AddHeader("Authorization", $"HMAC-SHA256 Credential={s.AccessKey}/{credentialScope}, SignedHeaders={signHeader}, Signature={signature}")
                .AddQuery("Action", "TranslateText")
                .AddQuery("Version", "2020-06-01")
                .SetBodyJsonByteArray(jsonRequestBytes)
                .ReceiveJson<TransResponse>(cToken);


            if (transResponse.ResponseMetadata.Error != null)
            {
                throw new Exception(transResponse.ResponseMetadata.Error.Message);
            }

            return transResponse.TranslationList.Select(item => item.Translation).ToList();
        }


        private class Signer
        {
            public static string GetSign(
                string _region,
                string _service,

                string method,
                string _host,
                string _path, 
                string query,

                string contentType,
                string xContentSha256,

                string xDate,
                string shortXDate,

                string signHeader,
                string credentialScope,

                string _sk)
            {
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

                string hashCanonicalString = ToHexString(HashSha256(Encoding.UTF8.GetBytes(canonicalStringBuilder)));
                string signString = $"HMAC-SHA256\n{xDate}\n{credentialScope}\n{hashCanonicalString}";
                
                byte[] signKey = GenSigningSecretKeyV4(_sk, shortXDate, _region, _service);

                string signature = ToHexString(HmacSha256(signKey, signString));


                return signature;
            }

            public static string GetQueryString(List<KeyValuePair<string, string>> queryList)
            {
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

                return queryBuilder.ToString();
            }

            private static byte[] GenSigningSecretKeyV4(string secretKey, string date, string region, string service)
            {
                byte[] kDate = HmacSha256(Encoding.UTF8.GetBytes(secretKey), date);
                byte[] kRegion = HmacSha256(kDate, region);
                byte[] kService = HmacSha256(kRegion, service);
                return HmacSha256(kService, "request");
            }

            public static byte[] HmacSha256(byte[] secret, string text)
            {
                using (HMACSHA256 mac = new HMACSHA256(secret))
                {
                    var hash = mac.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return hash;
                }
            }

            public static byte[] HashSha256(byte[] data)
            {
                using (SHA256 sha = SHA256.Create())
                {
                    var hash = sha.ComputeHash(data);
                    return hash;
                }
            }

            public static string ToHexString(byte[] bytes)
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
    }
}
