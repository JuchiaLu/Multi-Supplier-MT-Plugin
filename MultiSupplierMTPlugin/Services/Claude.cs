using MemoQ.MTInterfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin.Services
{
    public class Claude : MultiSupplierMTService
    {
        private class AnthropicRequest
        {
            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("messages")]
            public Message[] Messages { get; set; }

            [JsonProperty("max_tokens")]
            public int MaxTokens { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("stop_sequences")]
            public string[] StopSequences { get; set; }

            [JsonProperty("stream")]
            public bool? Stream { get; set; }

            [JsonProperty("system")]
            public string System { get; set; }

            [JsonProperty("temperature")]
            public double? Temperature { get; set; }

            [JsonProperty("top_k")]
            public int? TopK { get; set; }

            [JsonProperty("top_p")]
            public double? TopP { get; set; }
        }

        private class Message
        {
            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("content")]
            public string Content { get; set; }
        }

        private class Metadata
        {
            [JsonProperty("user_id")]
            public string UserId { get; set; }
        }

        private class AnthropicResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("content")]
            public ContentBlock[] Content { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("stop_reason")]
            public string StopReason { get; set; }

            [JsonProperty("stop_sequence")]
            public string StopSequence { get; set; }

            [JsonProperty("usage")]
            public Usage Usage { get; set; }

            [JsonProperty("error")]
            public Error Error { get; set; }
        }

        private class ContentBlock
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }

        private class Usage
        {
            [JsonProperty("input_tokens")]
            public int InputTokens { get; set; }

            [JsonProperty("output_tokens")]
            public int OutputTokens { get; set; }
        }

        private class Error 
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }


        private static readonly Dictionary<string, string> supportLanguages = new Dictionary<string, string>
        {
            {"zho-CN", "Chinese (Simplified)"},
            {"zho-TW", "Chinese (Traditional)"},
            {"eng", "English"},
            {"jpn", "Japanese"},
            {"kor", "Korean"},
            {"fre", "French"},
            {"spa", "Spanish"},
            {"rus", "Russian"},
            {"ger", "German"},
            {"ita", "Italian"},
            {"tur", "Turkish"},
            {"por-PT", "Portuguese (Portugal, Brazil)"},
            {"por", "Portuguese"},
            {"vie", "Vietnamese"},
            {"ind", "Indonesian"},
            {"tha", "Thai"},
            {"msa", "Malay"},
            {"ara", "Arabic"},
            {"hin", "Hindi"},
        };

        private static readonly HttpClient httpClient = new HttpClient();

        static Claude()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("anthropic-version", "2023-06-01");
        }

        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            using (var form = new Forms.FormClaude(options, environment))
            {
                form.ShowDialog(parentForm);
            }

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.ClaudeGeneralOptions.Checked;
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
            return false;
        }

        public override int MaxBatchSize()
        {
            return 1;
        }

        public override int MaxQueriesPerWindow()
        {
            return 45;
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
            return 50;
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
            return "Claude";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            var url = options.GeneralSettings.ClaudeGeneralOptions.BaseURL + options.GeneralSettings.ClaudeGeneralOptions.Path; 
            var model = options.GeneralSettings.ClaudeGeneralOptions.Model;
            var maxTokens = options.GeneralSettings.ClaudeGeneralOptions.MaxTokens;
            var temperature = options.GeneralSettings.ClaudeGeneralOptions.Temperature;
            var prompt = options.GeneralSettings.ClaudeGeneralOptions.Prompt;

            var xApiKey = options.SecureSettings.ClaudeSecureOptions.XApiKey;

            prompt = prompt.Replace("<srcLang>", supportLanguages[srcLangCode]);
            prompt = prompt.Replace("<tgtLang>", supportLanguages[trgLangCode]);

            var text = texts[0];
            var anthropicRequest = new AnthropicRequest()
            {
                System = prompt,
                Messages = new Message[]
                {
                    new Message() { Role = "user", Content = text }
                },
                Model = model,
                MaxTokens = maxTokens,
                Temperature = temperature,
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.TryAddWithoutValidation("x-api-key", xApiKey);

            var jsonRequest = JsonConvert.SerializeObject(anthropicRequest);
            requestMessage.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(requestMessage, cToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var anthropicResponse = JsonConvert.DeserializeObject<AnthropicResponse>(jsonResponse);

            if (!"end_turn".Equals(anthropicResponse.StopReason))
            {
                throw new Exception("model don't hit a natural stop point or a provided stop sequence");
            }

            var content = anthropicResponse.Content[0];

            var result = new List<string>
            {
                content.Text
            };

            return result;
        }

        public static async Task<bool> Check(string baseUrl, string path, string model, int maxTokens, double temperature, string xApiKey, string prompt)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.GeneralSettings.ClaudeGeneralOptions.BaseURL = baseUrl;
            tempOptions.GeneralSettings.ClaudeGeneralOptions.Path = path;
            tempOptions.GeneralSettings.ClaudeGeneralOptions.Model = model;
            tempOptions.GeneralSettings.ClaudeGeneralOptions.MaxTokens = maxTokens;
            tempOptions.GeneralSettings.ClaudeGeneralOptions.Temperature = temperature;
            tempOptions.GeneralSettings.ClaudeGeneralOptions.Prompt = prompt;

            tempOptions.SecureSettings.ClaudeSecureOptions.XApiKey = xApiKey;

            var service = new Claude();
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