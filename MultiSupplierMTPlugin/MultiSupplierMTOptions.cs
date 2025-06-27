using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MultiSupplierMTPlugin
{
    class MultiSupplierMTOptions : PluginSettingsObject<MultiSupplierMTGeneralSettings, MultiSupplierMTSecureSettings>
    {
        public MultiSupplierMTOptions(PluginSettings serializedSettings) : base(serializedSettings)
        {

        }

        public MultiSupplierMTOptions(MultiSupplierMTGeneralSettings generalSettings, MultiSupplierMTSecureSettings secureSettings) : base(generalSettings, secureSettings)
        {

        }

        public void SetProviderOptions(string name, ProviderOptions providerOptions)
        {
            this.GeneralSettings.SetProviderSettings(name, providerOptions.GeneralSettings);
            this.SecureSettings.SetProviderSettings(name, providerOptions.SecureSettings);
        }

        public ProviderOptions GetProviderOptionsOrNull(string name)
        {
            var g = this.GeneralSettings.GetProviderSettingsOrNull(name);
            var s = this.SecureSettings.GetProviderSettingsOrNull(name);

            if (g != null && s != null) return new ProviderOptions(g, s);

            return null;
        }
    }

    class MultiSupplierMTGeneralSettings
    {
        #region global 配置项
        public string Version { get; set; } = string.Empty;

        public string CurrentServiceProvider { get; set; } = ServiceNames.Microsoft_BuiltIn;
        public RequestType RequestType { get; set; } = RequestType.Plaintext;
        public bool ShowSupportedRequestTypeOnly { get; set; } = true;


        public bool InsertRequiredTagsToEnd { get; set; } = false;
        public bool NormalizeWhitespaceAroundTags { get; set; } = false;


        public bool EnableCustomRequestLimit { get; set; } = false;

        public int MaxSegmentsPerRequest { get; set; } = 1;
        public int MaxCharactersPerRequest { get; set; } = 0;

        public int WindowSizeMs { get; set; } = 1000;
        public int MaxRequestsPerWindow { get; set; } = 1;
        public double RequestSmoothness { get; set; } = 1.0;

        public int MaxRequestsHold { get; set; } = 1;

        public int FailedTimeoutMs { get; set; } = 0;
        public int RetryWaitingMs { get; set; } = 0;
        public int NumberOfRetries { get; set; } = 0;


        public bool EnableCustomDisplayName { get; set; } = false;
        public string CustomDisplayName { get; set; } = string.Empty;


        public bool EnableCache { get; set; } = true;


        public bool EnableStatsAndLog { get; set; } = true;
        public LogLevel LogLevel { get; set; } = LogLevel.Warn;
        public int LogRetentionDays { get; set; } = -1;

        public int RuningTimes { get; set; } = 1;
        public bool NeverShowTip { get; set; } = false;

        public string UILanguage { get; set; } = Thread.CurrentThread.CurrentUICulture.Name;

        public string DataDir { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MemoQ", "Plugins", "MultiSupplierMTPlugin");


        public LLMCommonGeneralSettings LLMCommon { get; set; } = new LLMCommonGeneralSettings();


        public string[] EnableProviders { get; set; } = new string[] 
        {
            ServiceNames.Aliyun,
            ServiceNames.Baidu,
            ServiceNames.Caiyun,
            ServiceNames.DeepL,
            ServiceNames.DeepLX,
            ServiceNames.Huoshan,
            ServiceNames.Niutrans,
            ServiceNames.Papago,
            ServiceNames.Tencent,
            ServiceNames.Xunfei,
            ServiceNames.Yandex,
            ServiceNames.Youdao,

            ServiceNames.DeepL_BuiltIn,
            ServiceNames.Google_BuiltIn,
            ServiceNames.Lingvanex_BuiltIn,
            ServiceNames.Microsoft_BuiltIn,
            ServiceNames.Modernmt_BuiltIn,
            ServiceNames.Yandex_BuiltIn,

            ServiceNames.Aliyun_LLM,
            ServiceNames.Anthropic_LLM,
            ServiceNames.Baichuan_LLM,
            ServiceNames.Baidu_LLM,
            ServiceNames.ByteDance_LLM,
            ServiceNames.DeepSeek_LLM,
            ServiceNames.Google_LLM,
            ServiceNames.InfiniAI_LLM,
            ServiceNames.Infly_LLM,
            ServiceNames.InternAI_LLM,
            ServiceNames.Lingyiwanwu_LLM,
            ServiceNames.Minimax_LLM,
            ServiceNames.Moonshot_LLM,
            ServiceNames.OpenAI_LLM,
            ServiceNames.OpenRouter_LLM,
            ServiceNames.Sensetime_LLM,
            ServiceNames.Siliconflow_LLM,
            ServiceNames.Stepfun_LLM,
            ServiceNames.Tencent_LLM,
            ServiceNames.Xunfei_LLM,
            ServiceNames.xAI_LLM,
            ServiceNames.Zhinao360_LLM,
            ServiceNames.Zhipu_LLM,
        };
        

        public OpenAICompatibleServiceInfo[] CustomOpenAICompatibleServiceInfos { get; set; } = new OpenAICompatibleServiceInfo[]{};
        #endregion

        #region providers 配置项（半多态方式实现）
        //使用多态的优点：非常节省代码，不用为每个提供商配置类定义一个字段。
        //使用多态的缺点：需要将类型信息也保存起来，反序列时才能根据类型还原，但一旦修改项目代码中的类名或者命名空间将导致整个类反序列化失败。
        //所以这里使用 SettingsTypeMapping 和 ProviderSettingsDicConverter 在代码中手动维护类型映射信息，而不是将类型信息保存在配置文件。
        public Dictionary<string, ProviderGeneralSettings> providerGeneralSettingsDic { get; set; } = new Dictionary<string, ProviderGeneralSettings>();

        public void SetProviderSettings(string name, ProviderGeneralSettings providerSettings)
        {
            providerGeneralSettingsDic[name] = providerSettings;
        }

        public ProviderGeneralSettings GetProviderSettingsOrNull(string name)
        {
            if (providerGeneralSettingsDic.ContainsKey(name)) return providerGeneralSettingsDic[name];

            return null;
        }
        #endregion
    }

    class MultiSupplierMTSecureSettings
    {
        #region global 配置项
        
        public string Version { get; set; } = string.Empty;

        #endregion

        #region providers 配置项（半多态方式实现）
        //使用多态的优点：非常节省代码，不用为每个提供商配置类定义一个字段。
        //使用多态的缺点：需要将类型信息也保存起来，反序列时才能根据类型还原，但一旦修改项目代码中的类名或者命名空间将导致整个类反序列化失败。
        //所以这里使用 SettingsTypeMapping 和 ProviderSettingsDicConverter 在代码中手动维护类型映射信息，而不是将类型信息保存在配置文件。
        public Dictionary<string, ProviderSecureSettings> providerSecureSettingsDic { get; set; } = new Dictionary<string, ProviderSecureSettings>();

        public void SetProviderSettings(string name, ProviderSecureSettings providerSettings)
        {
            providerSecureSettingsDic[name] = providerSettings;
        }

        public ProviderSecureSettings GetProviderSettingsOrNull(string name)
        {
            if (providerSecureSettingsDic.ContainsKey(name)) return providerSecureSettingsDic[name];

            return null;
        }
        #endregion
    }


    class ProviderOptions
    {
        public readonly ProviderGeneralSettings GeneralSettings;

        public readonly ProviderSecureSettings SecureSettings;

        public ProviderOptions()
        {
            GeneralSettings = new ProviderGeneralSettings();
            SecureSettings = new ProviderSecureSettings();
        }

        public ProviderOptions(ProviderGeneralSettings generalSettings, ProviderSecureSettings secureSettings)
        {
            GeneralSettings = generalSettings;
            SecureSettings = secureSettings;
        }

        public ProviderOptions Clone()
        {
            var jss = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var gJson = JsonConvert.SerializeObject(GeneralSettings, jss);
            var sJson = JsonConvert.SerializeObject(SecureSettings, jss);
            
            var g = JsonConvert.DeserializeObject<ProviderGeneralSettings>(gJson, jss);
            var s = JsonConvert.DeserializeObject<ProviderSecureSettings>(sJson, jss);
            
            return new ProviderOptions(g, s);
        }
    }

    class ProviderGeneralSettings 
    { 
        public virtual bool Checked { get; set; } = false;
    }

    class ProviderSecureSettings 
    { 

    }


    class SettingsTypeMapping
    {
        public static Dictionary<string, Type> General = new Dictionary<string, Type>
        {
            {ServiceNames.Aliyun, typeof(Providers.Aliyun.GeneralSettings)},
            {ServiceNames.Anthropic_LLM, typeof(Providers.Anthropic.GeneralSettings)},
            {ServiceNames.Baidu, typeof(Providers.Baidu.GeneralSettings)},
            {ServiceNames.Caiyun, typeof(Providers.Caiyun.GeneralSettings)},
            {ServiceNames.DeepL, typeof(Providers.DeepL.GeneralSettings)},
            {ServiceNames.DeepL_BuiltIn, typeof(Providers.DeepLBuiltIn.GeneralSettings)},
            {ServiceNames.DeepLX, typeof(Providers.DeepLX.GeneralSettings)},
            {ServiceNames.Google_BuiltIn, typeof(Providers.GoogleBuiltIn.GeneralSettings)},
            {ServiceNames.Huoshan, typeof(Providers.Huoshan.GeneralSettings)},
            {ServiceNames.Lingvanex_BuiltIn, typeof(Providers.LingvanexBuiltIn.GeneralSettings)},
            {ServiceNames.Microsoft_BuiltIn, typeof(Providers.MicrosoftBuiltIn.GeneralSettings)},
            {ServiceNames.Modernmt_BuiltIn, typeof(Providers.ModernmtBuiltIn.GeneralSettings)},
            {ServiceNames.Niutrans, typeof(Providers.Niutrans.GeneralSettings)},
            {ServiceNames.OpenAI_LLM, typeof(Providers.OpenAI.GeneralSettings)},
            {ServiceNames.Papago, typeof(Providers.Papago.GeneralSettings)},
            {ServiceNames.Tencent, typeof(Providers.Tencent.GeneralSettings)},
            {ServiceNames.Xunfei, typeof(Providers.Xunfei.GeneralSettings)},
            {ServiceNames.Yandex, typeof(Providers.Yandex.GeneralSettings)},
            {ServiceNames.Yandex_BuiltIn, typeof(Providers.YandexBuiltIn.GeneralSettings)},
            {ServiceNames.Youdao, typeof(Providers.Youdao.GeneralSettings)},
        };

        public static Dictionary<string, Type> Secure = new Dictionary<string, Type>
        {
            {ServiceNames.Aliyun, typeof(Providers.Aliyun.SecureSettings)},
            {ServiceNames.Anthropic_LLM, typeof(Providers.Anthropic.SecureSettings)},
            {ServiceNames.Baidu, typeof(Providers.Baidu.SecureSettings)},
            {ServiceNames.Caiyun, typeof(Providers.Caiyun.SecureSettings)},
            {ServiceNames.DeepL, typeof(Providers.DeepL.SecureSettings)},
            {ServiceNames.DeepL_BuiltIn, typeof(Providers.DeepLBuiltIn.SecureSettings)},
            {ServiceNames.DeepLX, typeof(Providers.DeepLX.SecureSettings)},
            {ServiceNames.Google_BuiltIn, typeof(Providers.GoogleBuiltIn.SecureSettings)},
            {ServiceNames.Huoshan, typeof(Providers.Huoshan.SecureSettings)},
            {ServiceNames.Lingvanex_BuiltIn, typeof(Providers.LingvanexBuiltIn.SecureSettings)},
            {ServiceNames.Microsoft_BuiltIn, typeof(Providers.MicrosoftBuiltIn.SecureSettings)},
            {ServiceNames.Modernmt_BuiltIn, typeof(Providers.ModernmtBuiltIn.SecureSettings)},
            {ServiceNames.Niutrans, typeof(Providers.Niutrans.SecureSettings)},
            {ServiceNames.OpenAI_LLM, typeof(Providers.OpenAI.SecureSettings)},
            {ServiceNames.Papago, typeof(Providers.Papago.SecureSettings)},
            {ServiceNames.Tencent, typeof(Providers.Tencent.SecureSettings)},
            {ServiceNames.Xunfei, typeof(Providers.Xunfei.SecureSettings)},
            {ServiceNames.Yandex, typeof(Providers.Yandex.SecureSettings)},
            {ServiceNames.Yandex_BuiltIn, typeof(Providers.YandexBuiltIn.SecureSettings)},
            {ServiceNames.Youdao, typeof(Providers.Youdao.SecureSettings)},
        };
    }


    class PluginSettingsObject<TGeneralSettings, TSecureSettings> where TGeneralSettings : new() where TSecureSettings : new()
    {
        private class ProviderSettingsDicConverter<TSettings, TDefaultSettings> : JsonConverter where TDefaultSettings : TSettings, new()
        {
            private readonly Dictionary<string, Type> _typeMapping;

            public ProviderSettingsDicConverter(Dictionary<string, Type> typeMapping)
            {
                _typeMapping = typeMapping;
            }

            public override bool CanConvert(Type objectType)
            {
                return typeof(Dictionary<string, TSettings>).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var result = new Dictionary<string, TSettings>();
                var jObject = JObject.Load(reader);

                foreach (var property in jObject.Properties())
                {
                    var providerName = property.Name;
                    var value = property.Value;

                    try
                    {
                        Type targetType = _typeMapping.TryGetValue(providerName, out var mappedType)
                            ? mappedType
                            : typeof(TDefaultSettings);

                        var setting = (TSettings)value.ToObject(targetType, serializer);
                        result[providerName] = setting;
                    }
                    catch
                    {
                        // do nothing                   
                    }
                }

                return result;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var dict = value as Dictionary<string, TSettings>;
                writer.WriteStartObject();
                foreach (var kvp in dict)
                {
                    if (kvp.Value == null)
                        continue;

                    writer.WritePropertyName(kvp.Key);
                    serializer.Serialize(writer, kvp.Value);
                }
                writer.WriteEndObject();
            }
        }

        private class SerializationHelper
        {
            private static JsonSerializerSettings _jss = new JsonSerializerSettings
            {
                Error = (sender, args) => { args.ErrorContext.Handled = true; },
                //TypeNameHandling = TypeNameHandling.All
            };

            static SerializationHelper()
            { 
                _jss.Converters.Add(new ProviderSettingsDicConverter<ProviderGeneralSettings, Providers.OpenAI.GeneralSettings>(SettingsTypeMapping.General));
                _jss.Converters.Add(new ProviderSettingsDicConverter<ProviderSecureSettings, Providers.OpenAI.SecureSettings>(SettingsTypeMapping.Secure));
            }

            public static string SerializeAsJsonString(object obj)
            {
                if (obj == null)
                {
                    return string.Empty;
                }

                return JsonConvert.SerializeObject(obj, _jss);
            }

            public static T DeserializeFromJsonString_FallbackToDefault<T>(string str) where T : new()
            {
                if (string.IsNullOrEmpty(str))
                {
                    return new T();
                }

                try
                {
                    return JsonConvert.DeserializeObject<T>(str, _jss);
                }
                catch
                {
                    return new T();
                }
            }
        }


        public readonly TGeneralSettings GeneralSettings;

        public readonly TSecureSettings SecureSettings;

        public PluginSettingsObject()
        {
            GeneralSettings = new TGeneralSettings();
            SecureSettings = new TSecureSettings();
        }

        public PluginSettingsObject(TGeneralSettings general, TSecureSettings secure)
        {
            GeneralSettings = general;
            SecureSettings = secure;
        }

        public PluginSettingsObject(PluginSettings serialized)
        {
            GeneralSettings = SerializationHelper.DeserializeFromJsonString_FallbackToDefault<TGeneralSettings>(serialized?.GeneralSettings);
            SecureSettings = SerializationHelper.DeserializeFromJsonString_FallbackToDefault<TSecureSettings>(serialized?.SecureSettings);
        }

        public virtual PluginSettings GetSerializedSettings()
        {
            return new PluginSettings(SerializationHelper.SerializeAsJsonString(GeneralSettings), SerializationHelper.SerializeAsJsonString(SecureSettings));
        }
    }


    enum RequestType
    {
        Plaintext = 0,
        OnlyFormattingWithXml = 1,
        OnlyFormattingWithHtml = 2,
        BothFormattingAndTagsWithXml = 3,
        BothFormattingAndTagsWithHtml = 4,
    }
}
