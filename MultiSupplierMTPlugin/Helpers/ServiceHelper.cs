using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MultiSupplierMTPlugin.Helpers
{
    static class ServiceHelper
    {
        private static readonly ConcurrentDictionary<string, byte> _lastCustomUniqueNames = new ConcurrentDictionary<string, byte>();

        private static readonly ConcurrentDictionary<string, byte> _allNames = new ConcurrentDictionary<string, byte>();
        
        private static readonly ConcurrentDictionary<string, OpenAICompatibleServiceInfo> _allInfos = new ConcurrentDictionary<string, OpenAICompatibleServiceInfo>();


        private static readonly ConcurrentDictionary<string, MultiSupplierMTService> _allServices = new ConcurrentDictionary<string, MultiSupplierMTService>();


        private static readonly object _initLock = new object();


        static ServiceHelper()
        {
            foreach (var name in ServiceNames.All)
            {
                _allNames.TryAdd(name, 0);
            }

            foreach (var kv in OpenAICompatibleServiceInfos.All)
            {
                _allInfos.TryAdd(kv.Key, kv.Value);
            }
        }


        public static void Init(OpenAICompatibleServiceInfo[] customInfos)
        {
            lock (_initLock)
            {
                foreach (var oldName in _lastCustomUniqueNames.Keys)
                {
                    _allNames.TryRemove(oldName, out _);
                    _allInfos.TryRemove(oldName, out _);
                    _allServices.TryRemove(oldName, out _);
                }
                _lastCustomUniqueNames.Clear();

                foreach (var info in customInfos)
                {
                    var uniqueName = info.UniqueName;
                    if (!_allInfos.ContainsKey(uniqueName))
                    {
                        _allNames.TryAdd(uniqueName, 0);
                        _allInfos.TryAdd(uniqueName, info);
                        _lastCustomUniqueNames.TryAdd(uniqueName, 0);
                    }
                }
            }
        }


        public static bool TryGetService(string uniqueName, out MultiSupplierMTService service)
        {
            if (uniqueName == null)
            {
                service = null;
                return false;
            }

            if (_allServices.TryGetValue(uniqueName, out service))
            {                
                return true;
            }

            if (TryCreateImplService(uniqueName, out service) || TryCreateCompatibleService(uniqueName, out service))
            {
                _allServices.TryAdd(uniqueName, service);
                return true;
            }

            service = null;
            return false;
        }

        public static MultiSupplierMTService GetServiceOrFallback(string uniqueName) 
        {
            if (TryGetService(uniqueName, out var service) || TryGetService(ServiceNames.Microsoft_BuiltIn, out service))
            { 
                return service; 
            }

            throw new InvalidOperationException("programming errors");
        }

        public static List<MultiSupplierMTService> GetAllServices()
        {
            var list = new List<MultiSupplierMTService>();
            foreach (var name in _allNames.Keys)
            {
                if (TryGetService(name, out var service))
                {
                    list.Add(service);
                }
            }
            return list;
        }


        private static bool TryCreateImplService(string uniqueName, out MultiSupplierMTService service)
        {
            if (ImplServiceFactories.All.TryGetValue(uniqueName, out var factory))
            {
                var mtOptions = OptionsHelper.MtOption;
                var providerOptions = OptionsHelper.GetProviderOptionsOrNull(uniqueName);
                service = factory(mtOptions, providerOptions);
                return true;
            }

            service = null;
            return false;
        }

        private static bool TryCreateCompatibleService(string uniqueName, out MultiSupplierMTService service)
        {
            if (_allInfos.TryGetValue(uniqueName, out var info))
            {
                var mtOptions = OptionsHelper.MtOption;
                var providerOptions = OptionsHelper.GetProviderOptionsOrNull(uniqueName);

                if (providerOptions == null)
                {
                    providerOptions = new ProviderOptions(
                        new Providers.OpenAI.GeneralSettings
                        {
                            BaseURL = info.BaseURL,
                            Path = info.Path,
                            Model = info.Model,
                        },
                        new Providers.OpenAI.SecureSettings()
                    );
                }

                service = new Providers.OpenAI.Service(mtOptions, providerOptions)
                {
                    UniqueName = uniqueName,
                    ApiKeyLink = info.ApiKeyLink,
                    ApiDocLink = info.ApiDocLink,
                    ModelsLink = info.ModelsLink,
                    BuildInModels = info.BuildInModels,
                };
                return true;
            }

            service = null;
            return false;
        }
    }


    class ServiceNames
    {
        #region const
        public const string Microsoft_BuiltIn = nameof(Microsoft_BuiltIn);
        public const string Google_BuiltIn = nameof(Google_BuiltIn);
        public const string Yandex_BuiltIn = nameof(Yandex_BuiltIn);
        public const string DeepL_BuiltIn = nameof(DeepL_BuiltIn);
        public const string Modernmt_BuiltIn = nameof(Modernmt_BuiltIn);
        public const string Lingvanex_BuiltIn = nameof(Lingvanex_BuiltIn);

        public const string Aliyun = nameof(Aliyun);
        public const string Baidu = nameof(Baidu);
        public const string Caiyun = nameof(Caiyun);
        public const string Huoshan = nameof(Huoshan);
        public const string Niutrans = nameof(Niutrans);
        public const string Tencent = nameof(Tencent);
        public const string Xunfei = nameof(Xunfei);
        public const string Youdao = nameof(Youdao);
        public const string DeepL = nameof(DeepL);
        public const string DeepLX = nameof(DeepLX);
        public const string Papago = nameof(Papago);
        public const string Yandex = nameof(Yandex);

        public const string OpenAI_LLM = nameof(OpenAI_LLM);
        public const string Anthropic_LLM = nameof(Anthropic_LLM);

        public const string Aliyun_LLM = nameof(Aliyun_LLM);
        public const string Tencent_LLM = nameof(Tencent_LLM);
        public const string Baidu_LLM = nameof(Baidu_LLM);
        public const string ByteDance_LLM = nameof(ByteDance_LLM);
        public const string Xunfei_LLM = nameof(Xunfei_LLM);
        public const string DeepSeek_LLM = nameof(DeepSeek_LLM);
        public const string Zhipu_LLM = nameof(Zhipu_LLM);
        public const string Stepfun_LLM = nameof(Stepfun_LLM);
        public const string Moonshot_LLM = nameof(Moonshot_LLM);
        public const string Baichuan_LLM = nameof(Baichuan_LLM);
        public const string Minimax_LLM = nameof(Minimax_LLM);
        public const string Sensetime_LLM = nameof(Sensetime_LLM);
        public const string Lingyiwanwu_LLM = nameof(Lingyiwanwu_LLM);
        public const string InternAI_LLM = nameof(InternAI_LLM);
        public const string Infly_LLM = nameof(Infly_LLM);
        public const string Zhinao360_LLM = nameof(Zhinao360_LLM);
        public const string Siliconflow_LLM = nameof(Siliconflow_LLM);
        public const string InfiniAI_LLM = nameof(InfiniAI_LLM);
        public const string Google_LLM = nameof(Google_LLM);
        public const string xAI_LLM = nameof(xAI_LLM);
        public const string Mistral_LLM = nameof(Mistral_LLM);
        public const string Cohere_LLM = nameof(Cohere_LLM);
        public const string Upstage_LLM = nameof(Upstage_LLM);
        public const string Perplexity_LLM = nameof(Perplexity_LLM);
        public const string Liquid_LLM = nameof(Liquid_LLM);
        public const string AionLabs_LLM = nameof(AionLabs_LLM);
        public const string InceptionLabs_LLM = nameof(InceptionLabs_LLM);
        public const string Azure_LLM = nameof(Azure_LLM);
        public const string Amazon_LLM = nameof(Amazon_LLM);
        public const string Cloudflare_LLM = nameof(Cloudflare_LLM);
        public const string Nvidia_LLM = nameof(Nvidia_LLM);
        public const string OpenRouter_LLM = nameof(OpenRouter_LLM);
        public const string AIMLApi_LLM = nameof(AIMLApi_LLM);
        public const string Fireworks_LLM = nameof(Fireworks_LLM);
        public const string Deepinfra_LLM = nameof(Deepinfra_LLM);
        public const string Targon_LLM = nameof(Targon_LLM);
        public const string Friendli_LLM = nameof(Friendli_LLM);
        public const string Groq_LLM = nameof(Groq_LLM);
        public const string Together_LLM = nameof(Together_LLM);
        public const string Tasking_LLM = nameof(Tasking_LLM);
        public const string Infermatic_LLM = nameof(Infermatic_LLM);
        public const string CentML_LLM = nameof(CentML_LLM);
        public const string Nebius_LLM = nameof(Nebius_LLM);
        public const string Novita_LLM = nameof(Novita_LLM);
        public const string Opper_LLM = nameof(Opper_LLM);
        public const string Kluster_LLM = nameof(Kluster_LLM);
        public const string OVHCloud_LLM = nameof(OVHCloud_LLM);
        public const string Scaleway_LLM = nameof(Scaleway_LLM);
        public const string TaamCloud_LLM = nameof(TaamCloud_LLM);
        public const string Sambanova_LLM = nameof(Sambanova_LLM);
        public const string GMICloud_LLM = nameof(GMICloud_LLM);
        public const string InferenceNet_LLM = nameof(InferenceNet_LLM);
        public const string nCompass_LLM = nameof(nCompass_LLM);
        public const string Nextbit256_LLM = nameof(Nextbit256_LLM);
        public const string Parasail_LLM = nameof(Parasail_LLM);
        public const string Ubicloud_LLM = nameof(Ubicloud_LLM);
        public const string FunctionNetwork_LLM = nameof(FunctionNetwork_LLM);
        public const string Venice_LLM = nameof(Venice_LLM);
        public const string Ionos_LLM = nameof(Ionos_LLM);
        public const string Hyperbolic_LLM = nameof(Hyperbolic_LLM);
        public const string Lepton_LLM = nameof(Lepton_LLM);
        public const string Lambda_LLM = nameof(Lambda_LLM);
        public const string Galadriel_LLM = nameof(Galadriel_LLM);
        public const string LlamaFamily_LLM = nameof(LlamaFamily_LLM);
        public const string PhalaNetwork_LLM = nameof(PhalaNetwork_LLM);
        public const string Enfer_LLM = nameof(Enfer_LLM);
        public const string Crusoe_LLM = nameof(Crusoe_LLM);
        public const string Avian_LLM = nameof(Avian_LLM);
        public const string Cerebras_LLM = nameof(Cerebras_LLM);
        public const string AlephAlpha_LLM = nameof(AlephAlpha_LLM);
        public const string Anyscale_LLM = nameof(Anyscale_LLM);
        public const string AtomaNetwork_LLM = nameof(AtomaNetwork_LLM);
        public const string Distribute_LLM = nameof(Distribute_LLM);
        public const string Runpod_LLM = nameof(Runpod_LLM);
        public const string VlmRun_LLM = nameof(VlmRun_LLM);
        public const string OneAPI_LLM = nameof(OneAPI_LLM);
        public const string NewAPI_LLM = nameof(NewAPI_LLM);
        public const string OneHub_LLM = nameof(OneHub_LLM);
        public const string SimpleOneAPI_LLM = nameof(SimpleOneAPI_LLM);
        public const string VoAPI_LLM = nameof(VoAPI_LLM);
        public const string LiteLLM_LLM = nameof(LiteLLM_LLM);
        public const string UniAPI_LLM = nameof(UniAPI_LLM);
        public const string Ollama_LLM = nameof(Ollama_LLM);
        public const string vLLM_LLM = nameof(vLLM_LLM);
        public const string LlamaCpp_LLM = nameof(LlamaCpp_LLM);
        public const string LMStudio_LLM = nameof(LMStudio_LLM);
        #endregion

        static ServiceNames()
        {
            All = typeof(ServiceNames).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(fi => (string)fi.GetRawConstantValue())
                .ToHashSet();
        }

        public static readonly HashSet<string> All;
    }

    class ImplServiceFactories
    {
        public static readonly Dictionary<string, Func<MultiSupplierMTOptions, ProviderOptions, MultiSupplierMTService>> All
            = new Dictionary<string, Func<MultiSupplierMTOptions, ProviderOptions, MultiSupplierMTService>>
        {
            { ServiceNames.Aliyun, (mtOption, option) => new Providers.Aliyun.Service(mtOption, option) },
            { ServiceNames.Tencent, (mtOption, option) => new Providers.Tencent.Service(mtOption, option) },
            { ServiceNames.Baidu, (mtOption, option) => new Providers.Baidu.Service(mtOption, option) },
            { ServiceNames.Huoshan, (mtOption, option) => new Providers.Huoshan.Service(mtOption, option) },
            { ServiceNames.Niutrans, (mtOption, option) => new Providers.Niutrans.Service(mtOption, option) },
            { ServiceNames.Youdao, (mtOption, option) => new Providers.Youdao.Service(mtOption, option) },
            { ServiceNames.Xunfei, (mtOption, option) => new Providers.Xunfei.Service(mtOption, option) },
            { ServiceNames.Caiyun, (mtOption, option) => new Providers.Caiyun.Service(mtOption, option) },

            { ServiceNames.Papago, (mtOption, option) => new Providers.Papago.Service(mtOption, option) },
            { ServiceNames.DeepL, (mtOption, option) => new Providers.DeepL.Service(mtOption, option) },
            { ServiceNames.DeepLX, (mtOption, option) => new Providers.DeepLX.Service(mtOption, option) },
            { ServiceNames.Yandex, (mtOption, option) => new Providers.Yandex.Service(mtOption, option) },

            { ServiceNames.Microsoft_BuiltIn, (mtOption, option) => new Providers.MicrosoftBuiltIn.Service(mtOption, option) },
            { ServiceNames.Google_BuiltIn, (mtOption, option) => new Providers.GoogleBuiltIn.Service(mtOption, option) },
            { ServiceNames.DeepL_BuiltIn, (mtOption, option) => new Providers.DeepLBuiltIn.Service(mtOption, option) },
            { ServiceNames.Yandex_BuiltIn, (mtOption, option) => new Providers.YandexBuiltIn.Service(mtOption, option) },
            { ServiceNames.Modernmt_BuiltIn, (mtOption, option) => new Providers.ModernmtBuiltIn.Service(mtOption, option) },
            { ServiceNames.Lingvanex_BuiltIn, (mtOption, option) => new Providers.LingvanexBuiltIn.Service(mtOption, option) },

            { ServiceNames.OpenAI_LLM, (mtOption, option) => new Providers.OpenAI.Service(mtOption, option) },
            { ServiceNames.Anthropic_LLM, (mtOption, option) => new Providers.Anthropic.Service(mtOption, option) },
        };
    }

    class OpenAICompatibleServiceInfos
    {
        private static ModelItem[] String2ModelItems(string[] names)
        {
            return names.Select(name => new ModelItem() { UniqueName = name, DisplayName = name }).ToArray();
        }


        public static readonly Dictionary<string, OpenAICompatibleServiceInfo> All = new Dictionary<string, OpenAICompatibleServiceInfo>()
        {
            {
                ServiceNames.Aliyun_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://dashscope.aliyuncs.com/compatible-mode/v1",
                    ModelsLink = "https://www.alibabacloud.com/help/zh/model-studio/models",
                    ApiKeyLink = "https://bailian.console.aliyun.com/?tab=model#/api-key",
                    ApiDocLink = "https://help.aliyun.com/zh/model-studio/compatibility-of-openai-with-dashscope",
                    Model = "qwen-plus",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "qwq-plus" ,
                        "qwen-max" ,
                        "qwen-plus" ,
                        "qwen-turbo" ,
                    })
                }
            },

            {
                ServiceNames.Tencent_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.hunyuan.cloud.tencent.com/v1",
                    ModelsLink = "https://hunyuan.tencent.com/modelSquare/home/list",
                    ApiKeyLink = "https://console.cloud.tencent.com/cam/capi",
                    ApiDocLink = "https://cloud.tencent.com/document/product/1729/111007",
                    Model = "Hunyuan-Translation-Lite",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "Hunyuan-T1",
                        "Hunyuan-TurboS",
                        "Hunyuan-Translation-Lite",
                    })
                }
            },

            {
                ServiceNames.Baidu_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://qianfan.baidubce.com/v2",
                    ModelsLink = "https://cloud.baidu.com/doc/WENXINWORKSHOP/s/Wm9cvy6rl",
                    ApiKeyLink = "https://console.bce.baidu.com/iam/#/iam/apikey/list",
                    ApiDocLink = "https://cloud.baidu.com/doc/qianfan-docs/s/1m9l6eex1",
                    Model = "ernie-4.0-8k",
                    BuildInModels = String2ModelItems(new string[] 
                    {
                        "ernie-4.5-turbo-128k",
                        "ernie-4.5-turbo-32k",
                        "ernie-4.5-8k-preview",
                        "ernie-4.0-8k",
                        "ernie-4.0-8k-0613",
                        "ernie-4.0-8k-latest",
                        "ernie-4.0-8k-preview",
                        "ernie-4.0-turbo-128k",
                        "ernie-4.0-turbo-8k",
                        "ernie-4.0-turbo-8k-0628",
                        "ernie-4.0-turbo-8k-0927",
                        "ernie-4.0-turbo-8k-latest",
                        "ernie-4.0-turbo-8k-preview",
                        "ernie-3.5-128k",
                        "ernie-3.5-128k-preview",
                        "ernie-3.5-8k",
                        "ernie-3.5-8k-0613",
                        "ernie-3.5-8k-0701",
                        "ernie-3.5-8k-preview",
                        "ernie-speed-128k",
                        "ernie-speed-8k",
                        "ernie-speed-pro-128k",
                        "ernie-lite-8k",
                        "ernie-lite-pro-128k",
                        "ernie-tiny-8k",
                        "qianfan-8b",
                        "qianfan-70b",
                        "qianfan-agent-intent-32k",
                        "qianfan-agent-lite-8k",
                        "qianfan-agent-speed-32k",
                        "qianfan-agent-speed-8k",
                        "qianfan-chinese-llama-2-13b",
                        "qianfan-sug-8k",
                        "deepseek-v3",
                    })
                }
            },

            {
                ServiceNames.ByteDance_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://ark.cn-beijing.volces.com/api/v3",
                    ModelsLink = "https://www.volcengine.com/docs/82379/1330310",
                    ApiKeyLink = "https://console.volcengine.com/ark/",
                    ApiDocLink = "https://www.volcengine.com/docs/82379/1330626",
                    Model = "doubao-seed-1.6-flash-250615",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "doubao-seed-1.6-250615",
                        "doubao-seed-1.6-flash-250615",
                        "deepseek-v3-250324",
                    })
                }
            },

            {
                ServiceNames.Xunfei_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://spark-api-open.xf-yun.com/v1",
                    ModelsLink = "https://www.xfyun.cn/doc/spark/HTTP%E8%B0%83%E7%94%A8%E6%96%87%E6%A1%A3.html",
                    ApiKeyLink = "https://console.xfyun.cn/services/bm35",
                    ApiDocLink = "https://www.xfyun.cn/doc/spark/HTTP%E8%B0%83%E7%94%A8%E6%96%87%E6%A1%A3.html#_7-%E4%BD%BF%E7%94%A8openai-sdk%E8%AF%B7%E6%B1%82%E7%A4%BA%E4%BE%8B",
                    Model = "generalv3",
                    BuildInModels = String2ModelItems(new string[] 
                    {
                        "4.0Ultra",
                        "generalv3.5",
                        "max-32k",
                        "generalv3",
                        "pro-128k",
                        "lite",
                    })                
                }
            },

            {
                ServiceNames.DeepSeek_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.deepseek.com/v1",
                    ModelsLink = "https://api-docs.deepseek.com/quick_start/pricing",
                    ApiKeyLink = "https://platform.deepseek.com/api_keys",
                    ApiDocLink = "https://api-docs.deepseek.com/zh-cn/",
                    Model = "deepseek-chat",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "deepseek-chat",
                        "deepseek-reasoner"
                    })
                }
            },

            {
                ServiceNames.Zhipu_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://open.bigmodel.cn/api/paas/v4",
                    ModelsLink = "https://open.bigmodel.cn/dev/howuse/model",
                    ApiKeyLink = "https://bigmodel.cn/usercenter/proj-mgmt/apikeys",
                    ApiDocLink = "https://bigmodel.cn/dev/api/thirdparty-frame/openai-sdk",
                    Model = "GLM-4-Flash-250414",
                    BuildInModels = String2ModelItems(new string[] 
                    {
                        "GLM-4-Plus",
                        "GLM-4-Air-250414 ",
                        "GLM-4-Long",
                        "GLM-4-AirX ",
                        "GLM-4-FlashX-250414",
                        "GLM-4-Flash-250414",
                    })
                }
            },

            {
                ServiceNames.Stepfun_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.stepfun.com/v1",
                    ModelsLink = "https://platform.stepfun.com/docs/llm/text",
                    ApiKeyLink = "https://platform.stepfun.com/interface-key",
                    ApiDocLink = "https://platform.stepfun.com/docs/guide/openai",
                    Model = "step-2-mini",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "step-2-mini",
                        "step-2",
                        "step-2-16k-exp",
                        "step-1",
                    })
                }
            },

            {
                ServiceNames.Moonshot_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.moonshot.cn/v1",
                    ModelsLink = "https://platform.moonshot.cn/docs/pricing/chat#%E7%94%9F%E6%88%90%E6%A8%A1%E5%9E%8B-moonshot-v1",
                    ApiKeyLink = "https://platform.moonshot.cn/console/api-keys",
                    ApiDocLink = "https://platform.moonshot.cn/docs/guide/migrating-from-openai-to-kimi",
                    Model = "kimi-latest-8k",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "kimi-latest-8k",
                        "kimi-latest-32k",
                        "kimi-latest-128k",
                        "moonshot-v1-8k",
                        "moonshot-v1-32k",
                        "moonshot-v1-128k",
                        "moonshot-v1-8k-vision-preview",
                        "moonshot-v1-32k-vision-preview ",
                        "moonshot-v1-128k-vision-preview",
                    })
                }
            },

            {
                ServiceNames.Baichuan_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.baichuan-ai.com/v1",
                    ModelsLink = "https://platform.baichuan-ai.com/docs/api",
                    ApiKeyLink = "https://platform.baichuan-ai.com/console/apikey",
                    ApiDocLink = "https://platform.baichuan-ai.com/docs/api#python-client",
                    Model = "Baichuan4",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "Baichuan4-Turbo",
                        "Baichuan4-Air",
                        "Baichuan4",
                        "Baichuan3-Turbo",
                        "Baichuan3-Turbo-128k",
                        "Baichuan2-Turbo",
                    })
                }
            },

            {
                ServiceNames.Minimax_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.minimax.chat/v1",
                    ModelsLink = "https://www.minimaxi.com/price",
                    ApiKeyLink = "https://platform.minimaxi.com/user-center/basic-information/interface-key",
                    ApiDocLink = "https://platform.minimaxi.com/document/ChatCompletion",
                    Model = "MiniMax-M1",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "MiniMax-M1",
                        "MiniMax-Text-01"
                    })
                }
            },

            {
                ServiceNames.Sensetime_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.sensenova.cn/compatible-mode/v1",
                    ModelsLink = "https://console.sensecore.cn/micro/help/docs/model-as-a-service/nova/model/llm/GeneralLLM",
                    ApiKeyLink = "https://console.sensecore.cn/iam/Security/access-key",
                    ApiDocLink = "https://www.sensecore.cn/help/docs/model-as-a-service/nova/overview/compatible-mode",
                    Model = "SenseChat-5",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "SenseChat-5-1202",
                        "SenseChat-Turbo-1202",
                        "SenseChat-5",
                        "SenseChat",
                        "SenseChat-32K",
                        "SenseChat-128K",
                        "SenseChat-Turbo",
                        "SenseChat-5-Cantonese",
                    })
                }
            },

            {
                ServiceNames.Lingyiwanwu_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.lingyiwanwu.com/v1",
                    ModelsLink = "https://platform.lingyiwanwu.com/docs#%E6%A8%A1%E5%9E%8B%E4%B8%8E%E8%AE%A1%E8%B4%B9",
                    ApiKeyLink = "https://platform.lingyiwanwu.com/",
                    ApiDocLink = "https://platform.lingyiwanwu.com/docs",
                    Model = "yi-lightning",
                    BuildInModels = String2ModelItems(new string[]
                    {
                         "yi-lightning",
                    })
                }
            },

            {
                ServiceNames.InternAI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://chat.intern-ai.org.cn/api/v1",
                    ModelsLink = "https://internlm.intern-ai.org.cn/api/document",
                    ApiKeyLink = "https://internlm.intern-ai.org.cn/api/tokens",
                    ApiDocLink = "https://internlm.intern-ai.org.cn/doc/docs/Chat/",
                    Model = "internlm3-latest",
                    BuildInModels = String2ModelItems(new string[] 
                    {
                        "internlm3-latest",
                        "internlm2.5-latest"
                    })
                }
            },

            {
                ServiceNames.Infly_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.infly.cn/v1",
                    ModelsLink = "https://platform.infly.cn/docs/open-api/price",
                    ApiKeyLink = "https://platform.infly.cn/console/api-key-management",
                    ApiDocLink = "https://platform.infly.cn/docs/open-api/api",
                    Model = "inf-chat-v1",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "inf-chat-v1",
                        "inf-chat-int-v1",
                    })
                }
            },

            {
                ServiceNames.Zhinao360_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://ai.360.cn/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://ai.360.com/platform/keys",
                    ApiDocLink = "https://ai.360.com/open",
                    Model = "360gpt-pro-trans",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "360gpt2-pro",
                        "360gpt-turbo",
                        "360gpt-pro-trans",
                    })
                }
            },

            {
                ServiceNames.Google_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://generativelanguage.googleapis.com/v1beta/openai",
                    ModelsLink = "https://ai.google.dev/gemini-api/docs/models",
                    ApiKeyLink = "https://aistudio.google.com/app/apikey",
                    ApiDocLink = "https://ai.google.dev/gemini-api/docs/openai",
                    Model = "gemini-2.5-flash",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "gemini-1.5-pro",
                        "gemini-1.5-flash",
                        "gemini-2.0-flash-lite",
                        "gemini-2.0-flash",
                        "gemini-2.5-flash-lite-preview-06-17",
                        "gemini-2.5-flash",
                        "gemini-2.5-pro",
                    })
                }
            },

            {
                ServiceNames.xAI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.x.ai/v1",
                    ModelsLink = "https://docs.x.ai/docs/models",
                    ApiKeyLink = "https://console.x.ai/",
                    ApiDocLink = "https://docs.x.ai/docs/api-reference#chat-completions",
                    Model = "grok-3",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "grok-2",
                        "grok-3-mini-fast",
                        "grok-3-mini",
                        "grok-3-fast",
                        "grok-3",
                    })
                }
            },

            {
                ServiceNames.Mistral_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.mistral.ai/v1",
                    ModelsLink = "https://docs.mistral.ai/getting-started/models/models_overview/",
                    ApiKeyLink = "https://console.mistral.ai/user/api-keys/",
                    ApiDocLink = "https://docs.mistral.ai/api/",
                }
            },

            {
                ServiceNames.Cohere_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.cohere.ai/compatibility/v1",
                    ModelsLink = "https://docs.cohere.com/v2/docs/models",
                    ApiKeyLink = "https://dashboard.cohere.com/welcome/login",
                    ApiDocLink = "https://docs.cohere.com/docs/compatibility-api",
                }
            },

            {
                ServiceNames.Upstage_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.upstage.ai/v1",
                    ModelsLink = "https://console.upstage.ai/docs/models",
                    ApiKeyLink = "https://console.upstage.ai/api-keys",
                    ApiDocLink = "https://console.upstage.ai/docs/getting-started",
                }
            },

            {
                ServiceNames.Perplexity_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.perplexity.ai",
                    ModelsLink = "https://docs.perplexity.ai/guides/pricing",
                    ApiKeyLink = "https://perplexity.ai/settings",
                    ApiDocLink = "https://docs.perplexity.ai/api-reference/chat-completions",
                }
            },

            {
                ServiceNames.Liquid_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://labs.liquid.ai/api/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://labs.liquid.ai",
                    ApiDocLink = "https://github.com/Liquid4All/liquid_client/blob/main/examples/openai/chat_completion.ipynb",
                }
            },

            {
                ServiceNames.AionLabs_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.aionlabs.ai/v1",
                    ModelsLink = "https://www.aionlabs.ai/documentation/chat#models",
                    ApiKeyLink = "https://www.aionlabs.ai/users/api_keys/",
                    ApiDocLink = "https://www.aionlabs.ai/documentation/",
                }
            },

            {
                ServiceNames.InceptionLabs_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.inceptionlabs.ai/v1",
                    ModelsLink = "https://platform.inceptionlabs.ai/docs#models",
                    ApiKeyLink = "https://platform.inceptionlabs.ai/dashboard/api-keys",
                    ApiDocLink = "https://www.inceptionlabs.ai/introducing-inception-api",
                }
            },

            {
                ServiceNames.Azure_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://{YOUR_RESOURCE_NAME}.openai.azure.com/openai/deployments/{YOUR_DEPLOYMENT_NAME}",
                    ModelsLink = "https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/models?tabs=global-standard%2Cstandard-chat-completions",
                    ApiKeyLink = "https://oai.azure.com/",
                    ApiDocLink = "https://learn.microsoft.com/en-us/azure/ai-services/openai/reference",
                }
            },

            //{
            //    ServiceNames.Amazon_LLM,
            //    new OpenAICompatibleServiceInfo()
            //    {
            //        BaseURL = "https://",
            //        ModelsLink = "https://TODO",
            //        ApiKeyLink = "https://TODO",
            //        ApiDocLink = "https://TODO",
            //    }
            //},

            {
                ServiceNames.Cloudflare_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.cloudflare.com/client/v4/accounts/{account_id}/ai/v1",
                    ModelsLink = "https://developers.cloudflare.com/workers-ai/models/",
                    ApiKeyLink = "https://dash.cloudflare.com/",
                    ApiDocLink = "https://developers.cloudflare.com/workers-ai/configuration/open-ai-compatibility/",
                }
            },

            {
                ServiceNames.Nvidia_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://integrate.api.nvidia.com/v1",
                    ModelsLink = "https://docs.api.nvidia.com/nim/reference/llm-apis",
                    ApiKeyLink = "https://build.nvidia.com/explore/discover",
                    ApiDocLink = "https://docs.api.nvidia.com/nim/reference/nvidia-llama-3_1-nemotron-ultra-253b-v1-infer",
                }
            },

            {
                ServiceNames.OpenRouter_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://openrouter.ai/api/v1",
                    ModelsLink = "https://openrouter.ai/models",
                    ApiKeyLink = "https://openrouter.ai/keys",
                    ApiDocLink = "https://openrouter.ai/docs/quickstart",
                    Model = "qwen/qwen3-8b:free",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "anthropic/claude-2",
                        "anthropic/claude-2.0",
                        "anthropic/claude-2.0:beta",
                        "anthropic/claude-2.1",
                        "anthropic/claude-2.1:beta",
                        "anthropic/claude-2:beta",
                        "anthropic/claude-3.5-haiku",
                        "anthropic/claude-3.5-haiku:beta",
                        "anthropic/claude-3.5-haiku-20241022",
                        "anthropic/claude-3.5-haiku-20241022:beta",
                        "anthropic/claude-3.5-sonnet",
                        "anthropic/claude-3.5-sonnet:beta",
                        "anthropic/claude-3.5-sonnet-20240620",
                        "anthropic/claude-3.5-sonnet-20240620:beta",
                        "anthropic/claude-3.7-sonnet",
                        "anthropic/claude-3.7-sonnet:beta",
                        "anthropic/claude-3.7-sonnet:thinking",
                        "anthropic/claude-3-haiku",
                        "anthropic/claude-3-haiku:beta",
                        "anthropic/claude-3-opus",
                        "anthropic/claude-3-opus:beta",
                        "anthropic/claude-3-sonnet",
                        "anthropic/claude-3-sonnet:beta",
                        "anthropic/claude-opus-4",
                        "anthropic/claude-sonnet-4",
                        "deepseek/deepseek-chat",
                        "deepseek/deepseek-chat:free",
                        "deepseek/deepseek-chat-v3-0324",
                        "deepseek/deepseek-chat-v3-0324:free",
                        "deepseek/deepseek-prover-v2",
                        "deepseek/deepseek-r1",
                        "deepseek/deepseek-r1:free",
                        "deepseek/deepseek-r1-0528",
                        "deepseek/deepseek-r1-0528:free",
                        "deepseek/deepseek-r1-0528-qwen3-8b",
                        "deepseek/deepseek-r1-0528-qwen3-8b:free",
                        "deepseek/deepseek-r1-distill-llama-8b",
                        "deepseek/deepseek-r1-distill-llama-70b",
                        "deepseek/deepseek-r1-distill-llama-70b:free",
                        "deepseek/deepseek-r1-distill-qwen-1.5b",
                        "deepseek/deepseek-r1-distill-qwen-7b",
                        "deepseek/deepseek-r1-distill-qwen-14b",
                        "deepseek/deepseek-r1-distill-qwen-14b:free",
                        "deepseek/deepseek-r1-distill-qwen-32b",
                        "deepseek/deepseek-r1-distill-qwen-32b:free",
                        "deepseek/deepseek-v3-base:free",
                        "google/gemini-2.0-flash-001",
                        "google/gemini-2.0-flash-exp:free",
                        "google/gemini-2.0-flash-lite-001",
                        "google/gemini-2.5-flash",
                        "google/gemini-2.5-flash-lite-preview-06-17",
                        "google/gemini-2.5-flash-preview",
                        "google/gemini-2.5-flash-preview:thinking",
                        "google/gemini-2.5-flash-preview-05-20",
                        "google/gemini-2.5-flash-preview-05-20:thinking",
                        "google/gemini-2.5-pro",
                        "google/gemini-2.5-pro-exp-03-25",
                        "google/gemini-2.5-pro-preview",
                        "google/gemini-2.5-pro-preview-05-06",
                        "google/gemini-flash-1.5",
                        "google/gemini-flash-1.5-8b",
                        "google/gemini-pro-1.5",
                        "google/gemma-2-9b-it",
                        "google/gemma-2-9b-it:free",
                        "google/gemma-2-27b-it",
                        "google/gemma-3-4b-it",
                        "google/gemma-3-4b-it:free",
                        "google/gemma-3-12b-it",
                        "google/gemma-3-12b-it:free",
                        "google/gemma-3-27b-it",
                        "google/gemma-3-27b-it:free",
                        "google/gemma-3n-e4b-it:free",
                        "openai/chatgpt-4o-latest",
                        "openai/codex-mini",
                        "openai/gpt-3.5-turbo",
                        "openai/gpt-3.5-turbo-16k",
                        "openai/gpt-3.5-turbo-0125",
                        "openai/gpt-3.5-turbo-0613",
                        "openai/gpt-3.5-turbo-1106",
                        "openai/gpt-3.5-turbo-instruct",
                        "openai/gpt-4",
                        "openai/gpt-4.1",
                        "openai/gpt-4.1-mini",
                        "openai/gpt-4.1-nano",
                        "openai/gpt-4.5-preview",
                        "openai/gpt-4-0314",
                        "openai/gpt-4-1106-preview",
                        "openai/gpt-4o",
                        "openai/gpt-4o:extended",
                        "openai/gpt-4o-2024-05-13",
                        "openai/gpt-4o-2024-08-06",
                        "openai/gpt-4o-2024-11-20",
                        "openai/gpt-4o-mini",
                        "openai/gpt-4o-mini-2024-07-18",
                        "openai/gpt-4o-mini-search-preview",
                        "openai/gpt-4o-search-preview",
                        "openai/gpt-4-turbo",
                        "openai/gpt-4-turbo-preview",
                        "openai/o1",
                        "openai/o1-mini",
                        "openai/o1-mini-2024-09-12",
                        "openai/o1-preview",
                        "openai/o1-preview-2024-09-12",
                        "openai/o1-pro",
                        "openai/o3",
                        "openai/o3-mini",
                        "openai/o3-mini-high",
                        "openai/o3-pro",
                        "openai/o4-mini",
                        "openai/o4-mini-high",
                        "qwen/qwen-2.5-7b-instruct",
                        "qwen/qwen-2.5-72b-instruct",
                        "qwen/qwen-2.5-72b-instruct:free",
                        "qwen/qwen-2.5-coder-32b-instruct",
                        "qwen/qwen-2.5-coder-32b-instruct:free",
                        "qwen/qwen-2.5-vl-7b-instruct",
                        "qwen/qwen2.5-vl-32b-instruct",
                        "qwen/qwen2.5-vl-32b-instruct:free",
                        "qwen/qwen2.5-vl-72b-instruct",
                        "qwen/qwen2.5-vl-72b-instruct:free",
                        "qwen/qwen-2-72b-instruct",
                        "qwen/qwen3-8b",
                        "qwen/qwen3-8b:free",
                        "qwen/qwen3-14b",
                        "qwen/qwen3-14b:free",
                        "qwen/qwen3-30b-a3b",
                        "qwen/qwen3-30b-a3b:free",
                        "qwen/qwen3-32b",
                        "qwen/qwen3-32b:free",
                        "qwen/qwen3-235b-a22b",
                        "qwen/qwen3-235b-a22b:free",
                        "qwen/qwen-max",
                        "qwen/qwen-plus",
                        "qwen/qwen-turbo",
                        "qwen/qwen-vl-max",
                        "qwen/qwen-vl-plus",
                        "qwen/qwq-32b",
                        "qwen/qwq-32b:free",
                        "qwen/qwq-32b-preview",
                        "x-ai/grok-2-1212",
                        "x-ai/grok-2-vision-1212",
                        "x-ai/grok-3",
                        "x-ai/grok-3-beta",
                        "x-ai/grok-3-mini",
                        "x-ai/grok-3-mini-beta",
                        "x-ai/grok-beta",
                        "x-ai/grok-vision-beta"
                    })
                }
            },

            {
                ServiceNames.Siliconflow_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.siliconflow.cn/v1",
                    ModelsLink = "https://siliconflow.cn/pricing",
                    ApiKeyLink = "https://cloud.siliconflow.cn/account/ak",
                    ApiDocLink = "https://docs.siliconflow.cn/cn/userguide/quickstart#4-3-openai",
                    Model = "Qwen/Qwen3-8B",
                    BuildInModels = String2ModelItems(new string[]
                    {
                        "internlm/internlm2_5-7b-chat",
                        "deepseek-ai/deepseek-vl2",
                        "deepseek-ai/DeepSeek-V3",
                        "deepseek-ai/DeepSeek-V2.5",
                        "deepseek-ai/DeepSeek-R1-Distill-Qwen-7B",
                        "deepseek-ai/DeepSeek-R1-Distill-Qwen-14B",
                        "deepseek-ai/DeepSeek-R1-Distill-Qwen-32B",
                        "deepseek-ai/DeepSeek-R1-0528-Qwen3-8B",
                        "deepseek-ai/DeepSeek-R1",
                        "Tongyi-Zhiwen/QwenLong-L1-32B",
                        "THUDM/glm-4-9b-chat",
                        "THUDM/GLM-Z1-Rumination-32B-0414",
                        "THUDM/GLM-Z1-9B-0414",
                        "THUDM/GLM-Z1-32B-0414",
                        "THUDM/GLM-4-9B-0414",
                        "THUDM/GLM-4-32B-0414",
                        "Qwen/Qwen3-8B",
                        "Qwen/Qwen3-14B",
                        "Qwen/Qwen3-30B-A3B",
                        "Qwen/Qwen3-32B",
                        "Qwen/Qwen3-235B-A22B",
                        "Qwen/Qwen2-VL-72B-Instruct",
                        "Qwen/Qwen2.5-VL-32B-Instruct",
                        "Qwen/Qwen2.5-VL-72B-Instruct",
                        "Qwen/Qwen2.5-Coder-7B-Instruct",
                        "Qwen/Qwen2.5-Coder-32B-Instruct",
                        "Qwen/Qwen2.5-7B-Instruct",
                        "Qwen/Qwen2.5-14B-Instruct",
                        "Qwen/Qwen2.5-32B-Instruct",
                        "Qwen/Qwen2.5-72B-Instruct-128K",
                        "Qwen/Qwen2.5-72B-Instruct",
                        "Qwen/Qwen2-7B-Instruct",
                        "Qwen/QwQ-32B-Preview",
                        "Qwen/QwQ-32B",
                        "Qwen/QVQ-72B-Preview",
                        "Pro/deepseek-ai/DeepSeek-V3-1226",
                        "Pro/deepseek-ai/DeepSeek-V3",
                        "Pro/deepseek-ai/DeepSeek-R1-Distill-Qwen-7B",
                        "Pro/deepseek-ai/DeepSeek-R1-0120",
                        "Pro/deepseek-ai/DeepSeek-R1",
                        "Pro/THUDM/glm-4-9b-chat",
                        "Pro/Qwen/Qwen2.5-VL-7B-Instruct",
                        "Pro/Qwen/Qwen2.5-Coder-7B-Instruct",
                        "Pro/Qwen/Qwen2.5-7B-Instruct",
                        "Pro/Qwen/Qwen2-7B-Instruct",
                    })
                }
            },

            {
                ServiceNames.InfiniAI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://cloud.infini-ai.com/maas/v1",
                    ModelsLink = "https://cloud.infini-ai.com/genstudio/model",
                    ApiKeyLink = "https://cloud.infini-ai.com/iam/secret/key",
                    ApiDocLink = "https://docs.infini-ai.com/gen-studio/api/maas.html",
                    Model = "qwen3-8b",
                    BuildInModels = String2ModelItems(new string[] 
                    {
                        "deepseek-r1",
                        "deepseek-r1-0528-qwen3-8b",
                        "deepseek-v3",
                        "qwen3-235b-a22b",
                        "deepseek-r1-distill-qwen-32b",
                        "glm-4-9b-chat",
                        "llama-2-7b-chat",
                        "llama-3-infini-8b-instruct",
                        "llama-3.3-70b-instruct",
                        "megrez-3b-instruct",
                        "qwen1.5-14b-chat",
                        "qwen2-7b-instruct",
                        "qwen2.5-14b-instruct",
                        "qwen2.5-32b-instruct",
                        "qwen2.5-72b-instruct",
                        "qwen2.5-7b-instruct",
                        "qwen2.5-coder-32b-instruct",
                        "qwen3-14b",
                        "qwen3-30b-a3b",
                        "qwen3-32b",
                        "qwen3-8b",
                        "qwq-32b",

                    })
                }
            },

            {
                ServiceNames.AIMLApi_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.aimlapi.com/v1",
                    ModelsLink = "https://docs.aimlapi.com/api-references/model-database",
                    ApiKeyLink = "https://aimlapi.com/app/keys",
                    ApiDocLink = "https://docs.aimlapi.com/",
                }
            },

            {
                ServiceNames.Fireworks_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.fireworks.ai/inference/v1",
                    ModelsLink = "https://fireworks.ai/models",
                    ApiKeyLink = "https://fireworks.ai/api-keys",
                    ApiDocLink = "https://docs.fireworks.ai/tools-sdks/openai-compatibility",
                }
            },

            {
                ServiceNames.Deepinfra_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.deepinfra.com/v1/openai",
                    ModelsLink = "https://deepinfra.com/models",
                    ApiKeyLink = "https://deepinfra.com/dash",
                    ApiDocLink = "https://deepinfra.com/blog/openai-api",
                }
            },

            {
                ServiceNames.Targon_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.targon.com/v1",
                    ModelsLink = "https://targon.com/models",
                    ApiKeyLink = "https://targon.com/settings/keys",
                    ApiDocLink = "https://targon.com/models",
                }
            },

            {
                ServiceNames.Friendli_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.friendli.ai/serverless/v1",
                    ModelsLink = "https://friendli.ai/models",
                    ApiKeyLink = "https://friendli.ai/suite",
                    ApiDocLink = "https://friendli.ai/docs/guides/serverless_endpoints/openai-compatibility",
                }
            },

            {
                ServiceNames.Groq_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.groq.com/openai/v1",
                    ModelsLink = "https://console.groq.com/docs/models",
                    ApiKeyLink = "https://console.groq.com/keys",
                    ApiDocLink = "https://console.groq.com/docs/api-reference",
                }
            },

            {
                ServiceNames.Together_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.together.xyz/v1",
                    ModelsLink = "https://docs.together.ai/docs/serverless-models",
                    ApiKeyLink = "https://api.together.xyz/settings/api-keys",
                    ApiDocLink = "https://docs.together.ai/docs/openai-api-compatibility",
                }
            },

            {
                ServiceNames.Tasking_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://oapi.tasking.ai/v1",
                    ModelsLink = "https://docs.tasking.ai/docs/guide/product_modules/model/overview#credentials-required-to-access-models",
                    ApiKeyLink = "https://app.tasking.ai/auth/signin",
                    ApiDocLink = "https://docs.tasking.ai/docs/developer-guide/openai/basic-usage",
                }
            },

            {
                ServiceNames.Infermatic_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.totalgpt.ai/v1",
                    ModelsLink = "https://infermatic.ai/models/",
                    ApiKeyLink = "https://ui.infermatic.ai/",
                    ApiDocLink = "https://infermatic.ai/docs/overview/",
                }
            },

            {
                ServiceNames.CentML_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.centml.com/openai/v1",
                    ModelsLink = "https://centml.ai/models",
                    ApiKeyLink = "https://app.centml.com/",
                    ApiDocLink = "https://docs.centml.ai/resources/json_and_tool#conclusion",
                }
            },

            {
                ServiceNames.Nebius_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.studio.nebius.ai/v1",
                    ModelsLink = "https://nebius.com/prices-ai-studio",
                    ApiKeyLink = "https://studio.nebius.ai/settings/api-keys",
                    ApiDocLink = "https://api.studio.nebius.ai/docs",
                }
            },

            {
                ServiceNames.Novita_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.novita.ai/v3/openai",
                    ModelsLink = "https://novita.ai/models",
                    ApiKeyLink = "https://novita.ai/dashboard/key",
                    ApiDocLink = "https://novita.ai/docs/api-reference/model-apis-llm-create-chat-completion",
                }
            },

            {
                ServiceNames.Opper_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.opper.ai/compat/openai",
                    ModelsLink = "https://docs.opper.ai/capabilities/models",
                    ApiKeyLink = "https://platform.opper.ai/",
                    ApiDocLink = "https://docs.opper.ai/sdks/openai",
                }
            },

            {
                ServiceNames.Kluster_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.kluster.ai/v1",
                    ModelsLink = "https://docs.kluster.ai/get-started/models/",
                    ApiKeyLink = "https://platform.kluster.ai/apikeys",
                    ApiDocLink = "https://docs.kluster.ai/get-started/openai-compatibility",
                }
            },

            {
                ServiceNames.OVHCloud_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://{model_name}.endpoints.kepler.ai.cloud.ovh.net/api/openai_compat/v1",
                    ModelsLink = "https://help.ovhcloud.com/csm/en-public-cloud-ai-endpoints-billing?id=kb_article_view&sysparm_article=KB0067530",
                    ApiKeyLink = "https://ca.ovh.com/auth/?action=gotomanage",
                    ApiDocLink = "https://help.ovhcloud.com/csm/en-public-cloud-ai-endpoints-getting-started?id=kb_article_view&sysparm_article=KB0065403",
                }
            },

            {
                ServiceNames.Scaleway_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://{Deployment UUID}.ifr.fr-par.scaleway.com/v1",
                    ModelsLink = "https://www.scaleway.com/en/docs/generative-apis/reference-content/supported-models/",
                    ApiKeyLink = "https://console.scaleway.com/",
                    ApiDocLink = "https://www.scaleway.com/en/docs/managed-inference/reference-content/openai-compatibility/",
                }
            },

            {
                ServiceNames.TaamCloud_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.taam.cloud/v1",
                    ModelsLink = "https://docs.taam.cloud/api-reference/endpoint/models",
                    ApiKeyLink = "https://app.taam.cloud/dashboard/settings/organization/developers",
                    ApiDocLink = "https://docs.taam.cloud/api-reference/openai-compatibility",
                }
            },

            {
                ServiceNames.Sambanova_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.sambanova.ai/v1",
                    ModelsLink = "https://docs.sambanova.ai/cloud/docs/get-started/supported-models",
                    ApiKeyLink = "https://cloud.sambanova.ai/",
                    ApiDocLink = "https://docs.sambanova.ai/cloud/docs/capabilities/openai-compatibility",
                }
            },

            {
                ServiceNames.GMICloud_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.gmi-serving.com/v1",
                    ModelsLink = "https://docs.gmicloud.ai/inference-engine/billing/price",
                    ApiKeyLink = "https://inference-engine.gmicloud.ai",
                    ApiDocLink = "https://docs.gmicloud.ai/inference-engine/api-reference",
                }
            },

            {
                ServiceNames.InferenceNet_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.inference.net/v1",
                    ModelsLink = "https://inference.net/models",
                    ApiKeyLink = "https://inference.net/",
                    ApiDocLink = "https://docs.inference.net/quickstart",
                }
            },

            {
                ServiceNames.nCompass_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.ncompass.tech/v1",
                    ModelsLink = "https://www.ncompass.tech/models",
                    ApiKeyLink = "https://app.ncompass.tech/api-settings",
                    ApiDocLink = "https://docs.ncompass.tech/api-reference/quickstart",
                }
            },

            {
                ServiceNames.Nextbit256_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.nextbit256.com/v1",
                    ModelsLink = "https://www.nextbit256.com/#serverless-models",
                    ApiKeyLink = "https://www.nextbit256.com/dashboard",
                    ApiDocLink = "https://www.nextbit256.com/docs",
                }
            },

            {
                ServiceNames.Parasail_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.saas.parasail.io/v1",
                    ModelsLink = "https://docs.parasail.io/parasail-docs/billing/pricing",
                    ApiKeyLink = "https://www.saas.parasail.io/keys",
                    ApiDocLink = "https://docs.parasail.io/parasail-docs/batch/api-reference",
                }
            },

            {
                ServiceNames.Ubicloud_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://{MODEL}.ai.ubicloud.com/v1",
                    ModelsLink = "https://www.ubicloud.com/docs/inference/endpoint",
                    ApiKeyLink = "https://console.ubicloud.com/",
                    ApiDocLink = "https://www.ubicloud.com/docs/inference/chat-completion-python",
                }
            },

            {
                ServiceNames.FunctionNetwork_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.function.network/v1",
                    ModelsLink = "https://docs.function.network/supported-models/chat-and-code-completion",
                    ApiKeyLink = "https://platform.function.network/",
                    ApiDocLink = "https://docs.function.network/developer-platform/openai-compatible-api",
                }
            },

            {
                ServiceNames.Venice_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.venice.ai/api/v1",
                    ModelsLink = "https://docs.venice.ai/overview/pricing",
                    ApiKeyLink = "https://venice.ai/settings/api",
                    ApiDocLink = "https://docs.venice.ai/overview/getting-started",
                }
            },

            {
                ServiceNames.Ionos_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://openai.inference.de-txl.ionos.com/v1",
                    ModelsLink = "https://cloud.ionos.com/managed/ai-model-hub",
                    ApiKeyLink = "https://developer.hosting.ionos.com/keys",
                    ApiDocLink = "https://api.ionos.com/docs/inference-openai/v1/",
                }
            },

            {
                ServiceNames.Hyperbolic_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.hyperbolic.xyz/v1",
                    ModelsLink = "https://docs.hyperbolic.xyz/docs/hyperbolic-ai-inference-pricing",
                    ApiKeyLink = "https://app.hyperbolic.xyz/settings",
                    ApiDocLink = "https://docs.hyperbolic.xyz/docs/python-api",
                }
            },

            {
                ServiceNames.Lepton_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://{model_name}.lepton.run/api/v1",
                    ModelsLink = "https://www.lepton.ai/docs/endpoints/llm/llama-3.2-1b",
                    ApiKeyLink = "https://dashboard.lepton.ai/",
                    ApiDocLink = "https://www.lepton.ai/docs/guides/endpoints/serverless-endpoints",
                }
            },

            {
                ServiceNames.Lambda_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.lambda.ai/v1",
                    ModelsLink = "https://docs.lambda.ai/public-cloud/lambda-inference-api/#listing-models",
                    ApiKeyLink = "https://cloud.lambdalabs.com/api-keys",
                    ApiDocLink = "https://docs.lambda.ai/public-cloud/lambda-inference-api/",
                }
            },

            {
                ServiceNames.Galadriel_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.galadriel.com/v1/verified",
                    ModelsLink = "https://docs.galadriel.com/for-agents-developers/models",
                    ApiKeyLink = "https://dashboard.galadriel.com/",
                    ApiDocLink = "https://docs.galadriel.com/for-agents-developers/quickstart",
                }
            },

            {
                ServiceNames.LlamaFamily_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.atomecho.cn/v1",
                    ModelsLink = "https://llama.family/docs/chat-completion-v1",
                    ApiKeyLink = "https://llama.family/login",
                    ApiDocLink = "https://llama.family/docs/api",
                }
            },

            {
                ServiceNames.PhalaNetwork_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.red-pill.ai/v1",
                    ModelsLink = "https://docs.phala.network/llm-in-gpu-tee/inference-api#chat-with-private-ai",
                    ApiKeyLink = "https://cloud.phala.network",
                    ApiDocLink = "https://docs.phala.network/llm-in-gpu-tee/inference-api#chat-with-private-ai",
                }
            },

            {
                ServiceNames.Enfer_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.enfer.ai/v1",
                    ModelsLink = "https://enfer-ai.gitbook.io/enfer.ai-docs",
                    ApiKeyLink = "https://dummy.enfer.ai/profile/keys",
                    ApiDocLink = "https://enfer-ai.gitbook.io/enfer.ai-docs",
                }
            },

            {
                ServiceNames.Crusoe_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.crusoe.ai/v1",
                    ModelsLink = "https://docs.crusoecloud.com/reference/inference/#available-models",
                    ApiKeyLink = "https://console.crusoecloud.com/",
                    ApiDocLink = "https://docs.crusoecloud.com/reference/inference/#getting-started",
                }
            },

            {
                ServiceNames.Avian_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.avian.io/v1",
                    ModelsLink = "https://docs.avian.io/get-started/models-and-pricing",
                    ApiKeyLink = "https://new.avian.io/api-keys",
                    ApiDocLink = "https://docs.avian.io/",
                }
            },

            {
                ServiceNames.Cerebras_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.cerebras.ai/v1",
                    ModelsLink = "https://inference-docs.cerebras.ai/support/pricing",
                    ApiKeyLink = "https://cloud.cerebras.ai/",
                    ApiDocLink = "https://inference-docs.cerebras.ai/resources/openai",
                }
            },

            {
                ServiceNames.AlephAlpha_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.aleph-alpha.com",
                    ModelsLink = "https://docs.litellm.ai/docs/providers/aleph_alpha",
                    ApiKeyLink = "https://app.aleph-alpha.com/profile",
                    ApiDocLink = "https://docs.aleph-alpha.com/products/pharia-ai/pharia-os/references/inference/endpoints/chat/",
                }
            },

            {
                ServiceNames.Anyscale_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.endpoints.anyscale.com/v1",
                    ModelsLink = "https://app.endpoints.anyscale.com/",
                    ApiKeyLink = "https://app.endpoints.anyscale.com/credentials",
                    ApiDocLink = "https://docs.anyscale.com/examples/work-with-openai",
                }
            },

            {
                ServiceNames.AtomaNetwork_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.atoma.network/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://cloud.atoma.network/",
                    ApiDocLink = "https://docs.atoma.network/cloud-api-reference/get-started",
                }
            },

            {
                ServiceNames.Distribute_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.distribute.ai/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://dashboard.distribute.ai/enterprise/api-keys",
                    ApiDocLink = "https://docs.distribute.ai/enterprise-api/openai-compatible-api/chat/completions",
                }
            },

            {
                ServiceNames.Runpod_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.runpod.ai/v2/{ENDPOINT_ID}/openai/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://www.runpod.io/console/user/settingss",
                    ApiDocLink = "https://docs.runpod.io/serverless/vllm/openai-compatibility",
                }
            },

            {
                ServiceNames.VlmRun_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "https://api.vlm.run/v1/openai",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://app.vlm.run/",
                    ApiDocLink = "https://docs.vlm.run/integrations/integrations-openai-compatibility",
                }
            },

            {
                ServiceNames.OneAPI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:3000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://github.com/songquanpeng/one-api",
                }
            },

            {
                ServiceNames.NewAPI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:3000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://docs.newapi.pro/api/openai-chat/",
                }
            },

            {
                ServiceNames.OneHub_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:3000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://one-hub-doc.vercel.app/use/",
                }
            },

            {
                ServiceNames.SimpleOneAPI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:9090/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://github.com/fruitbars/simple-one-api",
                }
            },

            {
                ServiceNames.VoAPI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:3000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://github.com/VoAPI/VoAPI",
                }
            },

            {
                ServiceNames.LiteLLM_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:4000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://docs.litellm.ai/docs/",
                }
            },

            {
                ServiceNames.UniAPI_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:8000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://github.com/yym68686/uni-api",
                }
            },

            {
                ServiceNames.Ollama_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:11434/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://github.com/ollama/ollama/blob/main/docs/openai.md",
                }
            },

            {
                ServiceNames.vLLM_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:8000/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://docs.vllm.ai/en/latest/serving/openai_compatible_server.html",
                }
            },

            {
                ServiceNames.LlamaCpp_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:8080/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://llama-cpp-python.readthedocs.io/en/latest/server/",
                }
            },

            {
                ServiceNames.LMStudio_LLM,
                new OpenAICompatibleServiceInfo()
                {
                    BaseURL = "http://localhost:1234/v1",
                    ModelsLink = "https://TODO",
                    ApiKeyLink = "https://TODO",
                    ApiDocLink = "https://lmstudio.ai/docs/app/api/endpoints/openai",
                }
            },
        };
    }

    class OpenAICompatibleServiceInfo
    {
        public string UniqueName { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;


        #region 用于配置文件
        public string BaseURL { get; set; } = "https://";

        public string Path { get; set; } = "/chat/completions";

        public string Model { get; set; } = string.Empty;

        public ModelItem[] BuildInModels { get; set; } = new ModelItem[] { };
        #endregion


        #region 用于设置界面
        public string ModelsLink { get; set; } = "https://";

        public string ApiKeyLink { get; set; } = "https://";

        public string ApiDocLink { get; set; } = "https://";
        #endregion


        public OpenAICompatibleServiceInfo Clone()
        {
            var jss = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var json = JsonConvert.SerializeObject(this, jss);

            return JsonConvert.DeserializeObject<OpenAICompatibleServiceInfo>(json, jss);
        }
    }
}
