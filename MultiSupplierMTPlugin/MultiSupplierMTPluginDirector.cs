using MemoQ.Addins.Common.Framework;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTPluginDirector : PluginDirectorBase, IModule
    {
        private readonly string _dllFileName;

        private IEnvironment _environment;

        private MultiSupplierMTOptions _mtOptions;

        private static readonly object _lock = new object();

        public MultiSupplierMTPluginDirector()
        {
            _dllFileName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
        }

        #region IModule Members

        public bool IsActivated
        {   
            get { return true; }
        }

        public void Initialize(IModuleEnvironment env)
        {
            // 从 memoQ 8.2 开始，机器翻译插件不再管理（存储和加载）自己的设置，但显然接口更新没跟上，
            // 这里居然获取不到 PluginSettings，所以我们只能在 CreateEngine() 等能获取到配置的地方初始化。
        }

        public void Cleanup()
        {
            LoggingHelper.Dispose();
        }

        #endregion

        #region IPluginDirector Members

        public override bool InteractiveSupported
        {
            get { return true; }
        }

        public override bool BatchSupported
        {
            get { return true; }
        }

        public override bool SupportFuzzyForwarding 
        {
            get { return true; }
        }

        public override bool StoringTranslationSupported
        {
            get { return true; }
        }

        public override string PluginID
        {
            get { return _dllFileName; }
        }

        public override string FriendlyName
        {
            get 
            {
                if (_mtOptions == null)
                    return $"Multi Supplier MT Plugin\r\n({_dllFileName})";

                if (_mtOptions.GeneralSettings.EnableCustomDisplayName)
                    return $"{_mtOptions.GeneralSettings.CustomDisplayName}\r\n({_dllFileName})";

                string provider = _mtOptions.GeneralSettings.CurrentServiceProvider;
                var service = ServiceHelper.GetServiceOrFallback(provider);
                var localizedName = ServiceLocalizedNameHelper.GetWithSuffix(service.UniqueName, service.IsLLM, service.IsBuiltIn);
                return $"Multi Supplier - {localizedName}\r\n({_dllFileName})";
            }
        }

        public override string CopyrightText
        {
            get  { return $"{_dllFileName}, Copyright (C) Juchia"; }
        }

        public override Image DisplayIcon
        {
            get 
            {
                // TODO 根据当前选的提供商，显示不同提供商的图标
                return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MultiSupplierMTPlugin.Icon.png")); ; 
            }
        }

        public override IEnvironment Environment
        {
            set { this._environment = value; }
        }

        public override PluginSettings EditOptions(IWin32Window parentForm, PluginSettings settings)
        {
            var mtOptions = GetOrInitializeOptions(settings);

            using (var form = new MultiSupplierMTOptionsForm(mtOptions))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    mtOptions.GeneralSettings.RuningTimes += 1;
                    _environment.PluginAvailabilityChanged();
                }
            }

            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            mtOptions.GeneralSettings.Version = version;
            mtOptions.GeneralSettings.Version = version;

            return mtOptions.GetSerializedSettings();
        }

        public override bool IsLanguagePairSupported(LanguagePairSupportedParams args)
        {
            var mtOptions = GetOrInitializeOptions(args.PluginSettings);

            var provider  =  mtOptions.GeneralSettings.CurrentServiceProvider;
            var service = ServiceHelper.GetServiceOrFallback(provider);

            return service.IsLanguagePairSupported(args.SourceLangCode, args.TargetLangCode);
        }

        public override IEngine2 CreateEngine(CreateEngineParams args)
        {
            var mtOptions = GetOrInitializeOptions(args.PluginSettings);

            var provider = mtOptions.GeneralSettings.CurrentServiceProvider;
            var service = ServiceHelper.GetServiceOrFallback(provider);

            LimitHelper limitHelper;
            RetryHelper retryHelper;
            if (mtOptions.GeneralSettings.EnableCustomRequestLimit)
            {
                limitHelper = new LimitHelper(
                    mtOptions.GeneralSettings.MaxRequestsHold,
                    mtOptions.GeneralSettings.MaxRequestsPerWindow,
                    mtOptions.GeneralSettings.WindowSizeMs,
                    mtOptions.GeneralSettings.RequestSmoothness
                    );

                retryHelper = new RetryHelper(
                    mtOptions.GeneralSettings.FailedTimeoutMs,
                    mtOptions.GeneralSettings.RetryWaitingMs,
                    mtOptions.GeneralSettings.NumberOfRetries
                    );
            }
            else
            {
                limitHelper = new LimitHelper(
                    service.MaxThreadHold,
                    service.MaxQueriesPerWindow,
                    service.WindowSizeMs,
                    service.Smoothness
                    );

                retryHelper = new RetryHelper(
                   service.FailedTimeoutMs,
                   service.RetryWaitingMs,
                   service.NumberOfRetries
                );
            }

            // TODO：多个 MultiSupplierMTEngine 应该共用一个 RateLimitHelper，否则一对多翻译时限流失效。
            return new MultiSupplierMTEngine(mtOptions, limitHelper, retryHelper, service, mtOptions.GeneralSettings.RequestType, args.SourceLangCode, args.TargetLangCode);
        }

        #endregion

        private MultiSupplierMTOptions GetOrInitializeOptions(PluginSettings pluginSettings)
        {
            if (_mtOptions != null)
                return _mtOptions;

            lock (_lock)
            {
                if (_mtOptions != null)
                    return _mtOptions;

                var mtOptions = new MultiSupplierMTOptions(pluginSettings);

                var general = mtOptions.GeneralSettings;

                OptionsHelper.Init(mtOptions);

                LocalizedHelper.Init(general.UILanguage);

                LoggingHelper.Init(Path.Combine(general.DataDir, "Log"), _dllFileName, general.EnableStatsAndLog, general.LogLevel, general.LogRetentionDays);

                ServiceHelper.Init(general.CustomOpenAICompatibleServiceInfos);

                DatabaseHelper.Init(Path.Combine(general.DataDir, "Cache", "Translation"), _dllFileName);

                CacheHelper.Init(DatabaseHelper.LiteDatebase);

                StatsHelper.Init(DatabaseHelper.LiteDatebase);

                ContextHelper.Init(_dllFileName);

                _mtOptions = mtOptions;

                return mtOptions;
            }
        }
    }
}
