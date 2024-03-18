using MemoQ.Addins.Common.Utils;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Service
{
    public class ServicePapago : MTServiceInterface
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
            new OptionsFormPapago(options, environment).ShowDialog(parentForm);

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

        public override int MaxBatchSize()
        {
            return 1;
        }

        public override int MaxQueriesPerSecond()
        {
            return 5;
        }

        public override int MaxThreadHold()
        {
            return 10;
        }

        public override string UniqueName()
        {
            return "Papago";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
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

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
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

            var service = new ServicePapago();
            try
            {
                await service.BatchTranslate(tempOptions, new List<string>() { "test" }, "eng", "zho-CN", null, null, null);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
