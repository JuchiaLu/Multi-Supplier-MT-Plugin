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
    public class Openai : MultiSupplierMTService
    {
        private class ChatCompletionRequest
        {
            [JsonProperty("messages")]
            public Message2[] Messages { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }

            //[JsonProperty("frequency_penalty")]
            //public double FrequencyPenalty { get; set; }

            //[JsonProperty("logit_bias")]
            //public string LogitBias { get; set; }


            //[JsonProperty("max_tokens")]
            //public int MaxTokens { get; set; }

            //[JsonProperty("n")]
            //public int N { get; set; }


            //[JsonProperty("presence_penalty")]
            //public double PresencePenalty { get; set; }

            //// { "type": "text" } 或 { "type": "json_object" } 
            //[JsonProperty("response_format")]
            //public ResponseRormat ResponseRormat { get; set; }

            //[JsonProperty("seed")]
            //public int Seed { get; set; }

            //// string / array / null
            //[JsonProperty("stop")]
            //public string[] Stop { get; set; }

            //[JsonProperty("stream")]
            //public bool Stream { get; set; }

            [JsonProperty("temperature")]
            public double Temperature { get; set; }

            //[JsonProperty("top_p")]
            //public double TopP { get; set; }

            //[JsonProperty("tools")]
            //public Tool[] Tools { get; set; }

            //[JsonProperty("tool_choice")]
            //public Tool ToolChoice { get; set; }

            //[JsonProperty("user")]
            //public string User { get; set; }
        }

        private class Message2 
        {
            [JsonProperty("content")]
            public string Content { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            //[JsonProperty("name")]
            //public string Name { get; set; }
        }

        private enum Role
        {
            //system,
            //user,
            //assistant,
            //tool
        }

        private enum Model
        {
            //gpt-4
            //gpt-4-1106-preview
            //gpt-4-vision-preview
            //gpt-4-32k
            //gpt-3.5-turbo
            //gpt-3.5-turbo-16k
        }

        private enum FinishReason
        { 
        
        }

        private class ChatCompletionResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("choices")]
            public Choice[] Choices { get; set; }

            [JsonProperty("created")]
            public int Created { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("system_fingerprint")]
            public string SystemFingerprint { get; set; }

            [JsonProperty("object")]
            public string Object { get; set; }

            [JsonProperty("usage")]
            public Usage Usage { get; set; }
        }

        private class Choice
        {
            [JsonProperty("finish_reason")]
            public string FinishReason { get; set; }

            [JsonProperty("index")]
            public int Index { get; set; }

            [JsonProperty("message")]
            public Message Message { get; set; }
        }

        private class Message
        {
            [JsonProperty("content")]
            public string Content { get; set; }

            [JsonProperty("tool_calls")]
            public ToolCall[] ToolCalls { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }
        }

        private class ToolCall
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("function")]
            public Function Function { get; set; }
        }

        private class Function
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("arguments")]
            public string Arguments { get; set; }
        }

        private class Usage
        {
            [JsonProperty("completion_tokens")]
            public int CompletionTokens { get; set; }

            [JsonProperty("prompt_tokens")]
            public int PromptTokens { get; set; }

            [JsonProperty("total_tokens")]
            public int TotalTokens { get; set; }
        }


        private class ChatCompletionChunkResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("choices")]
            public Choice2[] Choices { get; set; }

            [JsonProperty("created")]
            public int Created { get; set; }

            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("system_fingerprint")]
            public string SystemFingerprint { get; set; }

            [JsonProperty("object")]
            public string Object { get; set; }
        }

        private class Choice2
        {
            [JsonProperty("delta")]
            public Delta Delta { get; set; }

            [JsonProperty("finish_reason")]
            public string FinishReason { get; set; }

            [JsonProperty("index")]
            public int Index { get; set; }
        }

        private class Delta
        {
            [JsonProperty("content")]
            public string Content { get; set; }

            [JsonProperty("tool_calls")]
            public ToolCall2[] ToolCalls { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }
        }

        private class ToolCall2
        {
            [JsonProperty("index")]
            public int Index { set; get; }

            [JsonProperty("content")]
            public string Content { get; set; }

            [JsonProperty("tool_calls")]
            public ToolCall2[] ToolCalls { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }
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

        public override MultiSupplierMTOptions ShowConfig(MultiSupplierMTOptions options, IEnvironment environment, IWin32Window parentForm)
        {
            using (var form = new Forms.FormOpenai(options, environment))
            {
                form.ShowDialog(parentForm);
            }

            return options;
        }

        public override bool IsAvailable(MultiSupplierMTOptions options)
        {
            return options.GeneralSettings.OpenaiGeneralOptions.Checked;
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
            return "OpenAI";
        }

        public override async Task<List<string>> TranslateAsync(MultiSupplierMTOptions options, List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken)
        {
            var url = options.GeneralSettings.OpenaiGeneralOptions.BaseURL + options.GeneralSettings.OpenaiGeneralOptions.Path; 
            var model = options.GeneralSettings.OpenaiGeneralOptions.Model;
            var temperature = options.GeneralSettings.OpenaiGeneralOptions.Temperature;
            var prompt = options.GeneralSettings.OpenaiGeneralOptions.Prompt;

            var apiKey = options.SecureSettings.OpenaiSecureOptions.ApiKey;
            var organization = options.SecureSettings.OpenaiSecureOptions.Organization;

            prompt = prompt.Replace("<srcLang>", supportLanguages[srcLangCode]);
            prompt = prompt.Replace("<tgtLang>", supportLanguages[trgLangCode]);

            var text = texts[0];
            var chatCompletionRequest = new ChatCompletionRequest()
            {
                Messages = new Message2[] 
                {
                    new Message2(){ Role = "system", Content = prompt},
                    new Message2(){ Role = "user", Content = text}
                },

                Model = model,

                Temperature = temperature,
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.Add("Authorization", "Bearer " + apiKey);
            if (!string.IsNullOrEmpty(organization))
            {
                requestMessage.Headers.TryAddWithoutValidation("OpenAI-Organization", organization);
            }

            var jsonRequest = JsonConvert.SerializeObject(chatCompletionRequest);
            requestMessage.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(requestMessage, cToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var chatCompletionResponse = JsonConvert.DeserializeObject<ChatCompletionResponse>(jsonResponse);

            var choice = chatCompletionResponse.Choices[0];

            if (!"stop".Equals(choice.FinishReason))
            {
                throw new Exception("model don't hit a natural stop point or a provided stop sequence");
            }

            var result = new List<string>
            {
                choice.Message.Content
            };

            return result;
        }


        public static async Task<bool> Check(string baseUrl, string path, string model, double temperature, string apiKey, string organization, string prompt)
        {
            var tempOptions = new MultiSupplierMTOptions(new MultiSupplierMTGeneralOptions(), new MultiSupplierMTSecureOptions());
            tempOptions.GeneralSettings.OpenaiGeneralOptions.BaseURL = baseUrl;
            tempOptions.GeneralSettings.OpenaiGeneralOptions.Path = path;
            tempOptions.GeneralSettings.OpenaiGeneralOptions.Model = model;
            tempOptions.GeneralSettings.OpenaiGeneralOptions.Temperature = temperature;
            tempOptions.GeneralSettings.OpenaiGeneralOptions.Prompt = prompt;

            tempOptions.SecureSettings.OpenaiSecureOptions.ApiKey = apiKey;
            tempOptions.SecureSettings.OpenaiSecureOptions.Organization = organization;

            var service = new Openai();
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