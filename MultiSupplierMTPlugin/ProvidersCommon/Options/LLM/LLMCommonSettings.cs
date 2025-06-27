using Newtonsoft.Json;

namespace MultiSupplierMTPlugin.ProvidersCommon.Options.LLM
{
    class LLMCommonGeneralSettings
    {
        public string GlossaryDelimiter { get; set; } = ",";
        public string GlossaryFilePath { get; set; } = string.Empty;

        public bool SummaryAutoGenerate { get; set; } = false;
        public string SummaryFilePath { get; set; } = string.Empty;
        public string SummaryGeneratePrompt { get; set; } =
                        // 1. 文本用途说明：整篇文档将被分段翻译
                        "The source document will be translated in segments using a large language model. \r\n" +
                        // 2. 摘要目标
                        "To ensure contextual accuracy and consistency, generate a summary of about 1200 words. \r\n" +
                        // 3. 摘要要求：内容 + 风格
                        "The summary should reflect the document’s main topics, tone, style, and intent. It will guide segment-by-segment translation. \r\n" +
                        // 4. 明确文本边界
                        "The source text is between the markers $SOURCE-START$ and $SOURCE-END$. \r\n" +
                        // 5. 输出格式要求
                        "Output only the summary — no explanations, and exclude the markers. \r\n" +
                        // 6. 插入全文
                        "$SOURCE-START$\r\n{{full-text!}}\r\n$SOURCE-END$";

        public bool AboveTextIncludeSource { get; set; } = true;
        public bool AboveTextIncludeTarget { get; set; } = false;
        public int AboveTextMaxSegments { get; set; } = 3;
        public int AboveTextMaxCharacters { get; set; } = 1000;

        public bool BelowTextIncludeSource { get; set; } = true;
        public bool BelowTextIncludeTarget { get; set; } = false;
        public int BelowTextMaxSegments { get; set; } = 3;
        public int BelowTextMaxCharacters { get; set; } = 1000;

        public string PromptTemplateId { get; set; } = string.Empty;
        public PromptTemplate[] PromptTemplates { get; set; } = new PromptTemplate[] { };
    }

    class PromptTemplate
    {
        public string ID { get; set; } = string.Empty; // 不能变更的唯一 ID，

        public string Name { get; set; } = string.Empty; // 用户设定的名字        

        public string SystemPrompt { get; set; } = string.Empty;

        public string UserPrompt { get; set; } = string.Empty;

        public string BathTranslateSystemPrompt { get; set; } = string.Empty;

        public string BathTranslateUserPrompt { get; set; } = string.Empty;


        #region 方法

        public PromptTemplate Clone()
        {
            var jss = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var json = JsonConvert.SerializeObject(this, jss);

            return JsonConvert.DeserializeObject<PromptTemplate>(json, jss);
        }

        public static PromptTemplate GetDefault(string name = null)
        {
            return new PromptTemplate()
            {
                ID = "Default",

                Name = name ?? "Default",

                SystemPrompt =
                        // 1. 大模型角色
                        "You are a professional translator using CAT tools. \r\n" +
                        // 2. 标签说明
                        "Source text may contain tags like <b>, <i>, <u>, <sub>, <sup>, <inline_tag>, <structural_tag>, <spec_char>, or <span data-mqitag>. \r\n" +
                        // 3. 标签处理规范
                        "Do not translate, modify, or remove these tags. Keep them exactly as they are and in the correct positions. \r\n" +
                        // 4. 输出格式要求
                        "Output only the translation — no comments or explanations. ",

                UserPrompt =
                        // 2. 翻译语言方向
                        "Translate the following text from {{source-language!}} to {{target-language!}}: \r\n" +
                        // 2. 插入源文本
                        "{{source-text!}}",

                BathTranslateSystemPrompt =
                        // 1. 大模型角色
                        "You are a professional translator using CAT tools. \r\n" +
                        // 2. 标签说明
                        "Source text may contain tags like <b>, <i>, <u>, <sub>, <sup>, <inline_tag>, <structural_tag>, <spec_char>, or <span data-mqitag>. \r\n" +
                        // 3. 标签处理规范
                        "Do not translate, modify, or remove these tags. Keep them exactly as they are and in the correct positions. \r\n" +
                        // 4. 输出格式要求
                        "Output only the translation — no comments or explanations. ",

                BathTranslateUserPrompt =
                        // 1. 翻译语言方向
                        "Translate the following JSON from {{source-language!}} to {{target-language!}}. \r\n" +
                        // 2. 批量翻译格式
                        "Return a valid JSON object with the same keys and the translated sentences as values: \r\n" +
                        // 3. 插入源文本
                        "{{source-text!}}"
            };
        }

        #endregion
    }
}
