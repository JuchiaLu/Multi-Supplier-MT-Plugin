using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.DeepL
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.DeepL;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = true;

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

        public override string ApiKeyLink { get; set; } = "https://www.deepl.com/your-account";

        public override string ApiDocLink { get; set; } = "https://developers.deepl.com/docs/api-reference/translate/openapi-spec-for-text-translation";

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

            TransRequest transRequest = new TransRequest()
            {
                Text = texts.ToArray(),
                SourceLang = SupportLang.Dic[srcLangCode],
                TargetLang = SupportLang.Dic[trgLangCode],
                PreserveFormatting = true
            };

            var requestType = _mtGeneralSettings.RequestType;
            if (requestType == RequestType.OnlyFormattingWithXml || requestType == RequestType.BothFormattingAndTagsWithXml)
            {
                transRequest.TagHandling = "xml";
            }
            else if (requestType == RequestType.OnlyFormattingWithHtml || requestType == RequestType.BothFormattingAndTagsWithHtml)
            {
                transRequest.TagHandling = "html";
            }

            if (!string.IsNullOrEmpty(g.GlossaryId))
            {
                transRequest.GlossaryId = g.GlossaryId;
            }

            var transResponse = await _httpClient.Post(g.Server)
                .AddHeader("Authorization", "DeepL-Auth-Key " + s.AuthKey)
                .SetBodyJson(transRequest)
                .ReceiveJson<TransResponse>(cToken);

            return transResponse.Translations.Select(t => t.Text).ToList();
        }
    }
}
