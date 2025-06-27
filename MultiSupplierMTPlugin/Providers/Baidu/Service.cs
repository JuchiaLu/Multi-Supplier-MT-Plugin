using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.Baidu
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "http://api.fanyi.baidu.com/api/trans/vip/translate";


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.Baidu;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = false;

        public override bool IsHtmlSupported { get; set; } = false;

        public override bool IsBatchSupported { get; set; } = false;

        public override int MaxSegments { get; set; } = 1;

        public override int MaxCharacters { get; set; } = 0;

        public override int MaxQueriesPerWindow { get; set; } = 9;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 10;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://fanyi-api.baidu.com/manage/developer";

        public override string ApiDocLink { get; set; } = "https://fanyi-api.baidu.com/product/113";

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

            string[] result = new string[texts.Count];

            string salt = Guid.NewGuid().ToString();
            string sign = GetSign(s.AppId, s.AppKey, salt, texts[0]);
            
            var transResponse = await _httpClient.Get(_baseUrl)
                .AddQuery("q", texts[0])
                .AddQuery("from", SupportLang.Dic[srcLangCode])
                .AddQuery("to", SupportLang.Dic[trgLangCode])
                .AddQuery("appid", s.AppId)
                .AddQuery("salt", salt)
                .AddQuery("sign", sign)
                .ReceiveJson<TransResponse>(cToken);

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


        private string GetSign(string appId, string appKey, string salt, string text)
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
