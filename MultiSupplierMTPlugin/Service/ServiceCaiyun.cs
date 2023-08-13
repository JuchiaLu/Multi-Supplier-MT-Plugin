using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceCaiyun : MultiSupplierMTServiceInterface
    {
        private class TransRequest
        {
            [JsonProperty("source")]
            public List<string> Source { get; set; }

            [JsonProperty("trans_type")]
            public string TransType { get; set; }

            [JsonProperty("request_id")]
            public string RequestId { get; set; }

            [JsonProperty("detect")]
            public bool Detect { get; set; }
        }

        private class TransResponse
        {
            [JsonProperty("target")]
            public List<string> Target { get; set; }

            [JsonProperty("rc")]
            public int Rc { get; set; }

            [JsonProperty("confidence")]
            public float Confidence { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        private static readonly string baseUrl = "https://api.interpreter.caiyunai.com/v1/translator";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "zh"},
            {"eng", "en"},
            {"jpn", "ja"},
        };

        private static readonly HttpClient httpClient = new HttpClient();


        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            new OptionsFormCaiyun(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.CaiyunGeneralOptions.Checked;
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return supportLanguages.ContainsKey(srcLangCode) && supportLanguages.ContainsKey(trgLangCode);
        }

        public override int MaxBatchSize()
        {
            return 10;
        }

        public override int MaxQueriesPerSecond()
        {
            return 8;
        }

        public override int MaxThreadHold()
        {
            return 10;
        }

        public override string UniqueName()
        {
            return "Caiyun";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string token = options.SecureSettings.CaiyunSecureOptions.Token;

            TransRequest transRequest = new TransRequest()
            {
                Source = texts,
                TransType = $"{supportLanguages[srcLangCode]}2{supportLanguages[trgLangCode]}",
                RequestId = "demo",
                Detect = true
            };

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            requestMessage.Headers.Add("x-authorization", "token " + token);

            string jsonRequest = JsonConvert.SerializeObject(transRequest);
            requestMessage.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.Message != null)
            {
                throw new Exception(transResponse.Message);
            }

            return transResponse.Target;
        }


        public static async Task<bool> Check(string token)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.CaiyunSecureOptions.Token = token;

            var service = new ServiceCaiyun();
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
