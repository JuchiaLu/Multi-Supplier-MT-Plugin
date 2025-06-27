using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Youdao
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://openapi.youdao.com/v2/api";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Youdao;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = false;

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

        public override string ApiKeyLink { get; set; } = "https://ai.youdao.com/console/#/app-overview/check-application";

        public override string ApiDocLink { get; set; } = "https://fanyi.youdao.com/openapi/";

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

            List<KeyValuePair<string, string>> formParameters = new List<KeyValuePair<string, string>>(); 

            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long millis = (long)ts.TotalMilliseconds;
            string curtime = Convert.ToString(millis / 1000);
            string salt = Guid.NewGuid().ToString();
            string signStr = s.AppKey + Truncate(string.Join("", texts)) + salt + curtime + s.AppSecret; ;
            string sign = GetSign(signStr);

            formParameters.Add(new KeyValuePair<string, string>("from", SupportLang.Dic[srcLangCode]));
            formParameters.Add(new KeyValuePair<string, string>("to", SupportLang.Dic[trgLangCode]));
            formParameters.Add(new KeyValuePair<string, string>("signType", "v3"));
            formParameters.Add(new KeyValuePair<string, string>("appKey", s.AppKey));
            formParameters.Add(new KeyValuePair<string, string>("curtime", curtime));
            formParameters.Add(new KeyValuePair<string, string>("salt", salt));
            formParameters.Add(new KeyValuePair<string, string>("sign", sign));

            foreach (var item in texts)
            {
                formParameters.Add(new KeyValuePair<string, string>("q", item));
            }

            var transResponse = await _httpClient.Post(_baseUrl)
                .SetBodyForm(formParameters)
                .ReceiveJson<TransResponse>(cToken);

            if (!("0".Equals(transResponse.ErrorCode)))
            {
                throw new Exception("Error Code: " + transResponse.ErrorCode);
            }

            string[] result = new string[texts.Count];
            int j = 0;
            foreach (TransResult t in transResponse.TranslateResults)
            {
                result[j] = t.Translation;
                j++;
            }

            return result.ToList();
        }


        private static string Truncate(string q)
        {
            int len = q.Length;
            return len <= 20 ? q : (q.Substring(0, 10) + len + q.Substring(len - 10, 10));
        }

        private static string GetSign(string input)
        {
            HashAlgorithm algorithm = new SHA256CryptoServiceProvider();
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}
