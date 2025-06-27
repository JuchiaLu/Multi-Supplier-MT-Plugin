using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.ProvidersCommon.Forms.LLM;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Providers.OpenAI
{
    class Service : LLMBaseService<GeneralSettings, SecureSettings>
    {
        private static readonly HttpClient _httpClient = new HttpClient();


        public Service(MultiSupplierMTOptions mtOptions, ProviderOptions options) 
            : base(mtOptions, options) 
        {
        }

        public override string UniqueName { get; set; } = ServiceNames.OpenAI_LLM;

        public override bool IsAvailable { get { return _generalSettings.Checked; } set { } }

        public override bool IsBuiltIn { get; set; } = false;

        public override bool IsLLM { get; set; } = true;

        public override bool IsXmlSupported { get; set; } = true;

        public override bool IsHtmlSupported { get; set; } = true;

        public override bool IsBatchSupported
        {
            get { return _generalSettings.EnableBathTranslate; }

            // 然而，这里并不能保存到配置文件
            set { _generalSettings.EnableBathTranslate = value; }
        }

        public override int MaxSegments 
        {
            get { return IsBatchSupported ? _generalSettings.BathTranslateMaxSegments : 1; }
            
            // 然而，这里并不能保存到配置文件
            set { _generalSettings.BathTranslateMaxSegments = value; }
        }

        public override int MaxCharacters
        {
            get { return IsBatchSupported ? _generalSettings.BathTranslateMaxCharacters : 0; }

            // 然而，这里并不能保存到配置文件
            set { _generalSettings.BathTranslateMaxCharacters = value; }
        }


        public override int MaxQueriesPerWindow { get; set; } = 45;

        public override int WindowSizeMs { get; set; } = 1000;

        public override double Smoothness { get; set; } = 1.0;

        public override int MaxThreadHold { get; set; } = 50;

        public override int FailedTimeoutMs { get; set; } = 0;

        public override int RetryWaitingMs { get; set; } = 0;

        public override int NumberOfRetries { get; set; } = 0;

        public override string ApiKeyLink { get; set; } = "https://platform.openai.com/api-keys";

        public override string ApiDocLink { get; set; } = "https://platform.openai.com/docs/api-reference/chat";

        public override string ModelsLink { get; set; } = "https://platform.openai.com/docs/models";

        public override Dictionary<string, string> SupportLangDic { get; set; } = SupportLang.Dic;

        public override ModelItem[] BuildInModels { get; set; } =  new string[]
        {
            "gpt-3.5-turbo",
            "gpt-3.5-turbo-0125",
            "gpt-3.5-turbo-1106",
            "gpt-3.5-turbo-instruct",

            "gpt-4",
            "gpt-4-0613",
            "gpt-4-0314",

            "gpt-4-turbo",
            "gpt-4-turbo-2024-04-09",

            "gpt-4-turbo-preview",
            "gpt-4-0125-preview",
            "gpt-4-1106-vision-preview",

            "gpt-4o",
            "gpt-4o-2024-11-20",
            "gpt-4o-2024-08-06",
            "gpt-4o-2024-05-13",

            "gpt-4o-mini", //推荐
            "gpt-4o-mini-2024-07-18",

            "gpt-4.1",
            "gpt-4.1-2025-04-14",

            "gpt-4.1-mini", //推荐
            "gpt-4.1-mini-2025-04-14",

            "gpt-4.1-nano",
            "gpt-4.1-nano-2025-04-14",

            //"chatgpt-4o-latest"
        }.Select(name => new ModelItem() { UniqueName = name, DisplayName = name }).ToArray();


        public override ProviderOptions ShowConfig()
        {
            using (var form = new OptionsForm(this, _generalSettings, _secureSettings, _mtGeneralSettings, _mtSecureSettings))
            {
                form.ShowDialog();
            }

            return new Options(_generalSettings, _secureSettings);
        }

        public override async Task<List<string>> ListModels(CancellationToken cToken, ProviderOptions tempOptions)
        {
            // 决定哪套配置
            var (g, s) = ResolveOptions(tempOptions);

            // 发送请求
            var modelResponse = await _httpClient
               .Get(g.BaseURL + "/models")
               .AddHeader("Authorization", "Bearer " + s.ApiKey)
               .AddHeaderIf(!string.IsNullOrEmpty(s.Organization), "OpenAI-Organization", s.Organization)
               .ReceiveJson<ModelResponse>(cToken);

            // 返回最终结果
            return modelResponse.Data.Select(m => m.Id).OrderBy(i => i, new NaturalSortComparer()).ToList();
        }

        protected override async Task<string> TranslateAsync(
            GeneralSettings g, SecureSettings s, 
            string systemPrompt, string userPrompt,
            List<string> texts, string srcLang, string tgtLang, 
            List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, 
            CancellationToken cToken)
        {
            var localizedName = ServiceLocalizedNameHelper.Get(UniqueName);

            // 6.请求体
            var chatCompletionRequest = new ChatCompletionRequest()
            {
                Messages = new Message[]
                {
                    new Message(){ Role = "system", Content = systemPrompt},
                    new Message(){ Role = "user", Content = userPrompt}
                },

                Model = g.Model,

                MaxTokens = g.MaxTokens,
                Temperature = g.Temperature,
            };

            // 7.请求体批量翻译格式处理
            if (g.EnableBathTranslate)
            {
                var responseFormat = new ResponseFormat();
                switch (g.BathTranslateResponseFormat)
                {
                    case BathTranslateResponseFormat.JSON_Schema:
                        responseFormat.Type = "json_schema";
                        responseFormat.JsonSchema = BathTranslateHelper.GetJsonScheme(g.BathTranslateSchema);
                        break;
                    case BathTranslateResponseFormat.JSON_Object:
                        responseFormat.Type = "json_object";
                        break;
                    default:
                        responseFormat.Type = "text";
                        break;
                }
                chatCompletionRequest.ResponseFormat = responseFormat;
            }

            // 8.发送请求
            var chatCompletionResponse = await _httpClient
                .Post(g.BaseURL + g.Path)
                .AddHeader("Authorization", "Bearer " + s.ApiKey)
                .AddHeaderIf(!string.IsNullOrEmpty(s.Organization), "OpenAI-Organization", s.Organization)
                .SetBodyJson(chatCompletionRequest)
                .ReceiveJson<ChatCompletionResponse>(cToken);

            // 9.读取结果中关心的字段
            var choice = chatCompletionResponse.Choices[0];

            // 10.日志警告非正常响应（不抛异常是因为有的 OpenAI 兼容提供商不一定兼容这些参数）
            if (!"stop".Equals(choice?.FinishReason.ToLower()) || !string.IsNullOrEmpty(choice.Message?.Refusal))
            {
                LoggingHelper.Warn($"{localizedName} Abnormal Finish Reason\r\n" +
                    $"Response did not complete normally — expected finish reason 'stop', but got '{choice?.FinishReason}'.\r\n" +
                    $"{choice.Message?.Refusal}");
            }

            // 11.读取翻译结果内容字段
            string content = choice.Message.Content;

            // 12.日志记录响应结果
            LoggingHelper.Info($"{localizedName} Response\r\n{content}");

            // 13.日志记录 token 使用情况
            LoggingHelper.Info($"{localizedName} Tokens Usage\r\n" +
                $"InputTokens: {chatCompletionResponse?.Usage?.PromptTokens}" +
                $"(WriteToCache: {chatCompletionResponse?.Usage?.PromptTokens}" +
                $", ReadFromCache: {chatCompletionResponse?.Usage?.PromptTokensDetails?.CachedTokens})" +
                $", OutputTokens: {chatCompletionResponse?.Usage?.CompletionTokens}");

            return content;
        }
    }
}