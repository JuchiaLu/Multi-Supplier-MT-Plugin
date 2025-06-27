using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.ProvidersCommon.Options.LLM;
using MultiSupplierMTPlugin.ProvidersCommon.Options.NMT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin
{
    interface MultiSupplierMTService
    {
        string UniqueName { get; set; }

        bool IsAvailable { get; set; }

        bool IsBuiltIn { get; set; }

        bool IsLLM { get; set; }

        bool IsXmlSupported { get; set; }

        bool IsHtmlSupported { get; set; }

        bool IsBatchSupported { get; set; }

        int MaxSegments { get; set; }

        int MaxCharacters { get; set; }

        int MaxQueriesPerWindow { get; set; }

        int WindowSizeMs { get; set; }

        double Smoothness { get; set; }

        int MaxThreadHold { get; set; }

        int FailedTimeoutMs { get; set; }

        int RetryWaitingMs { get; set; }

        int NumberOfRetries { get; set; }

        string ApiKeyLink { get; set; }
        
        string ApiDocLink { get; set; }

        ProviderOptions GetDefaultOptions();

        ProviderOptions ShowConfig();

        Task Check(ProviderOptions tempOptions);
        
        bool IsLanguagePairSupported(string srcLangCode, string trgLangCode);

        Task<List<string>> TranslateAsync(List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken, ProviderOptions tempOptions = null);
    }

    abstract class MultiSupplierMTService<TGeneralSettings, TSecureSettings> : MultiSupplierMTService
        where TGeneralSettings : ProviderGeneralSettings, new()  where TSecureSettings : ProviderSecureSettings, new() 
    {
        protected MultiSupplierMTOptions _mtOptions;

        protected MultiSupplierMTGeneralSettings _mtGeneralSettings;

        protected MultiSupplierMTSecureSettings _mtSecureSettings;

        protected ProviderOptions _options;

        protected TGeneralSettings _generalSettings;

        protected TSecureSettings _secureSettings;

        protected MultiSupplierMTService(MultiSupplierMTOptions mtOptions, ProviderOptions options)
        {
            this._mtOptions = mtOptions;
            this._mtGeneralSettings = mtOptions.GeneralSettings;
            this._mtSecureSettings = mtOptions.SecureSettings;

            
            this._generalSettings = options?.GeneralSettings as TGeneralSettings ?? new TGeneralSettings();
            this._secureSettings = options?.SecureSettings as TSecureSettings ?? new TSecureSettings();
            
            this._options = options ?? new ProviderOptions(this._generalSettings, this._secureSettings);
        }

        public abstract string UniqueName { get; set; }
        public abstract bool IsAvailable { get; set; }
        public abstract bool IsBuiltIn { get; set; }
        public abstract bool IsLLM { get; set; }
        public abstract bool IsXmlSupported { get; set; }
        public abstract bool IsHtmlSupported { get; set; }
        public abstract bool IsBatchSupported { get; set; }
        public abstract int MaxSegments { get; set; }
        public abstract int MaxCharacters { get; set; }
        public abstract int MaxQueriesPerWindow { get; set; }
        public abstract int WindowSizeMs { get; set; }
        public abstract double Smoothness { get; set; }
        public abstract int MaxThreadHold { get; set; }
        public abstract int FailedTimeoutMs { get; set; }
        public abstract int RetryWaitingMs { get; set; }
        public abstract int NumberOfRetries { get; set; }
        public abstract string ApiKeyLink { get; set; }
        public abstract string ApiDocLink { get; set; }

        public abstract Dictionary<string, string> SupportLangDic { get; set; }

        public abstract ProviderOptions ShowConfig();

        public async Task Check(ProviderOptions tempOptions)
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
            {
                var localizedName = ServiceLocalizedNameHelper.Get(UniqueName);

                try
                {
                    await TranslateAsync(new List<string> { "test" }, "eng", "zho-CN", null, null, null, cts.Token, tempOptions);
                }
                catch (OperationCanceledException ex) when (cts.IsCancellationRequested)
                {
                    var msg = "Timeout after 30 seconds";
                    LoggingHelper.Warn($"{localizedName} check exception: {msg}");
                    throw new Exception(msg);
                }
                catch (Exception ex)
                {
                    LoggingHelper.Warn($"{localizedName} check exception: {ex.Message}");
                    throw ex;
                }
            }
        }

        public virtual bool IsLanguagePairSupported(string srcLangCode, string trgLangCode)
        {
            return SupportLangDic.ContainsKey(srcLangCode) && SupportLangDic.ContainsKey(trgLangCode);
        }

        public abstract Task<List<string>> TranslateAsync(List<string> texts, string srcLangCode, string trgLangCode, List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData, CancellationToken cToken, ProviderOptions tempOptions = null);

        protected (TGeneralSettings g, TSecureSettings s) ResolveOptions(ProviderOptions tempOptions)
        {
            if (tempOptions == null)
                return (_generalSettings, _secureSettings);

            return (
                tempOptions.GeneralSettings as TGeneralSettings ?? _generalSettings,
                tempOptions.SecureSettings as TSecureSettings ?? _secureSettings
            );
        }

        public ProviderOptions GetDefaultOptions()
        {
            return new ProviderOptions(new TGeneralSettings(), new TSecureSettings());
        }
    }


    interface NMTBaseService : MultiSupplierMTService
    {
        // TODO NMT 提供商也共用一个配置界面
    }

    abstract class NMTBaseService<TGeneralSettings, TSecureSettings> : MultiSupplierMTService<TGeneralSettings, TSecureSettings>, NMTBaseService
        where TGeneralSettings : NMTBaseGeneralSettings, new() where TSecureSettings : NMTBaseSecureSettings, new()
    {
        protected NMTBaseService(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options)
        {

        }
    }


    interface LLMBaseService : MultiSupplierMTService
    {
        string ModelsLink { get; set; }

        ModelItem[] BuildInModels { get; set; }

        Task<List<string>> ListModels(ProviderOptions tempOptions);
    }

    abstract class LLMBaseService<TGeneralSettings, TSecureSettings> : MultiSupplierMTService<TGeneralSettings, TSecureSettings>, LLMBaseService
        where TGeneralSettings : LLMBaseGeneralSettings, new() where TSecureSettings : LLMBaseSecureSettings, new()
    {
        protected LLMBaseService(MultiSupplierMTOptions mtOptions, ProviderOptions options) : base(mtOptions, options)
        {
        }

        public abstract string ModelsLink { get; set; }
        public abstract ModelItem[] BuildInModels { get; set; }

        public abstract Task<List<string>> ListModels(CancellationToken cToken, ProviderOptions tempOptions);


        public async Task<List<string>> ListModels(ProviderOptions tempOptions)
        {
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
            {
                var localizedName = ServiceLocalizedNameHelper.Get(UniqueName);

                try
                {
                    var result = await ListModels(cts.Token, tempOptions);

                    if (result.Count == 0)
                        throw new Exception("server return empty model list");

                    return result;
                }
                catch (OperationCanceledException ex) when (cts.IsCancellationRequested)
                {
                    var msg = "Timeout after 10 seconds";
                    LoggingHelper.Warn($"{localizedName} list models exception: {msg}");
                    throw new Exception(msg);
                }
                catch (Exception ex)
                {
                    LoggingHelper.Warn($"{localizedName} list models exception: {ex.Message}");
                    throw ex;
                }
            }
        }


        protected abstract Task<string> TranslateAsync(
            TGeneralSettings g, TSecureSettings s,
            string systemPrompt, string userPrompt,
            List<string> texts, string srcLang, string tgtLang,
            List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData,
            CancellationToken cToken);


        public override async Task<List<string>> TranslateAsync(
            List<string> texts, string srcLang, string tgtLang,
            List<string> tmSources, List<string> tmTargets, MTRequestMetadata metaData,
            CancellationToken cToken, ProviderOptions tempOptions = null)
        {
            // 1.决定使用哪套配置
            var (g, s) = ResolveOptions(tempOptions);

            // 2.服务本地化名字，用在日志记录时
            var localizedName = ServiceLocalizedNameHelper.Get(UniqueName);

            // 3.决定使用哪套提示词：是否使用模板、是否批量翻译
            string systemPrompt, userPrompt;
            if (string.IsNullOrEmpty(g.PromptTemplateId))
            {
                systemPrompt = g.EnableBathTranslate ? g.BathTranslateSystemPrompt : g.SystemPrompt;
                userPrompt = g.EnableBathTranslate ? g.BathTranslateUserPrompt : g.UserPrompt;
            }
            else
            {
                var template = g.PromptTemplateId == "Default"
                    ? PromptTemplate.GetDefault()
                    : _mtGeneralSettings.LLMCommon.PromptTemplates.FirstOrDefault(p => p.ID == g.PromptTemplateId);

                if (template == null)
                    throw new Exception("Using a deleted prompt template. Please reconfigure.");

                systemPrompt = g.EnableBathTranslate ? template.BathTranslateSystemPrompt : template.SystemPrompt;
                userPrompt = g.EnableBathTranslate ? template.BathTranslateUserPrompt : template.UserPrompt;
            }

            // 4.解析提示词占位符 (TODO 摘要生成自定义一个方法，而不是共用翻译方法，否则参数太长了)
            (systemPrompt, userPrompt) = PromptHelper.Parse(
                systemPrompt, userPrompt,
                _mtOptions, _options, SupportLangDic, this,
                texts, srcLang, tgtLang, tmSources, tmTargets, metaData
                );

            // 5.日志记录最终解析后的提示词
            LoggingHelper.Info($"{localizedName} Request\r\n[System Prompt: ]\r\n{systemPrompt}\r\n[User Prompt: ]\r\n{userPrompt}");

            // 子类实现
            var content = await TranslateAsync(g, s, systemPrompt, userPrompt, texts, srcLang, tgtLang, tmSources, tmTargets, metaData, cToken);

            // 14.是否批量翻译，以及批量翻译时的结果解析
            var result = g.EnableBathTranslate
                ? BathTranslateHelper.Deserialize(g.BathTranslateSchema, texts.Count, content)
                : new List<string> { content };

            // 15.返回最终结果
            return result;
        }
    }
}
