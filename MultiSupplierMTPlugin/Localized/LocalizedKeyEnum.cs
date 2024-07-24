
namespace MultiSupplierMTPlugin.Localized
{
    // TODO：除了不可避免的动态值（时间日期、用户输入等）外，最好不要使用插值，这不利于理解且不利于批量翻译

    public  class LocalizedKeyEnum : LocalizedKeyEnumBase
    {
        private LocalizedKeyEnum(string name) : base(name) 
        {
        }

        [LocalizedKey("4ec208c3-410c-4daa-8cb7-8a1dbc8d9b13", "Multi Supplier MT Plugin")] // 多提供商机器翻译插件
        public static readonly LocalizedKeyEnum Form = new LocalizedKeyEnum(nameof(Form));

        [LocalizedKey("d5b68680-860a-43b6-a34f-f9b06672361c", "Service Provider")] // 提供商
        public static readonly LocalizedKeyEnum Form_LabelServiceProvider = new LocalizedKeyEnum(nameof(Form_LabelServiceProvider));

        [LocalizedKey("98f52dda-407e-4558-bb5b-c5d1be9bae2a", "Request Type")] // 请求类型
        public static readonly LocalizedKeyEnum Form_LabelRequestType = new LocalizedKeyEnum(nameof(Form_LabelRequestType));

        [LocalizedKey("4f5424da-0e9b-4248-9a34-68846494ba2a", "Insert Required Tags To End")] // 将原文中的内联标签追加到译文后
        public static readonly LocalizedKeyEnum Form_CheckBoxTagsToEnd = new LocalizedKeyEnum(nameof(Form_CheckBoxTagsToEnd));

        [LocalizedKey("c2c08303-5d5d-4341-84cf-0b4c7eb61a7f", "Normalize Whitespace Around Tags")] // 归一化译文中内联标签旁边的空格
        public static readonly LocalizedKeyEnum Form_CheckBoxNormalizeWhitespace = new LocalizedKeyEnum(nameof(Form_CheckBoxNormalizeWhitespace));

        [LocalizedKey("f2a12541-8aef-4ef2-8544-87762cb08c36", "Enable Custom Request Limit")] // 启用自定义请求限制
        public static readonly LocalizedKeyEnum Form_LinkLabelCustomRequestLimit = new LocalizedKeyEnum(nameof(Form_LinkLabelCustomRequestLimit));

        [LocalizedKey("bac7187e-1367-4ffb-a8e9-439d30267790", "Enable Custom Display Name")] // 启用自定义显示名称
        public static readonly LocalizedKeyEnum Form_LinkLabelCustomDisplayName = new LocalizedKeyEnum(nameof(Form_LinkLabelCustomDisplayName));

        [LocalizedKey("63604532-cd5c-4ef8-af3d-3540dc6e3acc", "Enable Stats And Log")] // 启用统计和日志
        public static readonly LocalizedKeyEnum Form_LinkLabelStatsAndLog = new LocalizedKeyEnum(nameof(Form_LinkLabelStatsAndLog));

        [LocalizedKey("73f9781d-d68f-45fa-bcc4-032e077895ed", "Enable Translate Cache")] // 启用翻译缓存
        public static readonly LocalizedKeyEnum Form_LinkLabelTranslateCache = new LocalizedKeyEnum(nameof(Form_LinkLabelTranslateCache));


        [LocalizedKey("eb2b3011-77f5-498c-b3eb-15719ec439be", "Plaintext")] // 仅纯文本
        public static readonly LocalizedKeyEnum Form_ComboBoxRequestType_Plaintext = new LocalizedKeyEnum(nameof(Form_ComboBoxRequestType_Plaintext));

        [LocalizedKey("f926c81f-7e8c-4d93-819a-90d67f61e8f9", "Include Formatting With Xml")] // 包括格式标记，（用 Xml 表示）
        public static readonly LocalizedKeyEnum Form_ComboBoxRequestType_OnlyFormattingWithXml = new LocalizedKeyEnum(nameof(Form_ComboBoxRequestType_OnlyFormattingWithXml));

        [LocalizedKey("ed3b6ee6-f020-4f97-ae01-b5e3f139cd60", "Include Formatting With Html")] // 包括格式标记，（用 Html 表示）
        public static readonly LocalizedKeyEnum Form_ComboBoxRequestType_OnlyFormattingWithHtml = new LocalizedKeyEnum(nameof(Form_ComboBoxRequestType_OnlyFormattingWithHtml));

        [LocalizedKey("095b951d-6052-4a60-a235-7ef4c08a31ef", "Include Formatting And Tags With Xml")] // 包括格式标记和内联标签，（用 Xml 表示）
        public static readonly LocalizedKeyEnum Form_ComboBoxRequestType_BothFormattingAndTagsWithXml = new LocalizedKeyEnum(nameof(Form_ComboBoxRequestType_BothFormattingAndTagsWithXml));

        [LocalizedKey("7699f7c8-f881-4fc1-b3d6-26f6fb3886ad", "Include Formatting And Tags With Html")] // 包括格式标记和内联标签，（用 Html 表示）
        public static readonly LocalizedKeyEnum Form_ComboBoxRequestType_BothFormattingAndTagsWithHtml = new LocalizedKeyEnum(nameof(Form_ComboBoxRequestType_BothFormattingAndTagsWithHtml));


        [LocalizedKey("eb524eef-5269-4b05-a9f5-b922688c32f5", "Test (Built In)")] // 测试翻译（内置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_TestBuiltIn = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_TestBuiltIn));

        [LocalizedKey("167c4588-e75f-440e-8948-9baab3d30199", "Microsoft (Built In)")] // 微软翻译（内置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_MicrosoftBuiltIn = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_MicrosoftBuiltIn));

        [LocalizedKey("7259d737-eca2-4e08-8f05-7ca50bb2a056", "Google (Built In)")] // 谷歌翻译（内置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_GoogleBuiltIn = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_GoogleBuiltIn));

        [LocalizedKey("68f20413-9b96-4f29-9f91-4465c3a246a9", "DeepL (Built In)")] // DeepL 翻译（内置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_DeepLBuiltIn = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_DeepLBuiltIn));

        [LocalizedKey("1d684418-58fa-4c85-b40a-1b4cf327c63e", "Lingvanex (Built In)")] // Lingvanex 翻译（内置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_LingvanexBuiltIn = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_LingvanexBuiltIn));

        [LocalizedKey("117446d0-394d-4a30-ab9d-e60f378b3178", "Yandex (Built In)")] // Yandex 翻译（内置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_YandexBuiltIn = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_YandexBuiltIn));

        [LocalizedKey("10a4fe53-0ce6-4943-8593-2f7c6bcca77a", "Baidu (Need Config)")] // 百度翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Baidu = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Baidu));

        [LocalizedKey("bebacba9-8a50-4039-a8a2-80b28772e8ca", "Tencent (Need Config)")] // 腾讯翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Tencent = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Tencent));

        [LocalizedKey("a3700cd7-ce8d-4eb6-bf72-dfb8c0a8fc25", "Aliyun (Need Config)")] // 阿里翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Aliyun = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Aliyun));

        [LocalizedKey("3e2dfcbe-645b-4c7d-aef6-f3483ee97110", "Huoshan (Need Config)")] // 火山翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Huoshan = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Huoshan));

        [LocalizedKey("c1f403bd-c452-4ef1-ada7-6bc70f4f68ce", "Caiyun (Need Config)")] // 彩云翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Caiyun = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Caiyun));

        [LocalizedKey("44230611-1c83-4e2b-b13a-23b01dca3d69", "Niutrans (Need Config)")] // 小牛翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Niutrans = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Niutrans));

        [LocalizedKey("8bedbcea-d908-4fe6-ae86-03e25c0a558b", "Youdao (Need Config)")] // 有道翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Youdao = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Youdao));

        [LocalizedKey("a00b8e13-dd40-4133-8725-61c32750b034", "Xunfei (Need Config)")] // 讯飞翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Xunfei = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Xunfei));

        [LocalizedKey("8b613cee-28a1-47b1-905e-4cc5a358f01f", "OpenAI GPT (Need Config)")] // OpenAI GPT（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_OpenAI = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_OpenAI));

        [LocalizedKey("3c815cd6-9f40-41e9-aef4-36153af826ca", "Papago (Need Config)")] // Papago 翻译（需配置）
        public static readonly LocalizedKeyEnum Form_ComboBoxServiceProvider_Papago = new LocalizedKeyEnum(nameof(Form_ComboBoxServiceProvider_Papago));


        [LocalizedKey("22031b6b-eeb0-4599-b0d9-1e3641668875", "Custom Request Limit")] // 自定义请求限制
        public static readonly LocalizedKeyEnum FormCustomLimit = new LocalizedKeyEnum(nameof(FormCustomLimit));

        [LocalizedKey("0c2743fc-8e3b-45b1-8ffa-0bd6f2971397", "Segment Limit")] //句段限制
        public static readonly LocalizedKeyEnum FormCustomLimit_TabPageSegmentLimit = new LocalizedKeyEnum(nameof(FormCustomLimit_TabPageSegmentLimit));
        
        [LocalizedKey("c72a9c7b-dceb-4c54-b62c-64738f86033f", "Max Segments Per Request")] //每请求最大句段数
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelMaxSegmentsPerRequest = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelMaxSegmentsPerRequest));

        [LocalizedKey("6cbdf74a-8412-4c20-9d5b-f3eda4fc7f26", "Selected provider no supported batch translation!")] //选择的提供商不支持批量翻译！
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelNoBathTip = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelNoBathTip));

        [LocalizedKey("8d3c7ac2-b063-4de9-9d17-233d4a4f46ae", "Rate Limit")] // 速率限制
        public static readonly LocalizedKeyEnum FormCustomLimit_TabPageRateLimit = new LocalizedKeyEnum(nameof(FormCustomLimit_TabPageRateLimit));

        [LocalizedKey("849ae12e-3897-4247-afb0-e3419ec9bbd9", "Max Requests Per Window")] // 每窗口最大请求数
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelMaxRequestsPerWindow = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelMaxRequestsPerWindow));

        [LocalizedKey("d1cb71bd-5def-4dae-99d1-697cfe21aaf7", "Window Size Ms")] // 窗口大小（毫秒）
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelWindowSizeMs = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelWindowSizeMs));
        
        [LocalizedKey("9314b2e9-8bbb-43cb-96c9-205da152ee77", "Request Smoothness")] // 请求平滑度
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelRequestSmoothness = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelRequestSmoothness));
        
        [LocalizedKey("fbfb46fd-f5f3-41f9-ac20-8d182feeeec0", "Concurrency Limit")] // 并发限制
        public static readonly LocalizedKeyEnum FormCustomLimit_TabPageConcurrencyLimit = new LocalizedKeyEnum(nameof(FormCustomLimit_TabPageConcurrencyLimit));
        
        [LocalizedKey("b12804ea-fc85-4a47-a2ea-a19c1bb69474", "Max Requests Hold")] // 请求最大保持数
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelMaxRequestsHold = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelMaxRequestsHold));
        
        [LocalizedKey("0c339fcb-14b1-44a5-81b7-74c57492d7ac", "Retry Limit")] // 重试限制
        public static readonly LocalizedKeyEnum FormCustomLimit_TabPageRetryLimit = new LocalizedKeyEnum(nameof(FormCustomLimit_TabPageRetryLimit));

        [LocalizedKey("fcc7de38-9e72-4994-b329-0314c318fd82", "Number Of Retries")] // 重试最大次数
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelNumberOfRetries = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelNumberOfRetries));

        [LocalizedKey("33beee65-d86f-4943-ab77-6b83d2a6e480", "Failed Timeout Ms")] // 超时失败（毫秒）
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelFailedTimeoutMs = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelFailedTimeoutMs));
        
        [LocalizedKey("98d13160-5171-43ee-9d99-606f9c349985", "Retry Waiting Ms")] // 重试等待（毫秒）
        public static readonly LocalizedKeyEnum FormCustomLimit_LabelRetryWaitingMs = new LocalizedKeyEnum(nameof(FormCustomLimit_LabelRetryWaitingMs));

        [LocalizedKey("16aba4ce-e67e-46c2-82f0-fd4edd64ca1a", "Load Provider Default")] // 加载提供商默认值
        public static readonly LocalizedKeyEnum FormCustomLimit_ButtonLoadProviderDefault = new LocalizedKeyEnum(nameof(FormCustomLimit_ButtonLoadProviderDefault));


        [LocalizedKey("f3f35751-a53b-4933-b04d-9ae07a45ac48", "Custom Display Name")] // 自定义显示名称
        public static readonly LocalizedKeyEnum FormCustomDisplayName = new LocalizedKeyEnum(nameof(FormCustomDisplayName));

        [LocalizedKey("f98f704f-cdab-4049-9236-065df3dbcb8b", "Display Name")] // 显示名称
        public static readonly LocalizedKeyEnum FormCustomDisplayName_LabelDisplayName = new LocalizedKeyEnum(nameof(FormCustomDisplayName_LabelDisplayName));


        [LocalizedKey("ea435a7b-1cb3-4c8f-a9bb-360641b2b9e3", "Stats And Log")] // 统计和日志
        public static readonly LocalizedKeyEnum FormStatsAndLog = new LocalizedKeyEnum(nameof(FormStatsAndLog));

        [LocalizedKey("1ad559b0-d204-4ba5-8571-a92f460e87be", "Request Count")] // 请求条数
        public static readonly LocalizedKeyEnum FormStatsAndLog_LabelRequestCount = new LocalizedKeyEnum(nameof(FormStatsAndLog_LabelRequestCount));

        [LocalizedKey("c479e88b-6cf4-41ab-9bb8-20732c5335f2", "Exception Count")] // 异常条数
        public static readonly LocalizedKeyEnum FormStatsAndLog_LabelExceptionCount = new LocalizedKeyEnum(nameof(FormStatsAndLog_LabelExceptionCount));

        [LocalizedKey("f32a702e-9295-4043-b926-79c3417f0452", "Reset Stats")] // 重置统计
        public static readonly LocalizedKeyEnum FormStatsAndLog_LinkLabelResetStats = new LocalizedKeyEnum(nameof(FormStatsAndLog_LinkLabelResetStats));

        [LocalizedKey("02b6a21c-4887-4356-86df-94f8771de461", "Open Log Dir")] // 打开日志目录
        public static readonly LocalizedKeyEnum FormStatsAndLog_ButtonOpenLogDir = new LocalizedKeyEnum(nameof(FormStatsAndLog_ButtonOpenLogDir));

        [LocalizedKey("9d5ea46e-76d8-4ef4-b0fd-b4494bbf9ac1", "Dir cteate or open fail")] // 目录创建或打开失败
        public static readonly LocalizedKeyEnum FormStatsAndLog_OpenLogDirFailMsg = new LocalizedKeyEnum(nameof(FormStatsAndLog_OpenLogDirFailMsg));

        //[LocalizedKey("6a8e6ea4-409d-4f3f-8efd-5ef133321286", "Logger init fail")] // 日志记录器初始化失败
        //public static readonly LocalizedKeyEnum FormStatsAndLog_LabelLogInitFail = new LocalizedKeyEnum(nameof(FormStatsAndLog_LabelLogInitFail));


        [LocalizedKey("e4886123-c46d-46ad-94c0-9c1dcfa63f99", "Translate Cache")] // 翻译缓存
        public static readonly LocalizedKeyEnum FormTranslateCache = new LocalizedKeyEnum(nameof(FormTranslateCache));

        [LocalizedKey("2522fd4f-4ec8-496c-bc2f-f8b1a706b8ec", "Cache Count")] // 缓存条数
        public static readonly LocalizedKeyEnum FormTranslateCache_LabelCacheCount = new LocalizedKeyEnum(nameof(FormTranslateCache_LabelCacheCount));

        [LocalizedKey("b725027c-9b93-40e8-b315-c4cf2771a7c2", "Clean?")] // 清空？
        public static readonly LocalizedKeyEnum FormTranslateCache_LinkLabelClean = new LocalizedKeyEnum(nameof(FormTranslateCache_LinkLabelClean));

        [LocalizedKey("8aeecb5e-36f9-4546-b516-a5a620c1e412", "It cannot be restored after clearing")] // 清空后将无法恢复？
        public static readonly LocalizedKeyEnum FormTranslateCache_MessageBoxConfirmCleanTip = new LocalizedKeyEnum(nameof(FormTranslateCache_MessageBoxConfirmCleanTip));


        [LocalizedKey("877868a5-db27-45fc-b1ad-3ce6da4d0d9e", "OK")] // 确认
        public static readonly LocalizedKeyEnum Form_ButtonOK = new LocalizedKeyEnum(nameof(Form_ButtonOK));

        [LocalizedKey("0f95184c-1752-40f7-9786-d1ab711e781d", "Cancel")] // 取消
        public static readonly LocalizedKeyEnum Form_ButtonCancel = new LocalizedKeyEnum(nameof(Form_ButtonCancel));

        [LocalizedKey("8b8b544f-d639-4054-b3de-366ea201fabd", "Help")] // 帮助
        public static readonly LocalizedKeyEnum Form_ButtonHelp = new LocalizedKeyEnum(nameof(Form_ButtonHelp));


        [LocalizedKey("585eb308-fa75-4952-8889-692e54dbf0bf", "Check")] // 检测
        public static readonly LocalizedKeyEnum Form_LinkLabelCheck = new LocalizedKeyEnum(nameof(Form_LinkLabelCheck));

        [LocalizedKey("f5195f4d-e383-46cc-ae13-a2cb548b679e", "Checked Succeess !")] // 检测成功！
        public static readonly LocalizedKeyEnum Form_LabelCheckResult_CheckedSuccees = new LocalizedKeyEnum(nameof(Form_LabelCheckResult_CheckedSuccees));

        [LocalizedKey("98c68a7d-ea6a-4a0e-bb26-51ca50fb13d8", "Checked Fail !")] // 检测失败！
        public static readonly LocalizedKeyEnum Form_LabelCheckResult_CheckedFail = new LocalizedKeyEnum(nameof(Form_LabelCheckResult_CheckedFail));


        [LocalizedKey("f866ccd3-447c-47a4-aa1e-9a95b76bf22f", "Operation failed after {0} attempts.")] // 操作在 {0} 次尝试后仍失败。
        public static readonly LocalizedKeyEnum RetryHelper_Exception_AllAttemptFailMsg = new LocalizedKeyEnum(nameof(RetryHelper_Exception_AllAttemptFailMsg));

        [LocalizedKey("33399640-4007-4ca6-a89d-62e257fe1cd4", "Operation timed out in {0} ms.")] // 操作在 {0} 毫秒后超时失败。
        public static readonly LocalizedKeyEnum RetryHelper_Exception_TimeoutMsg = new LocalizedKeyEnum(nameof(RetryHelper_Exception_TimeoutMsg));

        [LocalizedKey("fafb4f94-42bd-44ad-95a4-f7e15e4bfee3", "Tags conversion failed in the translation.")] // 译文中标签转换失败。
        public static readonly LocalizedKeyEnum MultiSupplierMTSession_String2SegmentFail = new LocalizedKeyEnum(nameof(MultiSupplierMTSession_String2SegmentFail));

        [LocalizedKey("77f1e8a2-a669-409c-b0a3-6de0a29ab36a", "Request failed, and all {0} segments in the request could not be translated.")] // 请求失败，该请求中全部 {0} 个句段未能完成翻译。
        public static readonly LocalizedKeyEnum MultiSupplierMTSession_AllSegmentsTranslateFail = new LocalizedKeyEnum(nameof(MultiSupplierMTSession_AllSegmentsTranslateFail));


        [LocalizedKey("81752443-6399-441a-9243-82563c012d8f", "Aliyun")] // 阿里翻译
        public static readonly LocalizedKeyEnum FormAliyun = new LocalizedKeyEnum(nameof(FormAliyun));

        [LocalizedKey("b5661636-c435-49a7-81c6-cfd668a39e36", "Key Id")] // Key Id
        public static readonly LocalizedKeyEnum FormAliyun_LabelKeyId = new LocalizedKeyEnum(nameof(FormAliyun_LabelKeyId));

        [LocalizedKey("61ceadf9-9ab8-4158-9faa-c7068d6d893c", "Key Secret")] // Key Secret
        public static readonly LocalizedKeyEnum FormAliyun_LabelKeySecret = new LocalizedKeyEnum(nameof(FormAliyun_LabelKeySecret));

        [LocalizedKey("8e1fd442-84b4-4051-aa7e-2da7adef70c6", "Type")] // 版 本
        public static readonly LocalizedKeyEnum FormAliyun_LabelServiceType = new LocalizedKeyEnum(nameof(FormAliyun_LabelServiceType));

        [LocalizedKey("9ce291a1-d735-4b7b-b8a6-0a4fe9f58d27", "General")] // 普通版
        public static readonly LocalizedKeyEnum FormAliyun_RadioButtonGeneral = new LocalizedKeyEnum(nameof(FormAliyun_RadioButtonGeneral));

        [LocalizedKey("18adb34c-014b-44fb-b7a7-86e7f90572f7", "Professional")] // 专业版
        public static readonly LocalizedKeyEnum FormAliyun_RadioButtonProfessional = new LocalizedKeyEnum(nameof(FormAliyun_RadioButtonProfessional));


        [LocalizedKey("02dbdf25-02a9-4cd3-8a8e-d54290fa2fe6", "Baidu")] // 百度翻译
        public static readonly LocalizedKeyEnum FormBaidu = new LocalizedKeyEnum(nameof(FormBaidu));

        [LocalizedKey("362f169d-dc50-42d4-bb28-e54ced53ea5b", "App Id")] // App Id
        public static readonly LocalizedKeyEnum FormBaidu_LabelAppId = new LocalizedKeyEnum(nameof(FormBaidu_LabelAppId));

        [LocalizedKey("865a1c4e-4701-47d3-9b26-f88a76c8bc02", "App Key")] // App Key
        public static readonly LocalizedKeyEnum FormBaidu_LabelAppKey = new LocalizedKeyEnum(nameof(FormBaidu_LabelAppKey));


        [LocalizedKey("44835cf9-2e46-401b-aafb-380bfa0b45c4", "Tencent")] // 腾讯翻译
        public static readonly LocalizedKeyEnum FormTencent = new LocalizedKeyEnum(nameof(FormTencent));

        [LocalizedKey("3b683478-2921-4ae5-89a4-ff32d98bfd57", "Secret Id")] // Secret Id
        public static readonly LocalizedKeyEnum FormTencent_LabelSecretId = new LocalizedKeyEnum(nameof(FormTencent_LabelSecretId));

        [LocalizedKey("73ce8a1b-a18a-4ba6-b0da-e0f9dc61a31b", "Secret Key")] // Secret Key
        public static readonly LocalizedKeyEnum FormTencent_LabelSecretKey = new LocalizedKeyEnum(nameof(FormTencent_LabelSecretKey));


        [LocalizedKey("d4682b5e-a68b-49bb-9811-4d0138c0b50a", "Huoshan")] // 火山翻译
        public static readonly LocalizedKeyEnum FormHuoshan = new LocalizedKeyEnum(nameof(FormHuoshan));

        [LocalizedKey("134a02b6-6c85-4425-981c-36f0dd5e121f", "Access Key")] // Access Key
        public static readonly LocalizedKeyEnum FormHuoshan_LabelAccessKey = new LocalizedKeyEnum(nameof(FormHuoshan_LabelAccessKey));

        [LocalizedKey("6961769b-5c4f-4166-ad37-ea1f3fa756b7", "Secret Key")] // Secret Key
        public static readonly LocalizedKeyEnum FormHuoshan_LabelSecretKey = new LocalizedKeyEnum(nameof(FormHuoshan_LabelSecretKey));


        [LocalizedKey("9141043a-d8df-4ca0-95aa-a941c7fcff03", "Caiyun")] // 彩云翻译
        public static readonly LocalizedKeyEnum FormCaiyun = new LocalizedKeyEnum(nameof(FormCaiyun));

        [LocalizedKey("3907107c-22eb-4572-b41f-1ace9ce191b4", "Token")] // Token
        public static readonly LocalizedKeyEnum FormCaiyun_LabelToken = new LocalizedKeyEnum(nameof(FormCaiyun_LabelToken));


        [LocalizedKey("8ca6b805-41fe-4830-8d5b-e16673d712b5", "Niutrans")] // 小牛翻译
        public static readonly LocalizedKeyEnum FormNiutrans = new LocalizedKeyEnum(nameof(FormNiutrans));

        [LocalizedKey("8cd43629-c5ba-4cba-8949-2c7824e246df", "Api Key")] // Api Key
        public static readonly LocalizedKeyEnum FormNiutrans_LabelApikey = new LocalizedKeyEnum(nameof(FormNiutrans_LabelApikey));


        [LocalizedKey("65cfa610-5c9e-4fc0-acc9-e67e271adbcb", "Youdao")] // 有道翻译
        public static readonly LocalizedKeyEnum FormYoudao = new LocalizedKeyEnum(nameof(FormYoudao));

        [LocalizedKey("4dcdcb0b-f653-4349-b9af-7314712da29c", "App Key")] // App Key
        public static readonly LocalizedKeyEnum FormYoudao_LabelAppKey = new LocalizedKeyEnum(nameof(FormYoudao_LabelAppKey));

        [LocalizedKey("ae384aee-4b30-4544-a587-c3669e8dddae", "App Secret")] // App Secret
        public static readonly LocalizedKeyEnum FormYoudao_LabelAppSecret = new LocalizedKeyEnum(nameof(FormYoudao_LabelAppSecret));


        [LocalizedKey("a89e15a0-c08f-47a0-a517-be32d5200068", "Xunfei")] // 讯飞翻译
        public static readonly LocalizedKeyEnum FormXunfei = new LocalizedKeyEnum(nameof(FormXunfei));

        [LocalizedKey("099c2f58-da48-48b4-af32-91e172fc0709", "Api Id")] // Api Id
        public static readonly LocalizedKeyEnum FormXunfei_LabelApiId = new LocalizedKeyEnum(nameof(FormXunfei_LabelApiId));

        [LocalizedKey("9a1ae0fa-1be3-4cf9-95d2-7d4f1337d2d4", "Api Key")] // Api Key
        public static readonly LocalizedKeyEnum FormXunfei_LabelApiKey = new LocalizedKeyEnum(nameof(FormXunfei_LabelApiKey));

        [LocalizedKey("ff38c851-5663-4b7d-8c85-4bea0ce0b058", "Api Secret")] // Api Secret
        public static readonly LocalizedKeyEnum FormXunfei_LabelApiSecret = new LocalizedKeyEnum(nameof(FormXunfei_LabelApiSecret));


        [LocalizedKey("07a89e6b-7ae9-4dab-8c63-d78fc747ea82", "OpenAI GPT")] // OpenAI GPT
        public static readonly LocalizedKeyEnum FormOpenai = new LocalizedKeyEnum(nameof(FormOpenai));

        [LocalizedKey("300fc67c-0b73-42e1-8e5f-6594aaf0ab8f", "Base Url")] // Base Url
        public static readonly LocalizedKeyEnum FormOpenai_LabelBaseUrl = new LocalizedKeyEnum(nameof(FormOpenai_LabelBaseUrl));

        [LocalizedKey("42bbc36b-7616-45cb-ae8b-fa2575d11849", "Path")] // Path
        public static readonly LocalizedKeyEnum FormOpenai_LabelPath = new LocalizedKeyEnum(nameof(FormOpenai_LabelPath));

        [LocalizedKey("f8289042-679e-4a55-aa7c-a0c00ee640a0", "Model")] // Model
        public static readonly LocalizedKeyEnum FormOpenai_LabelModel = new LocalizedKeyEnum(nameof(FormOpenai_LabelModel));

        [LocalizedKey("8793bde6-cdf1-4fca-a7db-2d42251c4097", "Temperature")] // Temperature
        public static readonly LocalizedKeyEnum FormOpenai_LabelTemperature = new LocalizedKeyEnum(nameof(FormOpenai_LabelTemperature));

        [LocalizedKey("ab51f3ef-e791-48db-aba8-37c9435d7396", "Api Key")] // Api Key
        public static readonly LocalizedKeyEnum FormOpenai_LabelApiKey = new LocalizedKeyEnum(nameof(FormOpenai_LabelApiKey));

        [LocalizedKey("87136671-38b8-41d0-8e9b-5151282e2cc3", "Org(optional)")] // Org(optional)
        public static readonly LocalizedKeyEnum FormOpenai_LabelOrganization = new LocalizedKeyEnum(nameof(FormOpenai_LabelOrganization));

        [LocalizedKey("8b08223d-ff3a-4618-8f53-70d3abfe899e", "Prompt")] // Prompt
        public static readonly LocalizedKeyEnum FormOpenai_LabelPrompt = new LocalizedKeyEnum(nameof(FormOpenai_LabelPrompt));


        [LocalizedKey("76845133-ca2a-4cd5-a5a2-3218e656b381", "Papago")] // Papago 翻译
        public static readonly LocalizedKeyEnum FormPapago = new LocalizedKeyEnum(nameof(FormPapago));

        [LocalizedKey("445a5731-6292-4d94-9b54-a7bf456058c2", "Client ID")] // Client ID
        public static readonly LocalizedKeyEnum FormPapago_LabelClientID = new LocalizedKeyEnum(nameof(FormPapago_LabelClientID));

        [LocalizedKey("f66898c7-cc1c-4b2d-9a46-ce31c53dff2f", "Client Secret")] // Client Secret
        public static readonly LocalizedKeyEnum FormPapago_LabelClientSecret = new LocalizedKeyEnum(nameof(FormPapago_LabelClientSecret));
    }
}
