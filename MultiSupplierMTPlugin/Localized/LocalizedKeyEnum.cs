
namespace MultiSupplierMTPlugin.Localized
{
    // TODO：除了不可避免的动态值（时间日期、用户输入等）外，最好不要使用插值，这不利于理解且不利于批量翻译

    public  class LocalizedKeyEnum : ILocalizedKeyEnum
    {
        private LocalizedKeyEnum(string name) : base(name) 
        {
        }

        [LocalizedKey("4ec208c3-410c-4daa-8cb7-8a1dbc8d9b13", "Multi Supplier MT Plugin")] // 多提供商机器翻译插件
        public static readonly LocalizedKeyEnum OptionForm = new LocalizedKeyEnum(nameof(OptionForm));

        [LocalizedKey("d5b68680-860a-43b6-a34f-f9b06672361c", "Service Provider")] // 提供商
        public static readonly LocalizedKeyEnum OptionForm_LabelServiceProvider = new LocalizedKeyEnum(nameof(OptionForm_LabelServiceProvider));

        [LocalizedKey("eb524eef-5269-4b05-a9f5-b922688c32f5", "Test (Built In)")] // 测试翻译（内置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Test = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Test));

        [LocalizedKey("98f52dda-407e-4558-bb5b-c5d1be9bae2a", "Request Type")] // 请求类型
        public static readonly LocalizedKeyEnum OptionForm_LabelRequestType = new LocalizedKeyEnum(nameof(OptionForm_LabelRequestType));

        [LocalizedKey("eb2b3011-77f5-498c-b3eb-15719ec439be", "Plaintext")] // 仅纯文本
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxRequestType_Plaintext = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxRequestType_Plaintext));

        [LocalizedKey("f926c81f-7e8c-4d93-819a-90d67f61e8f9", "Include Formatting With Xml")] // 包括格式标记，（用 Xml 表示）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxRequestType_OnlyFormattingWithXml = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxRequestType_OnlyFormattingWithXml));

        [LocalizedKey("ed3b6ee6-f020-4f97-ae01-b5e3f139cd60", "Include Formatting With Html")] // 包括格式标记，（用 Html 表示）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxRequestType_OnlyFormattingWithHtml = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxRequestType_OnlyFormattingWithHtml));

        [LocalizedKey("095b951d-6052-4a60-a235-7ef4c08a31ef", "Include Formatting And Tags With Xml")] // 包括格式标记和内联标签，（用 Xml 表示）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxRequestType_BothFormattingAndTagsWithXml = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxRequestType_BothFormattingAndTagsWithXml));

        [LocalizedKey("7699f7c8-f881-4fc1-b3d6-26f6fb3886ad", "Include Formatting And Tags With Html")] // 包括格式标记和内联标签，（用 Html 表示）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxRequestType_BothFormattingAndTagsWithHtml = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxRequestType_BothFormattingAndTagsWithHtml));

        [LocalizedKey("4f5424da-0e9b-4248-9a34-68846494ba2a", "Insert Required Tags To End")] // 将原文中的内联标签追加到译文后
        public static readonly LocalizedKeyEnum OptionForm_CheckBoxTagsToEnd = new LocalizedKeyEnum(nameof(OptionForm_CheckBoxTagsToEnd));

        [LocalizedKey("c2c08303-5d5d-4341-84cf-0b4c7eb61a7f", "Normalize Whitespace Around Tags")] // 归一化译文中内联标签旁边的空格
        public static readonly LocalizedKeyEnum OptionForm_CheckBoxNormalizeWhitespace = new LocalizedKeyEnum(nameof(OptionForm_CheckBoxNormalizeWhitespace));

        [LocalizedKey("73f9781d-d68f-45fa-bcc4-032e077895ed", "Enable Translate Cache")] // 启用翻译缓存
        public static readonly LocalizedKeyEnum OptionForm_CheckBoxTranslateCache = new LocalizedKeyEnum(nameof(OptionForm_CheckBoxTranslateCache));


        [LocalizedKey("167c4588-e75f-440e-8948-9baab3d30199", "Microsoft (Built In)")] // 微软翻译（内置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_MicrosoftBuiltIn = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_MicrosoftBuiltIn));

        [LocalizedKey("7259d737-eca2-4e08-8f05-7ca50bb2a056", "Google (Built In)")] // 谷歌翻译（内置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_GoogleBuiltIn = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_GoogleBuiltIn));

        [LocalizedKey("10a4fe53-0ce6-4943-8593-2f7c6bcca77a", "Baidu (Need Config)")] // 百度翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Baidu = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Baidu));

        [LocalizedKey("bebacba9-8a50-4039-a8a2-80b28772e8ca", "Tencent (Need Config)")] // 腾讯翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Tencent = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Tencent));

        [LocalizedKey("a3700cd7-ce8d-4eb6-bf72-dfb8c0a8fc25", "Aliyun (Need Config)")] // 阿里翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Aliyun = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Aliyun));

        [LocalizedKey("3e2dfcbe-645b-4c7d-aef6-f3483ee97110", "Huoshan (Need Config)")] // 火山翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Huoshan = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Huoshan));

        [LocalizedKey("c1f403bd-c452-4ef1-ada7-6bc70f4f68ce", "Caiyun (Need Config)")] // 彩云翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Caiyun = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Caiyun));

        [LocalizedKey("44230611-1c83-4e2b-b13a-23b01dca3d69", "Niutrans (Need Config)")] // 小牛翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Niutrans = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Niutrans));

        [LocalizedKey("8bedbcea-d908-4fe6-ae86-03e25c0a558b", "Youdao (Need Config)")] // 有道翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Youdao = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Youdao));

        [LocalizedKey("a00b8e13-dd40-4133-8725-61c32750b034", "Xunfei (Need Config)")] // 讯飞翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Xunfei = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Xunfei));

        [LocalizedKey("8b613cee-28a1-47b1-905e-4cc5a358f01f", "OpenAI GPT (Need Config)")] // OpenAI GPT（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_OpenAI = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_OpenAI));

        [LocalizedKey("3c815cd6-9f40-41e9-aef4-36153af826ca", "Papago (Need Config)")] // Papago 翻译（需配置）
        public static readonly LocalizedKeyEnum OptionForm_ComboBoxServiceProvider_Papago = new LocalizedKeyEnum(nameof(OptionForm_ComboBoxServiceProvider_Papago));


        [LocalizedKey("585eb308-fa75-4952-8889-692e54dbf0bf", "Check")] // 检测
        public static readonly LocalizedKeyEnum OptionForm_LinkLabelCheck = new LocalizedKeyEnum(nameof(OptionForm_LinkLabelCheck));

        [LocalizedKey("877868a5-db27-45fc-b1ad-3ce6da4d0d9e", "OK")] // 确认
        public static readonly LocalizedKeyEnum OptionForm_ButtonOK = new LocalizedKeyEnum(nameof(OptionForm_ButtonOK));

        [LocalizedKey("0f95184c-1752-40f7-9786-d1ab711e781d", "Cancel")] // 取消
        public static readonly LocalizedKeyEnum OptionForm_ButtonCancel = new LocalizedKeyEnum(nameof(OptionForm_ButtonCancel));

        [LocalizedKey("f5195f4d-e383-46cc-ae13-a2cb548b679e", "Checked Succeess !")] // 检测成功！
        public static readonly LocalizedKeyEnum OptionForm_LabelCheckResult_CheckedSuccees = new LocalizedKeyEnum(nameof(OptionForm_LabelCheckResult_CheckedSuccees));

        [LocalizedKey("98c68a7d-ea6a-4a0e-bb26-51ca50fb13d8", "Checked Fail !")] // 检测失败！
        public static readonly LocalizedKeyEnum OptionForm_LabelCheckResult_CheckedFail = new LocalizedKeyEnum(nameof(OptionForm_LabelCheckResult_CheckedFail));


        [LocalizedKey("81752443-6399-441a-9243-82563c012d8f", "Aliyun")] // 阿里翻译
        public static readonly LocalizedKeyEnum OptionFormAliyun = new LocalizedKeyEnum(nameof(OptionFormAliyun));

        [LocalizedKey("b5661636-c435-49a7-81c6-cfd668a39e36", "Key Id")] // Key Id
        public static readonly LocalizedKeyEnum OptionFormAliyun_LabelKeyId = new LocalizedKeyEnum(nameof(OptionFormAliyun_LabelKeyId));

        [LocalizedKey("61ceadf9-9ab8-4158-9faa-c7068d6d893c", "Key Secret")] // Key Secret
        public static readonly LocalizedKeyEnum OptionFormAliyun_LabelKeySecret = new LocalizedKeyEnum(nameof(OptionFormAliyun_LabelKeySecret));

        [LocalizedKey("8e1fd442-84b4-4051-aa7e-2da7adef70c6", "Type")] // 版 本
        public static readonly LocalizedKeyEnum OptionFormAliyun_LabelServiceType = new LocalizedKeyEnum(nameof(OptionFormAliyun_LabelServiceType));

        [LocalizedKey("9ce291a1-d735-4b7b-b8a6-0a4fe9f58d27", "General")] // 普通版
        public static readonly LocalizedKeyEnum OptionFormAliyun_RadioButtonGeneral = new LocalizedKeyEnum(nameof(OptionFormAliyun_RadioButtonGeneral));

        [LocalizedKey("18adb34c-014b-44fb-b7a7-86e7f90572f7", "Professional")] // 专业版
        public static readonly LocalizedKeyEnum OptionFormAliyun_RadioButtonProfessional = new LocalizedKeyEnum(nameof(OptionFormAliyun_RadioButtonProfessional));


        [LocalizedKey("02dbdf25-02a9-4cd3-8a8e-d54290fa2fe6", "Baidu")] // 百度翻译
        public static readonly LocalizedKeyEnum OptionFormBaidu = new LocalizedKeyEnum(nameof(OptionFormBaidu));

        [LocalizedKey("362f169d-dc50-42d4-bb28-e54ced53ea5b", "App Id")] // App Id
        public static readonly LocalizedKeyEnum OptionFormBaidu_LabelAppId = new LocalizedKeyEnum(nameof(OptionFormBaidu_LabelAppId));

        [LocalizedKey("865a1c4e-4701-47d3-9b26-f88a76c8bc02", "App Key")] // App Key
        public static readonly LocalizedKeyEnum OptionFormBaidu_LabelAppKey = new LocalizedKeyEnum(nameof(OptionFormBaidu_LabelAppKey));


        [LocalizedKey("44835cf9-2e46-401b-aafb-380bfa0b45c4", "Tencent")] // 腾讯翻译
        public static readonly LocalizedKeyEnum OptionFormTencent = new LocalizedKeyEnum(nameof(OptionFormTencent));

        [LocalizedKey("3b683478-2921-4ae5-89a4-ff32d98bfd57", "Secret Id")] // Secret Id
        public static readonly LocalizedKeyEnum OptionFormTencent_LabelSecretId = new LocalizedKeyEnum(nameof(OptionFormTencent_LabelSecretId));

        [LocalizedKey("73ce8a1b-a18a-4ba6-b0da-e0f9dc61a31b", "Secret Key")] // Secret Key
        public static readonly LocalizedKeyEnum OptionFormTencent_LabelSecretKey = new LocalizedKeyEnum(nameof(OptionFormTencent_LabelSecretKey));


        [LocalizedKey("d4682b5e-a68b-49bb-9811-4d0138c0b50a", "Huoshan")] // 火山翻译
        public static readonly LocalizedKeyEnum OptionFormHuoshan = new LocalizedKeyEnum(nameof(OptionFormHuoshan));

        [LocalizedKey("134a02b6-6c85-4425-981c-36f0dd5e121f", "Access Key")] // Access Key
        public static readonly LocalizedKeyEnum OptionFormHuoshan_LabelAccessKey = new LocalizedKeyEnum(nameof(OptionFormHuoshan_LabelAccessKey));

        [LocalizedKey("6961769b-5c4f-4166-ad37-ea1f3fa756b7", "Secret Key")] // Secret Key
        public static readonly LocalizedKeyEnum OptionFormHuoshan_LabelSecretKey = new LocalizedKeyEnum(nameof(OptionFormHuoshan_LabelSecretKey));


        [LocalizedKey("9141043a-d8df-4ca0-95aa-a941c7fcff03", "Caiyun")] // 彩云翻译
        public static readonly LocalizedKeyEnum OptionFormCaiyun = new LocalizedKeyEnum(nameof(OptionFormCaiyun));

        [LocalizedKey("3907107c-22eb-4572-b41f-1ace9ce191b4", "Token")] // Token
        public static readonly LocalizedKeyEnum OptionFormCaiyun_LabelToken = new LocalizedKeyEnum(nameof(OptionFormCaiyun_LabelToken));


        [LocalizedKey("8ca6b805-41fe-4830-8d5b-e16673d712b5", "Niutrans")] // 小牛翻译
        public static readonly LocalizedKeyEnum OptionFormNiutrans = new LocalizedKeyEnum(nameof(OptionFormNiutrans));

        [LocalizedKey("8cd43629-c5ba-4cba-8949-2c7824e246df", "Api Key")] // Api Key
        public static readonly LocalizedKeyEnum OptionFormNiutrans_LabelApikey = new LocalizedKeyEnum(nameof(OptionFormNiutrans_LabelApikey));


        [LocalizedKey("65cfa610-5c9e-4fc0-acc9-e67e271adbcb", "Youdao")] // 有道翻译
        public static readonly LocalizedKeyEnum OptionFormYoudao = new LocalizedKeyEnum(nameof(OptionFormYoudao));

        [LocalizedKey("4dcdcb0b-f653-4349-b9af-7314712da29c", "App Key")] // App Key
        public static readonly LocalizedKeyEnum OptionFormYoudao_LabelAppKey = new LocalizedKeyEnum(nameof(OptionFormYoudao_LabelAppKey));

        [LocalizedKey("ae384aee-4b30-4544-a587-c3669e8dddae", "App Secret")] // App Secret
        public static readonly LocalizedKeyEnum OptionFormYoudao_LabelAppSecret = new LocalizedKeyEnum(nameof(OptionFormYoudao_LabelAppSecret));


        [LocalizedKey("a89e15a0-c08f-47a0-a517-be32d5200068", "Xunfei")] // 讯飞翻译
        public static readonly LocalizedKeyEnum OptionFormXunfei = new LocalizedKeyEnum(nameof(OptionFormXunfei));

        [LocalizedKey("099c2f58-da48-48b4-af32-91e172fc0709", "Api Id")] // Api Id
        public static readonly LocalizedKeyEnum OptionFormXunfei_LabelApiId = new LocalizedKeyEnum(nameof(OptionFormXunfei_LabelApiId));

        [LocalizedKey("9a1ae0fa-1be3-4cf9-95d2-7d4f1337d2d4", "Api Key")] // Api Key
        public static readonly LocalizedKeyEnum OptionFormXunfei_LabelApiKey = new LocalizedKeyEnum(nameof(OptionFormXunfei_LabelApiKey));

        [LocalizedKey("ff38c851-5663-4b7d-8c85-4bea0ce0b058", "Api Secret")] // Api Secret
        public static readonly LocalizedKeyEnum OptionFormXunfei_LabelApiSecret = new LocalizedKeyEnum(nameof(OptionFormXunfei_LabelApiSecret));


        [LocalizedKey("07a89e6b-7ae9-4dab-8c63-d78fc747ea82", "OpenAI GPT")] // OpenAI GPT
        public static readonly LocalizedKeyEnum OptionFormOpenai = new LocalizedKeyEnum(nameof(OptionFormOpenai));

        [LocalizedKey("300fc67c-0b73-42e1-8e5f-6594aaf0ab8f", "Base Url")] // Base Url
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelBaseUrl = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelBaseUrl));

        [LocalizedKey("42bbc36b-7616-45cb-ae8b-fa2575d11849", "Path")] // Path
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelPath = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelPath));

        [LocalizedKey("f8289042-679e-4a55-aa7c-a0c00ee640a0", "Model")] // Model
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelModel = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelModel));

        [LocalizedKey("8793bde6-cdf1-4fca-a7db-2d42251c4097", "Temperature")] // Temperature
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelTemperature = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelTemperature));

        [LocalizedKey("ab51f3ef-e791-48db-aba8-37c9435d7396", "Api Key")] // Api Key
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelApiKey = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelApiKey));

        [LocalizedKey("87136671-38b8-41d0-8e9b-5151282e2cc3", "Org(optional)")] // Org(optional)
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelOrganization = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelOrganization));

        [LocalizedKey("8b08223d-ff3a-4618-8f53-70d3abfe899e", "Prompt")] // Prompt
        public static readonly LocalizedKeyEnum OptionFormOpenai_LabelPrompt = new LocalizedKeyEnum(nameof(OptionFormOpenai_LabelPrompt));


        [LocalizedKey("76845133-ca2a-4cd5-a5a2-3218e656b381", "Papago")] // Papago 翻译
        public static readonly LocalizedKeyEnum OptionFormPapago = new LocalizedKeyEnum(nameof(OptionFormPapago));

        [LocalizedKey("445a5731-6292-4d94-9b54-a7bf456058c2", "Client ID")] // Client ID
        public static readonly LocalizedKeyEnum OptionFormPapago_LabelClientID = new LocalizedKeyEnum(nameof(OptionFormPapago_LabelClientID));

        [LocalizedKey("f66898c7-cc1c-4b2d-9a46-ce31c53dff2f", "Client Secret")] // Client Secret
        public static readonly LocalizedKeyEnum OptionFormPapago_LabelClientSecret = new LocalizedKeyEnum(nameof(OptionFormPapago_LabelClientSecret));
    }
}
