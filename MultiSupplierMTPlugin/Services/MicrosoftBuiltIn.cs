using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class MicrosoftBuiltIn : MultiSupplierMTService
    {
        private class TranslationRequestItem
        {
            public string Text { get; set; }
        }

        private class TranslationResponseItem
        {
            public List<Translation> Translations { get; set; }
        }

        private class Translation
        {
            public string Text { get; set; }
            public string To { get; set; }
            public SentenceLength SentLen { get; set; }
        }

        private class SentenceLength
        {
            public List<int> SrcSentLen { get; set; }
            public List<int> TransSentLen { get; set; }
        }


        private static readonly string tokenUrl = "https://edge.microsoft.com/translate/auth";

        private static readonly string baseUrl = "https://api-edge.cognitive.microsofttranslator.com/translate";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh-Hans"},
            {"zho-TW", "zh-Hant"},
            {"eng", "en"},
            {"jpn", "ja"},
            {"kor", "ko"},
            {"fre", "fr"},
            {"spa", "es"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"tur", "tr"},
            {"por-PT", "pt-pt"},
            {"por", "pt"},
            {"vie", "vi"},
            {"ind", "id"},
            {"tha", "th"},
            {"msa", "ms"},
            {"ara", "ar"},
            {"hin", "hi"},
        };

        private static readonly HttpClient httpClient = new HttpClient();

        static MicrosoftBuiltIn()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Add("accept-language", "zh-TW,zh;q=0.9,ja;q=0.8,zh-CN;q=0.7,en-US;q=0.6,en;q=0.5");
            httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");
            httpClient.DefaultRequestHeaders.Add("pragma", "no-cache");
            httpClient.DefaultRequestHeaders.Add("sec-ch-ua", "\"Microsoft Edge\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
            httpClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            httpClient.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            httpClient.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            httpClient.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "cross-site");
            httpClient.DefaultRequestHeaders.Add("Referer", "https://appsumo.com/");
            httpClient.DefaultRequestHeaders.Add("Referrer-Policy", "strict-origin-when-cross-origin");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36 Edg/113.0.1774.42");
        }

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
            return true;
        }

        public override bool IsXmlSupported()
        {
            return false;
        }

        public override bool IsHtmlSupported()
        {
            return false;
        }

        public override bool IsBuiltIn()
        {
            return true;
        }

        public override int MaxBatchSize()
        {
            return 10;
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
            return "MicrosoftBuiltIn";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            HttpResponseMessage tokenResponse = await httpClient.GetAsync(tokenUrl);
            tokenResponse.EnsureSuccessStatusCode();
            string token = await tokenResponse.Content.ReadAsStringAsync();

            string url = baseUrl + $"?from={supportLanguages[srcLangCode]}&to={supportLanguages[trgLangCode]}&apiVersion=3.0&includeSentenceLength=true";
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.Add("Authorization", "Bearer " + token);

            List<TranslationRequestItem> translationRequestItems = new List<TranslationRequestItem>();
            foreach (string text in texts)
            {
                translationRequestItems.Add(new TranslationRequestItem { Text = text });
            }
            string jsonRequest = JsonConvert.SerializeObject(translationRequestItems);
            requestMessage.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage, cToken);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<TranslationResponseItem> translationResponseItems = JsonConvert.DeserializeObject<List<TranslationResponseItem>>(jsonResponse);

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
