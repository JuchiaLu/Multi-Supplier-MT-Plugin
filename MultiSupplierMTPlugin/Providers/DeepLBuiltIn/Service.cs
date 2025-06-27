using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.DeepLBuiltIn
{
    class Service : NMTBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private const string _baseUrl = "https://www2.deepl.com/jsonrpc";


        private static readonly Random _rndId = new Random(Guid.NewGuid().GetHashCode());

        static Service()
        {
            _rndId = new Random(Guid.NewGuid().GetHashCode());

            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate, //, | DecompressionMethods.Brotli,
            };
            _httpClient = new HttpClient(handler);

            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            _httpClient.DefaultRequestHeaders.Add("x-app-os-name", "iOS");
            _httpClient.DefaultRequestHeaders.Add("x-app-os-version", "18.3.0");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate"); //, br
            _httpClient.DefaultRequestHeaders.Add("x-app-device", "iPhone14,2");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "DeepL-iOS/3.9.1 iOS 18.3.0 (iPhone14,2)");
            _httpClient.DefaultRequestHeaders.Add("x-app-build", "510264");
            _httpClient.DefaultRequestHeaders.Add("x-app-version", "3.9.1");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
        }

        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options) { }


        public override string UniqueName { get; set; } = ServiceNames.DeepL_BuiltIn;

        public override bool IsAvailable { get { return true; } set { } }

        public override bool IsBuiltIn { get; set; } = true;

        public override bool IsLLM { get; set; } = false;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = true;

        public override bool IsBatchSupported { get; set; } = false;

        public override int MaxSegments { get; set; } = 1;

        public override int MaxCharacters { get; set; } = 0;

        public override int MaxQueriesPerWindow { get; set; } = 5;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 5;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "";

        public override string ApiDocLink { get; set; } = "";

        public override Dictionary<string, string> SupportLangDic { get; set; } = SupportLang.Dic;

        public override ProviderOptions ShowConfig()
        {
            return new Options(_generalSettings, _secureSettings);
        }

        public override async Task<List<string>> TranslateAsync(List<string> texts2, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken, ProviderOptions tempOptions)
        {
            string[] result = new string[texts2.Count];

            long timestamp = this.GetTimestamp(this.GetICount(texts2[0]));
            var id = _rndId.Next(11111111, 99999999);

            var text = texts2[0];

            var requestBody = new
            {
                jsonrpc = "2.0",
                method = "LMT_handle_texts",
                @params = new
                {
                    splitting = "newlines",
                    lang = new
                    {
                        source_lang_user_selected = SupportLang.Dic[srcLangCode],
                        target_lang = SupportLang.Dic[trgLangCode],
                    },
                    //commonJobParams = new
                    //{
                    //    wasSpoken = false,
                    //    transcribe_as = string.Empty,
                    //},
                    texts = new[]
                    {
                        new
                        {
                            text,
                            request_alternatives = 3,
                        },
                    },
                    timestamp,
                },
                id,
            };

            var requestBodyText = JsonConvert.SerializeObject(requestBody);


            if ((id + 5) % 29 == 0 || (id + 3) % 13 == 0)
            {
                requestBodyText = requestBodyText.Replace("\"method\":\"", "\"method\" : \"");
            }
            else
            {
                requestBodyText = requestBodyText.Replace("\"method\":\"", "\"method\": \"");
            }

            var transResponse = await _httpClient.Post(_baseUrl)
                .SetBodyJsonString(requestBodyText)
                .ReceiveJson<DeepLResponse>(cToken);

            result[0] = transResponse.Result.Texts[0].Text;

            return result.ToList();
        }


        private int GetICount(string translateText)
        {
            return translateText.Count(c => c == 'i');
        }

        private long GetTimestamp(int iCount)
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            if (iCount == 0)
            {
                return timestamp;
            }

            iCount++;
            return timestamp - (timestamp % iCount) + iCount;
        }
    }
}
