using MemoQ.MTInterfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class LingvanexBuiltIn : MultiSupplierMTService
    {
        private static readonly string baseUrl = "https://api-b2b.backenster.com/b1/api/v3/translate";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh-Hans_CN"},
            {"zho-TW", "zh-Hant_TW"},
            {"eng", "en_US"},
            {"jpn", "ja_JP"},
            {"kor", "ko_KR"},
            {"fre", "fr_CA"},
            {"spa", "es_ES"},
            {"rus", "ru_RU"},
            {"ger", "de_DE"},
            {"ita", "it_IT"},
            {"tur", "tr_TR"},
            {"por-PT", "pt_PT"},
            {"por", "pt_PT"},
            {"vie", "pt_PT"},
            {"ind", "pt_PT"},
            {"tha", "pt_PT"},
            {"msa", "ms_MY"},
            {"ara", "ar_SA"},
            {"hin", "hi_IN"},
        };

        private static readonly HttpClient httpClient = new HttpClient();

        static LingvanexBuiltIn()
        {
            // Set up request headers
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Host", "api-b2b.backenster.com");
            httpClient.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"125\", \"Chromium\";v=\"125\", \"Not.A/Brand\";v=\"24\"");
            httpClient.DefaultRequestHeaders.Add("accept", "application/json, text/javascript, */*; q=0.01");
            //httpClient.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded; charset=UTF-8");
            httpClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            httpClient.DefaultRequestHeaders.Add("authorization", "Bearer a_25rccaCYcBC9ARqMODx2BV2M0wNZgDCEl3jryYSgYZtF1a702PVi4sxqi2AmZWyCcw4x209VXnCYwesx");
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            httpClient.DefaultRequestHeaders.Add("origin", "https://lingvanex.com");
            httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "cross-site");
            httpClient.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            httpClient.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            httpClient.DefaultRequestHeaders.Add("referer", "https://lingvanex.com/");
            httpClient.DefaultRequestHeaders.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8");
            httpClient.DefaultRequestHeaders.Add("priority", "u=1, i");
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
            return "LingvanexBuiltIn";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            string[] result = new string[texts.Count];

            var bodyForm = new Dictionary<string, string>
            {
                { "from", supportLanguages[srcLangCode] },
                { "to", supportLanguages[trgLangCode] },
                { "text", texts[0] },
                { "platform", "dp" }
            };
            var content = new FormUrlEncodedContent(bodyForm);

            var response = await httpClient.PostAsync(baseUrl, content, cToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transResponse = JObject.Parse(jsonResponse);

            if (transResponse.ContainsKey("result"))
            {
                result[0] = transResponse["result"].ToString();
            }
            else
            {
                throw new Exception($"Unexpected response format: {jsonResponse}");
            }

            return result.ToList();
        }
    }
}
