using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.YandexBuiltIn
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://translate.yandex.net/api/v1/tr.json/translate";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Yandex_BuiltIn;

        public override bool IsAvailable { get { return true; } set { } }

        public override bool IsBuiltIn { get; set; } = true;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

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

            var formBody = new Dictionary<string, string>
            {
                { "source_lang", SupportLang.Dic[srcLangCode] },
                { "target_lang", SupportLang.Dic[trgLangCode] },
                { "text", texts[0]},
            };

            var transResponse = await _httpClient.Post(_baseUrl)
                .AddQuery("id", Guid.NewGuid().ToString("N") + "-0-0")
                .AddQuery("srv", "android")
                .SetBodyForm(formBody)
                .ReceiveJson<Dictionary<string, object>>(cToken);

            if (transResponse.ContainsKey("text") && transResponse["text"] is Newtonsoft.Json.Linq.JArray textArray && textArray.Count > 0)
            {
                result[0] = textArray[0].ToString();
            }
            else
            {
                throw new Exception($"Unexpected response format");
            }

            return result.ToList();
        }
    }
}
