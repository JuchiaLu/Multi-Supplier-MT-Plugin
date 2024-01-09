using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.Services;

namespace MultiSupplierMTPlugin.Service
{
    public class ServiceBaidu : MTServiceInterface
    {
        private class TransResponse
        {
            [JsonProperty("from")]
            public string From { get; set; }

            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("trans_result")]
            public List<TransResult> TransResult { get; set; }

            [JsonProperty("error_code")]
            public int ErrorCode { get; set; }

            [JsonProperty("error_msg")]
            public string ErrorMsg { get; set; }
        }


        private class TransResult
        {
            [JsonProperty("src")]
            public string Src { get; set; }

            [JsonProperty("dst")]
            public string Dst { get; set; }
        }


        private static readonly string baseUrl = "http://api.fanyi.baidu.com/api/trans/vip/translate";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "zh"},
            {"zho-TW", "cht"},
            {"eng", "en"},
            {"jpn", "jp"},
            {"kor", "kor"},
            {"fre", "fra"},
            {"spa", "spa"},
            {"rus", "ru"},
            {"ger", "de"},
            {"ita", "it"},
            {"tur", "tr"},
            {"por-PT", "pt"},
            {"por", "pot"},
            {"vie", "vie"},
            {"ind", "id"},
            {"tha", "th"},
            {"msa", "may"},
            {"ara", "ar"},
            {"hin", "hi"},
        };

        private static readonly HttpClient httpClient = new HttpClient();


        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            new OptionsFormBaidu(options, environment).ShowDialog(parentForm);

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.BaiduGeneralOptions.Checked;
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
            return 1;
        }

        public override int MaxThreadHold()
        {
            return 1;
        }

        public override string UniqueName()
        {
            return "Baidu";
        }

        public override async Task<List<string>> BatchTranslate(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData)
        {
            string appId = options.SecureSettings.BaiduSecureOptions.AppId;
            string appKey = options.SecureSettings.BaiduSecureOptions.AppKey;

            string[] result = new string[texts.Count];

            string salt = Guid.NewGuid().ToString();
            string sign = getSign(appId, appKey, salt, texts[0]);
            string url = $"{baseUrl}?q={HttpUtility.UrlEncode(texts[0])}&from={supportLanguages[srcLangCode]}&to={supportLanguages[trgLangCode]}&appid={appId}&salt={salt}&sign={sign}";

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            TransResponse transResponse = JsonConvert.DeserializeObject<TransResponse>(jsonResponse);

            if (transResponse.ErrorCode != 0)
            {
                throw new Exception(transResponse.ErrorMsg);
            }

            string seg = "";
            foreach (TransResult t in transResponse.TransResult)
            {
                seg += t.Dst; //+ Environment.NewLine
            }

            result[0] = seg;

            return result.ToList();
        }


        public static async Task<bool> Check(string appId, string appKey)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.SecureSettings.BaiduSecureOptions.AppId = appId;
            tempOptions.SecureSettings.BaiduSecureOptions.AppKey = appKey;

            var service = new ServiceBaidu();
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

        private string getSign(string appId, string appKey, string salt, string text)
        {
            string str = appId + text + salt + appKey;

            MD5 md5 = MD5.Create();
            
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            byte[] byteNew = md5.ComputeHash(byteOld);
           
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }
            
            return sb.ToString();
        }
    }
}
