using MemoQ.MTInterfaces;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceGoogleBuiltIn : MultiSupplierMTServiceInterface
    {
        private static readonly string baseUrl = "https://translate.googleapis.com/translate_a/single";

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
            return "Google Built In";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string[] result = new string[texts.Count];

            string url = baseUrl + $"?client=gtx&dt=t&sl={supportLanguages[srcLangCode]}&tl={supportLanguages[trgLangCode]}&q={System.Web.HttpUtility.UrlEncode(texts[0])}";

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JArray jsonArray = JArray.Parse(jsonResponse);
            
            string r = "";
            foreach (JToken jToken in jsonArray[0])
            {
                string t = jToken[0].Value<string>();
                r += t;
            }

            result[0] = r;

            return result.ToList();
        }
    }
}
