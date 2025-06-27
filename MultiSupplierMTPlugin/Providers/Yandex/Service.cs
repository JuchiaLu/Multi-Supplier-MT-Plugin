using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Yandex
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://translate.api.cloud.yandex.net/translate/v2/translate";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Yandex;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = true;

        public override bool IsBatchSupported { get; set; } = true;

        public override int MaxSegments { get; set; } = 10;

        public override int MaxCharacters { get; set; } = 0;

        public override int MaxQueriesPerWindow { get; set; } = 18;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 20;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://console.yandex.cloud/";

        public override string ApiDocLink { get; set; } = "https://yandex.cloud/en/docs/translate/api-ref/Translation/translate";

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
                Texts = texts.ToArray(),
                SourceLanguageCode = SupportLang.Dic[srcLangCode],
                TargetLanguageCode = SupportLang.Dic[trgLangCode],
                Speller = g.Speller,
            };

            var rType = _mtGeneralSettings.RequestType;
            transRequest.Format = (rType == RequestType.OnlyFormattingWithHtml) || (rType == RequestType.BothFormattingAndTagsWithHtml)
                ? Format.HTML 
                : Format.FORMAT_UNSPECIFIED;

            if (!string.IsNullOrEmpty(g.FolderId))
                transRequest.FolderId = g.FolderId;

            if (!string.IsNullOrEmpty(g.Model))
                transRequest.Model = g.Model;

            if (!string.IsNullOrEmpty(g.GlossaryFilePath))
            {
                var glossaryPairs = GlossaryHelper.ReadGlossaryPairs(g.GlossaryFilePath, srcLangCode, trgLangCode, g.GlossaryDelimiter);
                
                transRequest.GlossaryConfig = new GlossaryConfig()
                {
                    GlossaryData = new GlossaryData()
                    {
                        GlossaryPairs = glossaryPairs.Select(pair => new GlossaryPairs() 
                        {
                            SourceText = pair.Key,
                            TranslatedText = pair.Value,
                            Exact = g.GlossaryExact
                        }).ToArray(),
                    }
                };
            }

            var transResponse = await _httpClient.Post(_baseUrl)                
                .AddHeaderIf(g.AuthorizationType == AuthorizationType.ApiKey, "Authorization", "Api-Key " + s.KeyOrToken)
                .AddHeaderIf(g.AuthorizationType == AuthorizationType.IamToken, "Authorization", "Bearer " + s.KeyOrToken)
                .SetBodyJson(transRequest)
                .ReceiveJson<TransResponse>(cToken);           

            return transResponse.Translations.Select(t => t.Text).ToList();
        }
    }
}