using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.MicrosoftBuiltIn
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _tokenUrl = "https://edge.microsoft.com/translate/auth";

        private const string _baseUrl = "https://api-edge.cognitive.microsofttranslator.com/translate";

        static Service()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            _httpClient.DefaultRequestHeaders.Add("accept-language", "zh-TW,zh;q=0.9,ja;q=0.8,zh-CN;q=0.7,en-US;q=0.6,en;q=0.5");
            _httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");
            _httpClient.DefaultRequestHeaders.Add("pragma", "no-cache");
            _httpClient.DefaultRequestHeaders.Add("sec-ch-ua", "\"Microsoft Edge\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
            _httpClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            _httpClient.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            _httpClient.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            _httpClient.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            _httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "cross-site");
            _httpClient.DefaultRequestHeaders.Add("Referer", "https://appsumo.com/");
            _httpClient.DefaultRequestHeaders.Add("Referrer-Policy", "strict-origin-when-cross-origin");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36 Edg/113.0.1774.42");
        }

        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Microsoft_BuiltIn;

        public override bool IsAvailable { get { return true; } set { } }

        public override bool IsBuiltIn { get; set; } = true;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = false;

        public override bool IsBatchSupported { get; set; } = true;

        public override int MaxSegments { get; set; } = 10;

        public override int MaxCharacters { get; set; } = 3000;

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
            var token = await _httpClient.Get(_tokenUrl)
                .ReceiveString(cToken);

            List <TranslationRequestItem> translationRequestItems = new List<TranslationRequestItem>();
            foreach (string text in texts)
            {
                translationRequestItems.Add(new TranslationRequestItem { Text = text });
            }

            var translationResponseItems = await _httpClient.Post(_baseUrl)
                .AddHeader("Authorization", "Bearer " + token)
                .AddQuery("from", SupportLang.Dic[srcLangCode])
                .AddQuery("to", SupportLang.Dic[trgLangCode])
                .AddQuery("apiVersion", "3.0")
                .AddQuery("includeSentenceLength", "true")
                .SetBodyJson(translationRequestItems)
                .ReceiveJson<List<TranslationResponseItem>>(cToken);

            List<string> result = new List<string>();
            foreach (TranslationResponseItem translationItem in translationResponseItems)
            {
                foreach (Translation translation in translationItem.Translations)
                {
                    result.Add(translation.Text);
                }
            }

            return result;
        }
    }
}
