using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class DeeplBuiltIn : MultiSupplierMTService
    {
        private class DeepLResponse
        {
            public string Id { get; set; }

            public string Jsonrpc { get; set; }

            public DeepLResult Result { get; set; }
        }

        private class DeepLResult
        {
            public DeepLTextResult[] Texts { get; set; }

            public string Lang { get; set; }
        }

        private class DeepLTextResult
        {
            public string Text { get; set; }
        }


        private static readonly string baseUrl = "https://www2.deepl.com/jsonrpc";

        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "ZH"},
            {"zho-TW", "ZH"},
            {"eng", "EN"},
            {"jpn", "JA"},
            {"kor", "KO"},
            {"fre", "FR"},
            {"spa", "ES"},
            {"rus", "RU"},
            {"ger", "DE"},
            {"ita", "IT"},
            {"tur", "TR"},
            {"por-PT", "PT-PT"},
            {"por", "PT-BR"},
            //{"vie", ""},
            {"ind", "ID"},
            //{"tha", ""},
            //{"msa", ""},
            {"ara", "AR"},
            //{"hin", ""},
        };

        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly Random rndId = new Random(Guid.NewGuid().GetHashCode());

        static DeeplBuiltIn()
        {
            rndId = new Random(Guid.NewGuid().GetHashCode());

            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate, //, | DecompressionMethods.Brotli,
            };
            httpClient = new HttpClient(handler);

            httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            httpClient.DefaultRequestHeaders.Add("x-app-os-name", "iOS");
            httpClient.DefaultRequestHeaders.Add("x-app-os-version", "16.3.0");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate"); //, br
            httpClient.DefaultRequestHeaders.Add("x-app-device", "iPhone13,2");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "DeepL-iOS/2.9.1 iOS 16.3.0 (iPhone13,2)");
            httpClient.DefaultRequestHeaders.Add("x-app-build", "510265");
            httpClient.DefaultRequestHeaders.Add("x-app-version", "2.9.1");
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
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
            return "DeepLBuiltIn";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts2, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            string[] result = new string[texts2.Count];

            long timestamp = this.GetTimestamp(this.GetICount(texts2[0]));
            var id = rndId.Next(11111111, 99999999);

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
                        source_lang_user_selected = supportLanguages[srcLangCode],
                        target_lang = supportLanguages[trgLangCode],
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

            var response = await httpClient.PostAsync(baseUrl, new StringContent(requestBodyText, Encoding.UTF8, "application/json"), cToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var transResponse = JsonConvert.DeserializeObject<DeepLResponse>(jsonResponse);
            
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
