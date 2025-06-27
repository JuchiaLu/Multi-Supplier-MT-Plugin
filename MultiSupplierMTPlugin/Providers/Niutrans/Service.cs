using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Niutrans
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://api.niutrans.com/NiuTransServer";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Niutrans;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = false;

        public override bool IsBatchSupported { get; set; } = false;

        public override int MaxSegments { get; set; } = 1;

        public override int MaxCharacters { get; set; } = 0;

        public override int MaxQueriesPerWindow { get; set; } = 4;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 5;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://niutrans.com/cloud/account_info/info";

        public override string ApiDocLink { get; set; } = "https://niutrans.com/documents/contents/transapi_batch_v2";

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
                From = SupportLang.Dic[srcLangCode],
                To = SupportLang.Dic[trgLangCode],
                Apikey = s.Apikey,
                SrcText = texts[0]
            };

            string formatType = (_mtGeneralSettings.RequestType == RequestType.Plaintext) ? "/translation" : "/translationXML";
            string url = _baseUrl + formatType;

            var transResponse = await _httpClient.Post(url)
                .SetBodyJson(transRequest)
                .ReceiveJson<TransResponse>(cToken);

            if (transResponse.ErrorCode != null)
            {
                throw new Exception(transResponse.ErrorMsg);
            }

            string[] result = new string[texts.Count];

            result[0] = transResponse.TgtText;

            return result.ToList();
        }
    }
}
