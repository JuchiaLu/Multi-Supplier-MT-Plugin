using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class Papago : MultiSupplierMTService
    {
        private class TransRequest
        {
            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("target")]
            public string Target { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }

        private class TransResponse
        {
            [JsonProperty("message")]
            public Message Message { get; set; }
        }

        private class Message
        {
            [JsonProperty("result")]
            public Result Result { get; set; }
        }

        private class Result
        {
            [JsonProperty("srcLangType")]
            public string SrcLangType { get; set; }

            [JsonProperty("tarLangType")]
            public string TarLangType { get; set; }

            [JsonProperty("translatedText")]
            public string TranslatedText { get; set; }
        }

        private static readonly string baseUrl = "https://naveropenapi.apigw.ntruss.com/nmt/v1/translation";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh-CN"},
            {"zho-TW", "zh-TW"},
            {"eng", "en"},
            {"jpn", "ja"},
            {"kor", "ko"},
            {"fre", "fr"},
            {"spa", "es"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"vie", "vi"},
            {"ind", "id"},
            {"tha", "th"},
        };

        private static readonly HttpClient httpClient = new HttpClient();


        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            using (var form = new Forms.FormPapago(options, environment))
            {
                form.ShowDialog(parentForm);
            }

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.PapagoGeneralOptions.Checked; ;
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
            return false;
        }

        public override bool IsHtmlSupported()
        {
            return false;
        }

        public override bool IsBuiltIn()
        {
            return false;
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
            return "Papago";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            string[] result = new string[texts.Count];

            string clientID = options.SecureSettings.PapagoSecureOptions.ClientID;
            string clientSecret = options.SecureSettings.PapagoSecureOptions.ClientSecret;

            var transRequest = new TransRequest()
            {
                Source = supportLanguages[srcLangCode],
                Target = supportLanguages[trgLangCode],
                Text = texts[0],
            };

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            requestMessage.Headers.TryAddWithoutValidation("X-NCP-APIGW-API-KEY-ID", clientID);
            requestMessage.Headers.TryAddWithoutValidation("X-NCP-APIGW-API-KEY", clientSecret);

            string jsonRequest = JsonConvert.SerializeObject(transRequest);
            requestMessage.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage, cToken);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            result[0] = transResponse.Message.Result.TranslatedText;

            return result.ToList();
        }


        public static async Task<bool> Check(string appId, string appKey)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.PapagoSecureOptions.ClientID = appId;
            tempOptions.SecureSettings.PapagoSecureOptions.ClientSecret = appKey;

            var service = new Papago();
            try
            {
                await service.TranslateAsync(tempOptions, new List<string>() { "test" }, "eng", "zho-CN", null, null, null, new CancellationToken());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
