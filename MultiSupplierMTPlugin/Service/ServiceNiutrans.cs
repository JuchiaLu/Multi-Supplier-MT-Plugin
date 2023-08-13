using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceNiutrans : MultiSupplierMTServiceInterface
    {
        private class TransRequest
        {
            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("apikey")]
            public string Apikey { get; set; }

            [JsonProperty("src_text")]
            public string SrcText { get; set; }

            [JsonProperty("dictNo")]
            public string DictNo { get; set; }

            [JsonProperty("memoryNo")]
            public string MemoryNo { get; set; }
        }

        private class TransResponse
        {
            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("apikey")]
            public string Apikey { get; set; }

            [JsonProperty("src_text")]
            public string SrcText { get; set; }

            [JsonProperty("tgt_text")]
            public string TgtText { get; set; }

            [JsonProperty("error_code")]
            public string ErrorCode { get; set; }

            [JsonProperty("error_msg")]
            public string ErrorMsg { get; set; }
        }


        private static readonly string baseUrl = "https://api.niutrans.com/NiuTransServer";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "cht"},
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
            new OptionsFormNiutrans(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.NiutransGeneralOptions.Checked;
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
            return 10;
        }

        public override int MaxThreadHold()
        {
            return 50;
        }

        public override string UniqueName()
        {
            return "Niutrans";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string[] result = new string[texts.Count];

            string apikey = options.SecureSettings.NiutransSecureOptions.Apikey;

            TransRequest transRequest = new TransRequest()
            {
                From = supportLanguages[srcLangCode],
                To = supportLanguages[trgLangCode],
                Apikey = apikey,
                SrcText = texts[0]
            };

            string formatType = (options.GeneralSettings.RequestType == RequestType.Plaintext) ? "/translation" : "/translationXML";
            string url = baseUrl + formatType;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            
            string jsonRequest = JsonConvert.SerializeObject(transRequest);
            requestMessage.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.ErrorCode != null)
            {
                throw new Exception(transResponse.ErrorMsg);
            }

            result[0] = transResponse.TgtText;

            return result.ToList();
        }


        public static async Task<bool> Check(string apikey)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.NiutransSecureOptions.Apikey = apikey;

            var service = new ServiceNiutrans();
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
