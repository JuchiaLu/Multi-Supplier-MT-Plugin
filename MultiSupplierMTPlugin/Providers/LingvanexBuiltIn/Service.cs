using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.LingvanexBuiltIn
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://api-b2b.backenster.com/b1/api/v3/translate";

        static Service()
        {
            // Set up request headers
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Host", "api-b2b.backenster.com");
            _httpClient.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"125\", \"Chromium\";v=\"125\", \"Not.A/Brand\";v=\"24\"");
            _httpClient.DefaultRequestHeaders.Add("accept", "application/json, text/javascript, */*; q=0.01");
            //httpClient.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            _httpClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            _httpClient.DefaultRequestHeaders.Add("authorization", "Bearer a_25rccaCYcBC9ARqMODx2BV2M0wNZgDCEl3jryYSgYZtF1a702PVi4sxqi2AmZWyCcw4x209VXnCYwesx");
            _httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            _httpClient.DefaultRequestHeaders.Add("origin", "https://lingvanex.com");
            _httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "cross-site");
            _httpClient.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            _httpClient.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            _httpClient.DefaultRequestHeaders.Add("referer", "https://lingvanex.com/");
            _httpClient.DefaultRequestHeaders.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("priority", "u=1, i");
        }

        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Lingvanex_BuiltIn;

        public override bool IsAvailable { get { return true; } set { } }

        public override bool IsBuiltIn { get; set; } = true;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = true;

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

        public override string ApiKeyLink { get; set; } = "";

        public override string ApiDocLink { get; set; } = "";

        public override Dictionary<string, string> SupportLangDic { get; set; } = SupportLang.Dic;

        public override ProviderOptions ShowConfig()
        {
            return new Options(_generalSettings, _secureSettings);
        }

        public override async Task<List<string>> TranslateAsync(List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken, ProviderOptions tempOptions)
        {
            string[] result = new string[texts.Count];

            var bodyForm = new Dictionary<string, string>
            {
                { "from", SupportLang.Dic[srcLangCode] },
                { "to", SupportLang.Dic[trgLangCode] },
                { "text", texts[0] },
                { "platform", "dp" }
            };

            var jsonResponse = await _httpClient.Post(_baseUrl)
                .SetBodyForm(bodyForm)
                .ReceiveString(cToken);

            var transResponse = JObject.Parse(jsonResponse);

            if (transResponse.ContainsKey("result"))
            {
                result[0] = transResponse["result"].ToString();
            }
            else
            {
                throw new Exception($"Unexpected response format: {jsonResponse}");
            }

            return result.ToList();
        }
    }
}
