using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.GoogleBuiltIn
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://translate.googleapis.com/translate_a/single";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Google_BuiltIn;

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
            
            var jsonResponse = await _httpClient.Get(_baseUrl)
                .AddQuery("client", "gtx")
                .AddQuery("dt", "t")
                .AddQuery("sl", SupportLang.Dic[srcLangCode])
                .AddQuery("tl", SupportLang.Dic[trgLangCode])
                .AddQuery("q", texts[0])
                .ReceiveString(cToken);

            JArray jsonArray = JArray.Parse(jsonResponse);

            string r = "";
            foreach (JToken jToken in jsonArray[0])
            {
                string t = jToken[0].Value<string>();
                r += t;
            }

            result[0] = r;

            return result.ToList();
        }
    }
}
