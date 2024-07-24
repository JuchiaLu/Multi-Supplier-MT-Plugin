using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class YandexBuiltIn : MultiSupplierMTService
    {
        private static readonly string baseUrl = "https://translate.yandex.net/api/v1/tr.json/translate";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "zh"},
            {"eng", "en"},
            {"jpn", "ja"},
            {"kor", "ko"},
            {"fre", "fr"},
            {"spa", "es"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"tur", "tr"},
            {"por-PT", "pt"},
            {"por", "pt"},
            {"vie", "vi"},
            {"ind", "id"},
            {"tha", "th"},
            {"msa", "ms"},
            {"ara", "ar"},
            {"hin", "hi"},
        };

        private static readonly HttpClient httpClient = new HttpClient();


        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return true;
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return supportLanguages.ContainsKey(srcLangCode) && supportLanguages.ContainsKey(trgLangCode);
        }

        public override bool IsBatchSupported()
        {
            return false;
        }

        public override bool IsXmlSupported()
        {
            return true;
        }

        public override bool IsHtmlSupported()
        {
            return true;
        }

        public override bool IsBuiltIn()
        {
            return true;
        }

        public override int MaxBatchSize()
        {
            return 1;
        }

        public override int MaxQueriesPerWindow()
        {
            return 5;
        }

        public override int WindowSizeMs()
        {
            return 1000;
        }

        public override double Smoothness()
        {
            return 1.0;
        }

        public override int MaxThreadHold()
        {
            return 5;
        }

        public override int FailedTimeoutMs()
        {
            return 0;
        }

        public override int RetryWaitingMs()
        {
            return 0;
        }

        public override int NumberOfRetries()
        {
            return 0;
        }

        public override string UniqueName()
        {
            return "YandexBuiltIn";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            string[] result = new string[texts.Count];

            var queryParams = new Dictionary<string, string>
            {
                { "id", Guid.NewGuid().ToString("N") + "-0-0" },
                { "srv", "android" }
            };
            var queryString = new FormUrlEncodedContent(queryParams).ReadAsStringAsync().Result;
            var fullUrl = $"{baseUrl}?{queryString}";

            var bodyForm = new Dictionary<string, string>
            {
                { "source_lang", supportLanguages[srcLangCode] },
                { "target_lang", supportLanguages[trgLangCode] },
                { "text", texts[0]},
            };
            var content = new FormUrlEncodedContent(bodyForm);

            var response = await httpClient.PostAsync(fullUrl, content, cToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);

            if (transResponse.ContainsKey("text") && transResponse["text"] is Newtonsoft.Json.Linq.JArray textArray && textArray.Count > 0)
            {
                result[0] = textArray[0].ToString();
            }
            else
            {
                throw new Exception($"Unexpected response format: {jsonResponse}");
            }

            return result.ToList();
        }
    }
}
