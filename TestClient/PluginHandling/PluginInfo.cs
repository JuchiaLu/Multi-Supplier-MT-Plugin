using System;
using System.Xml;
using System.Xml.Serialization;
using MemoQ.MTInterfaces;

namespace MT_SDK
{
    /// <summary>
    /// Contains information about a single plugin.
    /// 包含有关单个插件的信息。
    /// </summary>
    /// <remarks>
    /// Abstracts two distinct interfaces plugins can implement; common handling by two distinct implementation of this interface.
    /// 抽象出两个不同的插件可以实现的接口; 通过这个接口的两个不同的实现进行公共处理。
    /// </remarks>
    internal interface IPluginInfo
    {
        bool StoringTranslationSupported { get; }
        IPluginDirectorCommon Director { get; }
        bool IsPluginConfigured { get; }
        bool IsPluginEnabled { get; set; }

        void SetEnvironment(DummyEnvironment environment);
        bool IsLanguagePairSupported(string langCode1, string langCode2);
        bool IsLanguagePairSupported(LanguagePairSupportedParams args);
        ICurrentEngine CreateEngine(string langCode1, string langCode2);
        void ShowOptionsForm(System.Windows.Forms.Form parentForm);
    }

    /// <summary>
    /// Factory methods to instantiate see <see cref="IPluginInfo"/>
    /// 要实例化的工厂方法请参见 < see cref = “ IPluginInfo”/>
    /// </summary>
    internal static class PluginInfoFactory
    {
        public static IPluginInfo Create(IPluginDirector director) => new PluginInfo(director);
        public static IPluginInfo Create(IPluginDirector2 director) => new PluginInfo2(director);
    }

    /// <summary>
    /// Technical base class for <see cref="PluginInfo"/> and <see cref="PluginInfo2"/>.
    /// 用于 < see cref = “ PluginInfo”/> 和 < see cref = “ PluginInfo2”/> 的技术基类。
    /// </summary>
    internal abstract class PluginInfoBase<TPluginDirector> : IPluginInfo where TPluginDirector : IPluginDirectorCommon
    {
        public TPluginDirector Director { get; private set; }

        protected PluginInfoBase(TPluginDirector director) { this.Director = director; }

        IPluginDirectorCommon IPluginInfo.Director => Director;
        public override string ToString() => Director.FriendlyName;
        public void SetEnvironment(DummyEnvironment environment) => Director.Environment = environment;

        public abstract bool StoringTranslationSupported { get; }
        public abstract ICurrentEngine CreateEngine(string langCode1, string langCode2);
        public abstract void ShowOptionsForm(System.Windows.Forms.Form parentForm);

        public abstract bool IsPluginConfigured { get; }
        public abstract bool IsPluginEnabled { get; set; }

        public virtual bool IsLanguagePairSupported(string srcLangCode, string trgLangCode) => false;
        public virtual bool IsLanguagePairSupported(LanguagePairSupportedParams args) => false;
    }

    /// <summary>
    /// Describes a plugin that implements <see cref="IPluginDirector"/> interface.
    /// 描述实现 < see cref = “ IPluginDirector”/> 接口的插件。
    /// </summary>
    internal class PluginInfo : PluginInfoBase<IPluginDirector>
    {
        public PluginInfo(IPluginDirector director)
            : base(director)
        { }

        public override bool StoringTranslationSupported => false;
        public override ICurrentEngine CreateEngine(string langCode1, string langCode2) => new CurrentEngine(Director.CreateEngine(langCode1, langCode2));
        public override void ShowOptionsForm(System.Windows.Forms.Form parentForm) => Director.ShowOptionsForm(parentForm);
        public override bool IsPluginConfigured { get { return (Director as MemoQ.Addins.Common.Framework.IModuleEx).PluginConfigured; } }
        public override bool IsPluginEnabled
        {
            get { return (Director as MemoQ.Addins.Common.Framework.IModuleEx).PluginEnabled; }
            set { (Director as MemoQ.Addins.Common.Framework.IModuleEx).PluginEnabled = value; }
        }

        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode) => this.Director.IsLanguagePairSupported(srcLangCode, trgLangCode);
    }

    /// <summary>
    /// Describes a plugin that implements <see cref="IPluginDirector2"/> interface.
    /// 描述实现 < see cref = “ IPluginDirector2”/> 接口的插件。
    /// </summary>
    internal class PluginInfo2 : PluginInfoBase<IPluginDirector2>
    {
        public override bool IsPluginEnabled { get; set; }
        public PluginSettings PluginSettings = new PluginSettings(null, null);

        public PluginInfo2(IPluginDirector2 director)
            : base(director)
        {
            var settingsFromFile = PluginSettingsSerializationHelper.TryLoadSettingsFromFile(director.PluginID);
            if (settingsFromFile != null)
                this.PluginSettings = settingsFromFile;
        }

        public override bool StoringTranslationSupported => Director.StoringTranslationSupported;
        public override bool IsPluginConfigured { get { return PluginSettings?.GeneralSettings != null; } }
        public override ICurrentEngine CreateEngine(string langCode1, string langCode2) => new CurrentEngine2(Director.CreateEngine(new CreateEngineParams(langCode1, langCode2, this.PluginSettings)));

        public override void ShowOptionsForm(System.Windows.Forms.Form parentForm)
        {
            this.PluginSettings = Director.EditOptions(parentForm, this.PluginSettings);
            PluginSettingsSerializationHelper.SaveSettingsToFile(Director.PluginID, this.PluginSettings);
        }

        public override bool IsLanguagePairSupported(LanguagePairSupportedParams args) => this.Director.IsLanguagePairSupported(args);
        public override bool IsLanguagePairSupported(string srcLangCode, string trgLangCode) => this.Director.IsLanguagePairSupported(new LanguagePairSupportedParams(srcLangCode, trgLangCode, PluginSettings));
    }

    internal static class PluginSettingsSerializationHelper
    {
        public static PluginSettings TryLoadSettingsFromFile(string pluginId)
        {
            var file = getSerializedSettingsFilePath(pluginId);
            if (System.IO.File.Exists(file))
                return MemoQ.Addins.Common.Utils.SerializationHelper.DeserializeXMLFallbackToNullOnError<SerializedPluginSettings>(file).ToMT();
            else
                return null;
        }

        public static void SaveSettingsToFile(string pluginId, PluginSettings settings)
        {
            if (settings == null)
                return;
            MemoQ.Addins.Common.Utils.SerializationHelper.SerializeXML(new SerializedPluginSettings(settings), getSerializedSettingsFilePath(pluginId));
        }

        private static string getSerializedSettingsFilePath(string pluginId) => System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, $"Settings.{pluginId}.xml");
    }

    /// <summary>
    /// Mimics the way memoQ saves the settings into MT Settings resources.
    /// 模仿 memQ 将设置保存到 MT 设置资源中的方式。
    /// </summary>
    public class SerializedPluginSettings
    {
        private string generalSettings;
        /// <summary>
        /// XmlIgnore because serialized as CData in <see cref="GeneralSettingsCData"/>
        /// XmlIgnore，因为在 < see cref = “ GeneralSettingsCData”/> 中序列化为 CData
        /// </summary>
        [XmlIgnore]
        public string GeneralSettings
        {
            get { return this.generalSettings; }
            set { this.generalSettings = value; }
        }

        /// <summary>
        /// get-set property for XmlSerializer to serialize in CData
        /// XmlSerializer 序列化为 CData 的 get-set 属性
        /// </summary>
        [XmlElement(nameof(GeneralSettings))]
        public XmlCDataSection GeneralSettingsCData
        {
            get { return new XmlDocument().CreateCDataSection(GeneralSettings); }
            set { GeneralSettings = value.Value; }
        }

        private string secureSettings;
        /// <summary>
        /// XmlIgnore because serialized as CData in <see cref="SecureSettingsCData"/>
        /// XmlIgnore，因为在 < see cref = “ SecureSettingsCData”/> 中序列化为 CData
        /// </summary>
        [XmlIgnore]
        public string SecureSettings
        {
            get { return this.secureSettings; }
            set { this.secureSettings = value; }
        }

        /// <summary>
        /// get-set property for XmlSerializer to serialize in CData
        /// XmlSerializer 序列化为 CData 的 get-set 属性
        /// </summary>
        [XmlElement(nameof(SecureSettings))]
        public XmlCDataSection SecureSettingsCData
        {
            get { return new XmlDocument().CreateCDataSection(SecureSettings); }
            set { SecureSettings = value.Value; }
        }

        /// <summary>
        /// for xml serialization
        /// 用于 xml 序列化
        /// </summary>
        public SerializedPluginSettings()
        {
        }

        public SerializedPluginSettings(string generalSetting, string secureSettings)
        {
            this.generalSettings = generalSetting;
            this.secureSettings = secureSettings;
        }

        public SerializedPluginSettings(MemoQ.MTInterfaces.PluginSettings settings)
        {
            this.generalSettings = settings?.GeneralSettings;
            this.secureSettings = settings?.SecureSettings;
        }

        public MemoQ.MTInterfaces.PluginSettings ToMT()
        {
            return new MemoQ.MTInterfaces.PluginSettings(this.generalSettings, this.secureSettings);
        }
    }
}
