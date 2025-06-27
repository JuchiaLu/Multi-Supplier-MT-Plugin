namespace MultiSupplierMTPlugin.Localized
{
    // TODO：除了不可避免的动态值（时间日期、用户输入等）外，最好不要使用插值，这不利于理解且不利于批量翻译

    class LocalizedKeyCommon : LocalizedKeyBase
    {
        public LocalizedKeyCommon(string name) : base(name) 
        {
        }

        static LocalizedKeyCommon()
        {
            AutoInit<LocalizedKeyCommon>();
        }


        #region 服务提供商名字相关
        [LocalizedValue("b64120c0-8871-4a27-845d-cca22d4a0262", " (Built In)", "（内置）")]
        public static LocalizedKeyCommon ProviderType_BuiltIn { get; private set; }

        [LocalizedValue("9972438f-b4cc-4ab5-a01e-7603cb56d2ce", " (Need Config)", "（需配置）")]
        public static LocalizedKeyCommon ProviderType_NeedConfig { get; private set; }

        [LocalizedValue("cf243806-c8a3-4120-ae94-c4495a7b1ff9", "NMT", "传统翻译")]
        public static LocalizedKeyCommon ProviderType_NMT { get; private set; }

        [LocalizedValue("c7ac5607-a8bc-4367-a681-e02441d4017e", "LLM", "大语言模型")]
        public static LocalizedKeyCommon ProviderType_LLM { get; private set; }       
        

        [LocalizedValue("167c4588-e75f-440e-8948-9baab3d30199", "Microsoft", "Microsoft")]
        public static LocalizedKeyCommon Provider_Microsoft_BuiltIn { get; private set; }

        [LocalizedValue("7259d737-eca2-4e08-8f05-7ca50bb2a056", "Google", "Google")]
        public static LocalizedKeyCommon Provider_Google_BuiltIn { get; private set; }

        [LocalizedValue("68f20413-9b96-4f29-9f91-4465c3a246a9", "DeepL", "DeepL")]
        public static LocalizedKeyCommon Provider_DeepL_BuiltIn { get; private set; }

        [LocalizedValue("1d684418-58fa-4c85-b40a-1b4cf327c63e", "Lingvanex", "Lingvanex")]
        public static LocalizedKeyCommon Provider_Lingvanex_BuiltIn { get; private set; }

        [LocalizedValue("117446d0-394d-4a30-ab9d-e60f378b3178", "Yandex", "Yandex")]
        public static LocalizedKeyCommon Provider_Yandex_BuiltIn { get; private set; }

        [LocalizedValue("60817a4f-969d-40a5-a150-638d82e7f14b", "Modernmt", "Modernmt")]
        public static LocalizedKeyCommon Provider_Modernmt_BuiltIn { get; private set; }


        [LocalizedValue("10a4fe53-0ce6-4943-8593-2f7c6bcca77a", "Baidu", "百度")]
        public static LocalizedKeyCommon Provider_Baidu { get; private set; }

        [LocalizedValue("bebacba9-8a50-4039-a8a2-80b28772e8ca", "Tencent", "腾讯")]
        public static LocalizedKeyCommon Provider_Tencent { get; private set; }

        [LocalizedValue("a3700cd7-ce8d-4eb6-bf72-dfb8c0a8fc25", "Aliyun", "阿里")]
        public static LocalizedKeyCommon Provider_Aliyun { get; private set; }

        [LocalizedValue("3e2dfcbe-645b-4c7d-aef6-f3483ee97110", "Huoshan", "火山")]
        public static LocalizedKeyCommon Provider_Huoshan { get; private set; }

        [LocalizedValue("c1f403bd-c452-4ef1-ada7-6bc70f4f68ce", "Caiyun", "彩云")]
        public static LocalizedKeyCommon Provider_Caiyun { get; private set; }

        [LocalizedValue("44230611-1c83-4e2b-b13a-23b01dca3d69", "Niutrans", "小牛")]
        public static LocalizedKeyCommon Provider_Niutrans { get; private set; }

        [LocalizedValue("8bedbcea-d908-4fe6-ae86-03e25c0a558b", "Youdao", "有道")]
        public static LocalizedKeyCommon Provider_Youdao { get; private set; }

        [LocalizedValue("a00b8e13-dd40-4133-8725-61c32750b034", "Xunfei", "讯飞")]
        public static LocalizedKeyCommon Provider_Xunfei { get; private set; }


        [LocalizedValue("3c815cd6-9f40-41e9-aef4-36153af826ca", "Papago", "Papago")]
        public static LocalizedKeyCommon Provider_Papago { get; private set; }

        [LocalizedValue("117446d0-394d-4a30-ab9d-e60f378b3178", "Yandex", "Yandex")]
        public static LocalizedKeyCommon Provider_Yandex { get; private set; }

        [LocalizedValue("345b96ea-5997-4d47-b991-c4310be2174b", "DeepL", "DeepL")]
        public static LocalizedKeyCommon Provider_DeepL { get; private set; }

        [LocalizedValue("d73149ce-2111-4d35-b372-3aba6555bf7e", "DeepLX", "DeepLX")]
        public static LocalizedKeyCommon Provider_DeepLX { get; private set; }


        [LocalizedValue("29d3573d-247b-43a3-b8ad-4dee62f65f90", "Aliyun", "阿里百炼")]
        public static LocalizedKeyCommon Provider_Aliyun_LLM { get; private set; }

        [LocalizedValue("9ca553e8-6437-4e39-b0c7-49a4c5f2737c", "Tencent", "腾讯混元")]
        public static LocalizedKeyCommon Provider_Tencent_LLM { get; private set; }

        [LocalizedValue("10148bd0-1fa5-4443-89a4-f6823f68f99c", "Baidu", "百度千帆")]
        public static LocalizedKeyCommon Provider_Baidu_LLM { get; private set; }

        [LocalizedValue("881e9305-6e3c-4850-8758-602c08932fa5", "ByteDance", "字节火山")]
        public static LocalizedKeyCommon Provider_ByteDance_LLM { get; private set; }

        [LocalizedValue("869e6896-d7df-4bf9-be98-ff5466d1a9ef", "Xunfei", "讯飞星火")]
        public static LocalizedKeyCommon Provider_Xunfei_LLM { get; private set; }

        [LocalizedValue("26d524a8-cc84-452c-ad71-f96f87aae514", "DeepSeek", "深度求索")]
        public static LocalizedKeyCommon Provider_DeepSeek_LLM { get; private set; }

        [LocalizedValue("5be602bb-adc2-47ee-8ec3-9628383b93a1", "Zhipu", "智谱清言")]
        public static LocalizedKeyCommon Provider_Zhipu_LLM { get; private set; }

        [LocalizedValue("bd0a3c1c-0c43-4d94-84e6-963ac4d63545", "Stepfun", "阶跃星辰")]
        public static LocalizedKeyCommon Provider_Stepfun_LLM { get; private set; }

        [LocalizedValue("6595d25a-2322-495f-a830-62fdd2afa63b", "Moonshot", "月之暗面")]
        public static LocalizedKeyCommon Provider_Moonshot_LLM { get; private set; }

        [LocalizedValue("593b503b-54f3-4e69-a516-041044d0833d", "Baichuan", "百川智能")]
        public static LocalizedKeyCommon Provider_Baichuan_LLM { get; private set; }

        [LocalizedValue("c0a9fbc4-8c74-4dec-919c-1033a1e83f84", "Minimax", "稀宇科技")]
        public static LocalizedKeyCommon Provider_Minimax_LLM { get; private set; }

        [LocalizedValue("be37c53f-5138-4df2-8982-c4e672f31400", "Sensetime", "商汤科技")]
        public static LocalizedKeyCommon Provider_Sensetime_LLM { get; private set; }

        [LocalizedValue("8b6fc269-b1c6-4061-a925-57ab45fce47c", "Lingyiwanwu", "零一万物")]
        public static LocalizedKeyCommon Provider_Lingyiwanwu_LLM { get; private set; }

        [LocalizedValue("2a45a308-533e-4862-bfa4-60ce3bf81fa3", "InternAI", "书生浦语")]
        public static LocalizedKeyCommon Provider_InternAI_LLM { get; private set; }

        [LocalizedValue("37134dd8-cd92-453d-b13b-c32ff3e8ab8d", "Infly", "无限光年")]
        public static LocalizedKeyCommon Provider_Infly_LLM { get; private set; }

        [LocalizedValue("da67023a-ab27-4160-8349-00614f0c8752", "360", "智脑 360")]
        public static LocalizedKeyCommon Provider_Zhinao360_LLM { get; private set; }


        [LocalizedValue("32962ba1-a286-43f5-9123-fb77d022596e", "OpenAI", "OpenAI")]
        public static LocalizedKeyCommon Provider_OpenAI_LLM { get; private set; }

        [LocalizedValue("036a1ca9-6a92-4ca2-99f1-1834b67beb81", "Anthropic", "Anthropic")]
        public static LocalizedKeyCommon Provider_Anthropic_LLM { get; private set; }

        [LocalizedValue("4ac77667-e667-4886-abd0-a1dca944da13", "Google", "Google")]
        public static LocalizedKeyCommon Provider_Google_LLM { get; private set; }

        [LocalizedValue("f4a00b4b-8859-444b-a0ac-0820c2e0e903", "xAI", "xAI")]
        public static LocalizedKeyCommon Provider_xAI_LLM { get; private set; }

        [LocalizedValue("e2bef79d-00da-4499-bdaa-0f4f488cceea", "Mistral", "Mistral")]
        public static LocalizedKeyCommon Provider_Mistral_LLM { get; private set; }

        [LocalizedValue("e2df9ff6-05ce-457d-8401-b3c200768a0b", "Cohere", "Cohere")]
        public static LocalizedKeyCommon Provider_Cohere_LLM { get; private set; }

        [LocalizedValue("8c0b784e-efcf-45de-8b7f-c66ef6d82a9b", "Upstage", "Upstage")]
        public static LocalizedKeyCommon Provider_Upstage_LLM { get; private set; }

        [LocalizedValue("4347a1b3-5991-43ab-88a7-6428a3f10494", "Perplexity", "Perplexity")]
        public static LocalizedKeyCommon Provider_Perplexity_LLM { get; private set; }

        [LocalizedValue("325c9ca4-b467-460c-a1d6-4aba7f962371", "Liquid", "Liquid")]
        public static LocalizedKeyCommon Provider_Liquid_LLM { get; private set; }

        [LocalizedValue("7052fe37-9cb8-4a28-a6d1-d42cf2245884", "AionLabs", "AionLabs")]
        public static LocalizedKeyCommon Provider_AionLabs_LLM { get; private set; }

        [LocalizedValue("ee81ac5f-069e-4957-ad80-11bb8acbd982", "InceptionLabs", "InceptionLabs")]
        public static LocalizedKeyCommon Provider_InceptionLabs_LLM { get; private set; }

        [LocalizedValue("2609a61d-78a8-4122-a246-2ba86c05ed3a", "Azure", "Azure")]
        public static LocalizedKeyCommon Provider_Azure_LLM { get; private set; }

        [LocalizedValue("e795cebf-5a85-46f5-ad29-fdfc2559f2b7", "Amazon", "Amazon")]
        public static LocalizedKeyCommon Provider_Amazon_LLM { get; private set; }

        [LocalizedValue("c6e77301-f6a4-463f-85aa-52cbe8975817", "Cloudflare", "Cloudflare")]
        public static LocalizedKeyCommon Provider_Cloudflare_LLM { get; private set; }

        [LocalizedValue("6e03d08a-b867-42c5-aa22-18cda7dad80d", "Nvidia", "Nvidia")]
        public static LocalizedKeyCommon Provider_Nvidia_LLM { get; private set; }

        [LocalizedValue("c6f7443a-bb7f-4d9a-ba83-13090e31d20e", "OpenRouter", "OpenRouter")]
        public static LocalizedKeyCommon Provider_OpenRouter_LLM { get; private set; }

        [LocalizedValue("647a4db5-1435-430b-a064-c61c9cf71fc6", "Siliconflow", "硅基流动")]
        public static LocalizedKeyCommon Provider_Siliconflow_LLM { get; private set; }

        [LocalizedValue("c6a4113a-b59d-4f47-8535-f18b60f1816c", "InfiniAI", "无问芯穹")]
        public static LocalizedKeyCommon Provider_InfiniAI_LLM { get; private set; }

        [LocalizedValue("40afc153-ae08-41fa-9aac-a2a357d0b5b8", "AIMLApi", "AIMLApi")]
        public static LocalizedKeyCommon Provider_AIMLApi_LLM { get; private set; }

        [LocalizedValue("3d6f0230-e533-43bd-9eb3-325d86c2e4a2", "Fireworks", "Fireworks")]
        public static LocalizedKeyCommon Provider_Fireworks_LLM { get; private set; }

        [LocalizedValue("971d1ff1-2c1d-49ff-8929-34cb7f7e76c8", "Deepinfra", "Deepinfra")]
        public static LocalizedKeyCommon Provider_Deepinfra_LLM { get; private set; }

        [LocalizedValue("817844a9-4e7d-44b1-bfe9-b3d9e5a7b05b", "Targon", "Targon")]
        public static LocalizedKeyCommon Provider_Targon_LLM { get; private set; }

        [LocalizedValue("f6b2607d-2659-488f-96d4-53f37902b0de", "Friendli", "Friendli")]
        public static LocalizedKeyCommon Provider_Friendli_LLM { get; private set; }

        [LocalizedValue("9478830a-60ee-44d1-a93e-007ea760518a", "Groq", "Groq")]
        public static LocalizedKeyCommon Provider_Groq_LLM { get; private set; }

        [LocalizedValue("cb0368a2-b604-4892-b18d-05bb61852251", "Together", "Together")]
        public static LocalizedKeyCommon Provider_Together_LLM { get; private set; }

        [LocalizedValue("10d14582-ae96-45c1-b9b4-9bd094a40b56", "Tasking", "Tasking")]
        public static LocalizedKeyCommon Provider_Tasking_LLM { get; private set; }

        [LocalizedValue("30986a9b-577d-45e0-b288-34d88b86f126", "Infermatic", "Infermatic")]
        public static LocalizedKeyCommon Provider_Infermatic_LLM { get; private set; }

        [LocalizedValue("d382fdc2-8962-4f47-a790-dff4ec058254", "CentML", "CentML")]
        public static LocalizedKeyCommon Provider_CentML_LLM { get; private set; }

        [LocalizedValue("f883333d-9c5d-4669-b074-eac00f26dc37", "Nebius", "Nebius")]
        public static LocalizedKeyCommon Provider_Nebius_LLM { get; private set; }

        [LocalizedValue("935a345c-eb59-4f24-b4e2-6712d15db278", "Novita", "Novita")]
        public static LocalizedKeyCommon Provider_Novita_LLM { get; private set; }

        [LocalizedValue("b55df2a6-2ca2-484b-af71-30247bababb1", "Opper", "Opper")]
        public static LocalizedKeyCommon Provider_Opper_LLM { get; private set; }

        [LocalizedValue("db2055ee-5f4a-4ad0-a3da-067def3ea278", "Kluster", "Kluster")]
        public static LocalizedKeyCommon Provider_Kluster_LLM { get; private set; }

        [LocalizedValue("7b096c7e-5f3f-439b-a888-f1155295897c", "OVHCloud", "OVHCloud")]
        public static LocalizedKeyCommon Provider_OVHCloud_LLM { get; private set; }

        [LocalizedValue("7c6033b0-e412-4bdb-b70c-031f36f99cfe", "Scaleway", "Scaleway")]
        public static LocalizedKeyCommon Provider_Scaleway_LLM { get; private set; }

        [LocalizedValue("858c5301-e049-4994-8240-ce1305a7719c", "TaamCloud", "TaamCloud")]
        public static LocalizedKeyCommon Provider_TaamCloud_LLM { get; private set; }

        [LocalizedValue("71a5ea90-56af-48e4-bf17-1e24fc8d9c73", "Sambanova", "Sambanova")]
        public static LocalizedKeyCommon Provider_Sambanova_LLM { get; private set; }

        [LocalizedValue("5e162c88-821c-4004-ba59-2b15aa5fbea6", "GMICloud", "GMICloud")]
        public static LocalizedKeyCommon Provider_GMICloud_LLM { get; private set; }

        [LocalizedValue("2fc062a9-31db-4052-8b42-823469ec5fa2", "InferenceNet", "InferenceNet")]
        public static LocalizedKeyCommon Provider_InferenceNet_LLM { get; private set; }

        [LocalizedValue("f0d12c2c-7554-4b5c-a60a-09b52b4f7451", "nCompass", "nCompass")]
        public static LocalizedKeyCommon Provider_nCompass_LLM { get; private set; }

        [LocalizedValue("c0faedf5-7a04-4dd7-88e5-e334274679b7", "Nextbit256", "Nextbit256")]
        public static LocalizedKeyCommon Provider_Nextbit256_LLM { get; private set; }

        [LocalizedValue("e029e24b-f90c-4c6a-a93f-001bbde2621f", "Parasail", "Parasail")]
        public static LocalizedKeyCommon Provider_Parasail_LLM { get; private set; }

        [LocalizedValue("a68d95f9-5368-49e3-b6fc-dd97d69bd7ef", "Ubicloud", "Ubicloud")]
        public static LocalizedKeyCommon Provider_Ubicloud_LLM { get; private set; }

        [LocalizedValue("699d3f1c-0553-49aa-b244-f984c5f41e35", "FunctionNetwork", "FunctionNetwork")]
        public static LocalizedKeyCommon Provider_FunctionNetwork_LLM { get; private set; }

        [LocalizedValue("037de9bb-55c2-44bf-aab3-636876007e4e", "Venice", "Venice")]
        public static LocalizedKeyCommon Provider_Venice_LLM { get; private set; }

        [LocalizedValue("4e4ea810-630e-4e42-8ee8-4c828c7eb7f1", "Ionos", "Ionos")]
        public static LocalizedKeyCommon Provider_Ionos_LLM { get; private set; }

        [LocalizedValue("80c5e619-d5c6-45b5-bc5d-eb05e2cfaa0f", "Hyperbolic", "Hyperbolic")]
        public static LocalizedKeyCommon Provider_Hyperbolic_LLM { get; private set; }

        [LocalizedValue("3cea1eac-4144-44f5-a672-0328bdb8be46", "Lepton", "Lepton")]
        public static LocalizedKeyCommon Provider_Lepton_LLM { get; private set; }

        [LocalizedValue("6b70d1b7-e96c-472f-809f-6ff7051db18e", "Lambda", "Lambda")]
        public static LocalizedKeyCommon Provider_Lambda_LLM { get; private set; }

        [LocalizedValue("d160bdc8-be2f-441e-a307-04dba4ffd36e", "Galadriel", "Galadriel")]
        public static LocalizedKeyCommon Provider_Galadriel_LLM { get; private set; }

        [LocalizedValue("d7e87fb2-0e65-45a6-a11b-8cdae5abacd3", "LlamaFamily", "LlamaFamily")]
        public static LocalizedKeyCommon Provider_LlamaFamily_LLM { get; private set; }

        [LocalizedValue("8d22f7e8-0b31-4cd5-a6a5-c3befca75038", "PhalaNetwork", "PhalaNetwork")]
        public static LocalizedKeyCommon Provider_PhalaNetwork_LLM { get; private set; }

        [LocalizedValue("f2c29fa2-5648-4272-b4d0-4380aed12218", "Enfer", "Enfer")]
        public static LocalizedKeyCommon Provider_Enfer_LLM { get; private set; }

        [LocalizedValue("ecb68e52-4eb0-4c32-bc12-183014f16242", "Crusoe", "Crusoe")]
        public static LocalizedKeyCommon Provider_Crusoe_LLM { get; private set; }

        [LocalizedValue("c8c1b723-6858-4b55-9e7c-8db3896d0752", "Avian", "Avian")]
        public static LocalizedKeyCommon Provider_Avian_LLM { get; private set; }

        [LocalizedValue("86679674-daeb-40e0-866c-db3edc5000eb", "Cerebras", "Cerebras")]
        public static LocalizedKeyCommon Provider_Cerebras_LLM { get; private set; }

        [LocalizedValue("c76694ea-76fe-4d96-ae36-dfa63fd0e6fe", "AlephAlpha", "AlephAlpha")]
        public static LocalizedKeyCommon Provider_AlephAlpha_LLM { get; private set; }

        [LocalizedValue("f0e3f42f-c0a2-4bad-af0c-360e49109eae", "Anyscale", "Anyscale")]
        public static LocalizedKeyCommon Provider_Anyscale_LLM { get; private set; }

        [LocalizedValue("6697f0d5-7620-4451-ada6-f67e1b830913", "AtomaNetwork", "AtomaNetwork")]
        public static LocalizedKeyCommon Provider_AtomaNetwork_LLM { get; private set; }

        [LocalizedValue("ca25dcf6-8070-4de8-a71b-8c6bebd9440b", "Distribute", "Distribute")]
        public static LocalizedKeyCommon Provider_Distribute_LLM { get; private set; }

        [LocalizedValue("e78b49e4-a9ce-40a2-9280-729d67a0cb66", "Runpod", "Runpod")]
        public static LocalizedKeyCommon Provider_Runpod_LLM { get; private set; }

        [LocalizedValue("87eec76c-06bf-4690-9b1b-c3c0f8e95dd8", "VlmRun", "VlmRun")]
        public static LocalizedKeyCommon Provider_VlmRun_LLM { get; private set; }

        [LocalizedValue("184facfa-f2fd-44f1-b0bf-3e50fc243905", "OneAPI", "OneAPI")]
        public static LocalizedKeyCommon Provider_OneAPI_LLM { get; private set; }

        [LocalizedValue("a9ad43ea-93bb-4a34-b1f9-b946e4cb1762", "NewAPI", "NewAPI")]
        public static LocalizedKeyCommon Provider_NewAPI_LLM { get; private set; }

        [LocalizedValue("83c2e323-f228-4ad6-89ec-a736015985eb", "OneHub", "OneHub")]
        public static LocalizedKeyCommon Provider_OneHub_LLM { get; private set; }

        [LocalizedValue("e138bf67-db24-4096-af16-99b852bd8848", "SimpleOneAPI", "SimpleOneAPI")]
        public static LocalizedKeyCommon Provider_SimpleOneAPI_LLM { get; private set; }

        [LocalizedValue("d7917f49-087c-4d5e-aa59-64f9dffd5958", "VoAPI", "VoAPI")]
        public static LocalizedKeyCommon Provider_VoAPI_LLM { get; private set; }

        [LocalizedValue("914c8f32-5927-4814-896d-b1c05d0e69df", "LiteLLM", "LiteLLM")]
        public static LocalizedKeyCommon Provider_LiteLLM_LLM { get; private set; }

        [LocalizedValue("484fae2c-447e-426c-9a80-d166d1998d18", "UniAPI", "UniAPI")]
        public static LocalizedKeyCommon Provider_UniAPI_LLM { get; private set; }

        [LocalizedValue("85a13bb5-33e1-4e0a-be88-8a0956d3d77d", "Ollama", "Ollama")]
        public static LocalizedKeyCommon Provider_Ollama_LLM { get; private set; }

        [LocalizedValue("6ecf24d4-f67d-4d27-bde5-42a2a5552605", "vLLM", "vLLM")]
        public static LocalizedKeyCommon Provider_vLLM_LLM { get; private set; }

        [LocalizedValue("1e30703a-1180-4455-b523-0658207189b2", "LlamaCpp", "LlamaCpp")]
        public static LocalizedKeyCommon Provider_LlamaCpp_LLM { get; private set; }

        [LocalizedValue("3f039292-b394-4e08-951a-9608a3b92ff9", "LMStudio", "LMStudio")]
        public static LocalizedKeyCommon Provider_LMStudio_LLM { get; private set; }

        #endregion



        [LocalizedValue("f866ccd3-447c-47a4-aa1e-9a95b76bf22f", "Operation failed after {0} attempts", "操作在 {0} 次尝试后失败")]
        public static LocalizedKeyCommon RetryHelper_Exception_AllAttemptFailMsg { get; private set; }

        [LocalizedValue("33399640-4007-4ca6-a89d-62e257fe1cd4", "Operation timed out in {0} ms", "操作在 {0} 毫秒后超时失败")]
        public static LocalizedKeyCommon RetryHelper_Exception_TimeoutMsg { get; private set; }


        [LocalizedValue("fafb4f94-42bd-44ad-95a4-f7e15e4bfee3", "Tags conversion failed in the translation", "译文中标签转换失败")]
        public static LocalizedKeyCommon MultiSupplierMTSession_String2SegmentFail { get; private set; }

        [LocalizedValue("77f1e8a2-a669-409c-b0a3-6de0a29ab36a", "Request failed, and all segments({0} segments) in the request could not be translated", "请求失败，该请求中全部句段（共 {0} 个）未能完成翻译")]
        public static LocalizedKeyCommon MultiSupplierMTSession_AllSegmentsTranslateFail { get; private set; }


        [LocalizedValue("877868a5-db27-45fc-b1ad-3ce6da4d0d9e", "OK", "确认")]
        public static LocalizedKeyCommon ButtonOK { get; private set; }

        [LocalizedValue("0f95184c-1752-40f7-9786-d1ab711e781d", "Cancel", "取消")]
        public static LocalizedKeyCommon ButtonCancel { get; private set; }

        [LocalizedValue("8b8b544f-d639-4054-b3de-366ea201fabd", "Help", "帮助")]
        public static LocalizedKeyCommon ButtonHelp { get; private set; }

        [LocalizedValue("2092c2ff-c7b9-4cfb-8f44-28e748b8bc5b", "Github", "Github")]
        public static LocalizedKeyCommon ButtonGithub { get; private set; }


        [LocalizedValue("10d1547b-50ea-4f47-88e1-bf901cb4a5b7", "Zero means no limit", "零代表不限制")]
        public static LocalizedKeyCommon ZeroIndicatesNoLimit { get; private set; }

        [LocalizedValue("0c986870-a920-4199-8508-711bf376045c", "(optional)", "（可选）")]
        public static LocalizedKeyCommon Textbox_OptionalTip { get; private set; }

        [LocalizedValue("fc5a8237-ff33-48ac-b121-1534859b719f", "The glossary file must be UTF-8 encoded, \r\nwith the following default column headers in order: \r\nSourceTerm, TargetTerm, SourceLanguage, TargetLanguage", "术语文件的编码格式必须为 UTF-8，默认的列名和顺序为：\r\nSourceTerm, TargetTerm, SourceLanguage, TargetLanguage")]
        public static LocalizedKeyCommon GlossaryFileFormatTip { get; private set; }

        [LocalizedValue("a7570773-8c0a-46fd-840c-1bd48323d374", "All available placeholders for prompts (right-click to insert):\r\n\r\n{{{{source-language}}}}, {{{{target-language}}}}\r\nRestrictions: None\r\n\r\n{{{{source-text}}}}, {{{{target-text}}}}\r\nRestrictions: Requires memoQ 9.14+, Preview Helper enabled, not usable in pre-translation. (restrict target-text only)\r\n\r\n{{{{tm-source-text}}}}, {{{{tm-target-text}}}}\r\nRestrictions: Requires memoQ 10.0+, \"Send best fuzzy TM\" option enabled\r\n\r\n{{{{above-text}}}}, {{{{below-text}}}}\r\nRestrictions: Requires memoQ 9.14+, Preview Helper enabled, not usable in pre-translation\r\n\r\n{{{{summary-text}}}}, {{{{full-text}}}}\r\nRestrictions: Requires memoQ 9.14+, Preview Helper enabled\r\n\r\n{{{{glossary-text}}}}\r\nRestrictions: Glossary file must be UTF-8 encoded\r\n\r\nNotes:\r\n\r\n1. Placeholders also support ! or [] syntax to enforce non-empty values or clear associated prompts when empty.\r\n\r\n2. For batch translation, ensure the prompt includes the JSON keyword and guide the model output expected schema.\r\n\r\n3. Prioritize static placeholders (e.g., {{{{glossary-text}}}}) near the beginning of the prompt.\r\n\r\n4. Place dynamic placeholders (e.g., {{{{source-text}}}}) later in the prompt.", "提示词中全部可用占位符（可使用右键菜单插入）: \r\n\r\n语言：{{{{source-language}}}}、{{{{target-language}}}}\r\n限制：无\r\n\r\n原文、译文：{{{{source-text}}}}、{{{{target-text}}}}\r\n限制（仅译文）：需 memoQ 9.14+、需同意启用预览助手、无法在预翻译中使用\r\n\r\n翻译记忆：{{{{tm-source-text}}}}、{{{{tm-target-text}}}}\r\n限制：需 memoQ 10.0+、需开启“Send best fuzzy TM”选项\r\n\r\n上文、下文：{{{{above-text}}}}、{{{{below-text}}}}\r\n限制：需 memoQ 9.14+、需同意启用预览助手、无法在预翻译中使用\r\n\r\n摘要、全文：{{{{summary-text}}}}、{{{{full-text}}}}\r\n限制：需 memoQ 9.14+、需同意启用预览助手\r\n\r\n术语表：{{{{glossary-text}}}}\r\n限制：需术语表文件的编码格式为 UTF-8\r\n\r\n注：\r\n1. 占位符还支持 “!” 或 “[]” 语法，用于“禁止值为空”或“值为空时关联引导词也替换为空”\r\n2. 启用批量翻译时，一定要在提示词中出现 JSON 关键字，并让模型返回预期输出格式\r\n3. 优先将值不会动态改变的占位符（比如 {{{{glossary-text}}}} 等）放置到提示词靠前位置\r\n4. 其次再将值会动态改变的占位符（比如 {{{{source-text}}}} 等），放置到提示词靠后位置")]
        public static LocalizedKeyCommon ToolTip_LLMPromptTip { get; private set; }




       

        [LocalizedValue("0ea6f41c-5f2d-4dea-96f2-7c5fe5323c48", "Insert Source Language", "插入源语言")]
        public static LocalizedKeyCommon TextBoxPromptMenu_SourceLanguage { get; private set; }

        [LocalizedValue("5436d7a6-df73-4e01-8fde-436339f94e47", "Insert Target Language", "插入目标语言")]
        public static LocalizedKeyCommon TextBoxPromptMenu_TargetLanguage { get; private set; }

        [LocalizedValue("920b7f53-1499-415c-b4e5-220a005454f8", "Insert Source Text", "插入源文本")]
        public static LocalizedKeyCommon TextBoxPromptMenu_SourceText { get; private set; }

        [LocalizedValue("4e8539fc-9494-4828-946e-2e7202191096", "Insert Target Text", "插入目标文本")]
        public static LocalizedKeyCommon TextBoxPromptMenu_TargetText { get; private set; }

        [LocalizedValue("8254527b-610c-45df-81fc-b9d296a78b2b", "Insert TM Source Text", "插入源翻译记忆")]
        public static LocalizedKeyCommon TextBoxPromptMenu_TmSourceText { get; private set; }

        [LocalizedValue("2735a33e-7bf6-44f2-93a2-42b73c5ec330", "Insert TM Target Text", "插入目标翻译记忆")]
        public static LocalizedKeyCommon TextBoxPromptMenu_TmTargetText { get; private set; }

        [LocalizedValue("3a039b6e-036e-4977-b71c-98a970f4e80e", "Insert Above Text", "插入上文")]
        public static LocalizedKeyCommon TextBoxPromptMenu_AboveText { get; private set; }

        [LocalizedValue("a65981a0-0e4e-4f38-b6fd-bf1e16fd7fdf", "Insert Below Text", "插入下文")]
        public static LocalizedKeyCommon TextBoxPromptMenu_BelowText { get; private set; }

        [LocalizedValue("d14def73-78cc-4678-a8cf-23b84300c66f", "Insert Suammary Text", "插入摘要")]
        public static LocalizedKeyCommon TextBoxPromptMenu_SuammaryText { get; private set; }

        [LocalizedValue("bcd450ce-33fe-42e8-bfe9-cbe7951272f7", "Insert Full Text", "插入全文")]
        public static LocalizedKeyCommon TextBoxPromptMenu_FullText { get; private set; }

        [LocalizedValue("64facf31-a913-4749-9cc1-057f0a3a6f41", "Insert Glossary Text", "插入术语表")]
        public static LocalizedKeyCommon TextBoxPromptMenu_GlossaryText { get; private set; }
    }
}
