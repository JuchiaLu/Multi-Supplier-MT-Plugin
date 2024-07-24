using MemoQ.Addins.Common.Framework;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTPluginDirector : PluginDirectorBase, IModule
    {
        private readonly string dllFileName;

        private IEnvironment environment;


        private MultiSupplierMTOptions options;

        private LoggingHelper loggingHelper;

        public MultiSupplierMTPluginDirector()
        {
            dllFileName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
        }

        #region IModule Members

        public bool IsActivated
        {   
            get { return true; }
        }

        public void Initialize(IModuleEnvironment env)
        {
            // 从 memoQ 8.2 开始，机器翻译插件不再管理（存储和加载）自己的设置，但显然接口更新没跟上，
            // 这里居然获取不到 PluginSettings，所以我们只能在 CreateEngine() 时初始化某些实例变量。
        }

        public void Cleanup()
        {
            if (loggingHelper != null)
            {
                loggingHelper.Dispose();
            }
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
            get
            {
                if (dllFileName.Equals("MultiSupplierMTPlugin"))
                {
                    return "MultiSupplier";// 兼容旧版本，防止已有配置文件失效
                }
                else
                {
                    return dllFileName;
                }
            }
        }

        public override string FriendlyName
        {
            get 
            {
                if (options != null)
                {
                    if (options.GeneralSettings.EnableCustomDisplayName)
                    {
                        return $"{options.GeneralSettings.CustomDisplayName}\n({dllFileName})";
                    }
                    else
                    {
                        string rovider = options.GeneralSettings.CurrentServiceProvider;

                        if (LocalizedKeyEnumBase.TryFromName<LLK>("Form_ComboBoxServiceProvider_" + rovider, out var keyEnum))
                        {
                            return $"Multi Supplier - {LLH.G(keyEnum)}\n({dllFileName})";
                        }
                        else
                        {
                            return $"Multi Supplier - {rovider}\n({dllFileName})";
                        }
                    }
                }
                else
                {
                    return $"Multi Supplier MT Plugin\n({dllFileName})";
                }
            }
        }

        public override string CopyrightText
        {
            get 
            {
                return $"{dllFileName}, Copyright (C) Juchia";
            }
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
            set
            {
                this.environment = value;
            }
        }

        public override PluginSettings EditOptions(IWin32Window parentForm, PluginSettings settings)
        {
            options = new MultiSupplierMTOptions(settings);

            using (var form = new MultiSupplierMTOptionsForm(options, environment))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    environment.PluginAvailabilityChanged();
                }
            }

            return options.GetSerializedSettings();
        }

        public override bool IsLanguagePairSupported(LanguagePairSupportedParams args)
        {
            options = new MultiSupplierMTOptions(args.PluginSettings);

            return ServiceHelper.GetService(options.GeneralSettings.CurrentServiceProvider).IsLanguagePairSupported(args.SourceLangCode, args.TargetLangCode);
        }

        public override IEngine2 CreateEngine(CreateEngineParams args)
        {
            options = new MultiSupplierMTOptions(args.PluginSettings);

            var mtService = ServiceHelper.GetService(options.GeneralSettings.CurrentServiceProvider);
            
            LimitHelper limitHelper;
            RetryHelper retryHelper;
            if (options.GeneralSettings.EnableCustomRequestLimit)
            {
                limitHelper = new LimitHelper(
                    options.GeneralSettings.MaxRequestsHold,
                    options.GeneralSettings.MaxRequestsPerWindow,
                    options.GeneralSettings.WindowSizeMs,
                    options.GeneralSettings.RequestSmoothness
                    );

                retryHelper = new RetryHelper(
                    options.GeneralSettings.FailedTimeoutMs,
                    options.GeneralSettings.RetryWaitingMs,
                    options.GeneralSettings.NumberOfRetries
                    );
            }
            else
            {
                limitHelper = new LimitHelper(
                    mtService.MaxThreadHold(),
                    mtService.MaxQueriesPerWindow(),
                    mtService.WindowSizeMs(),
                    mtService.Smoothness()
                    );

                retryHelper = new RetryHelper(
                   mtService.FailedTimeoutMs(),
                   mtService.RetryWaitingMs(),
                   mtService.NumberOfRetries()
                   );
            }

            if (options.GeneralSettings.EnableStatsAndLog && loggingHelper == null)
            {
                try
                {
                    string logdir = Path.Combine(options.GeneralSettings.DataDir, "Log");
                    string logFile = $"{dllFileName}.{DateTime.Now:yyyy-MM-dd}.log";
                    if (!Directory.Exists(logdir))
                    {
                        Directory.CreateDirectory(logdir);
                    }
                    loggingHelper = new LoggingHelper(Path.Combine(logdir, logFile));
                }
                catch
                {
                    // do nothing
                }
            }

            // TODO：多个 MultiSupplierMTEngine 应该共用一个 RateLimitHelper，否则一对多翻译时限流失效。
            return new MultiSupplierMTEngine(args.SourceLangCode, args.TargetLangCode, options, mtService, limitHelper, retryHelper, loggingHelper);
        }

        #endregion
    }
}
