using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MemoQ.Addins.Common.Framework;
using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Services;
using MultiSupplierMTPlugin.Helpers;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTPluginDirector : PluginDirectorBase, IModule
    {
        public const string PluginId = "MultiSupplier";

        private IEnvironment environment;

        public MultiSupplierMTPluginDirector()
        { 
        }

        #region IModule Members

        public bool IsActivated
        {   
            get { return true; }
        }

        public void Initialize(IModuleEnvironment env)
        {
        }

        public void Cleanup()
        {
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
            get { return "MultiSupplier"; }
        }

        public override string FriendlyName
        {
            get { return "Multi Supplier MT Plugin"; }
        }

        public override string CopyrightText
        {
            get { return "Copyright (C) Juchia"; }
        }

        public override Image DisplayIcon
        {
            get { return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MultiSupplierMTPlugin.Icon.bmp")); }
        }

        public override IEnvironment Environment
        {
            set
            {
                this.environment = value;

                //LocalizedHelper.SetEnvironment(value);
            }
        }

        public override PluginSettings EditOptions(IWin32Window parentForm, PluginSettings settings)
        {
            var options = new MultiSupplierMTOptions(settings);

            using (var form = new MultiSupplierMTOptionsForm(options, environment))
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    environment.PluginAvailabilityChanged();
                }
                return options.GetSerializedSettings();
            }
        }

        public override bool IsLanguagePairSupported(LanguagePairSupportedParams args)
        {
            var options = new MultiSupplierMTOptions(args.PluginSettings);

            var currentServiceProvider = ServiceHolder.GetService(options.GeneralSettings.CurrentServiceProvider);

            return currentServiceProvider.IsLanguagePairSupported(args.SourceLangCode, args.TargetLangCode);
        }

        public override IEngine2 CreateEngine(CreateEngineParams args)
        {
            var options = new MultiSupplierMTOptions(args.PluginSettings);

            var currentServiceProvider = ServiceHolder.GetService(options.GeneralSettings.CurrentServiceProvider);
            
            return new MultiSupplierMTEngine(options, currentServiceProvider, args.SourceLangCode, args.TargetLangCode);
        }

        #endregion
    }
}
