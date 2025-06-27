using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Papago
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://naveropenapi.apigw.ntruss.com/nmt/v1/translation";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Papago;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

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

        public override string ApiKeyLink { get; set; } = "https://nid.naver.com/nidlogin.login?mode=form&url=https%3A%2F%2Fdevelopers.naver.com%2Fmain%2F";

        public override string ApiDocLink { get; set; } = "https://guide.ncloud-docs.com/docs/en/papagotranslation-api";

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
                Text = texts[0],
            };

            var transResponse = await _httpClient.Post(_baseUrl)
                .AddHeader("X-NCP-APIGW-API-KEY-ID", s.ClientID)
                .AddHeader("X-NCP-APIGW-API-KEY", s.ClientSecret)
                .SetBodyJson(transRequest)
                .ReceiveJson<TransResponse>(cToken);

            string[] result = new string[texts.Count];
            result[0] = transResponse.Message.Result.TranslatedText;

            return result.ToList();
        }
    }
}
