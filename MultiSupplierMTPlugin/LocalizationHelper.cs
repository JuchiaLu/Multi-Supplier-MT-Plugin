using System.Collections.Generic;
using MemoQ.MTInterfaces;

namespace MultiSupplierMTPlugin
{
    public class LocalizationHelper
    {
        private static readonly Dictionary<string, string> chineseTexts = new Dictionary<string, string>()
        {
            {"OptionForm", "多提供商机器翻译插件"},
            {"OptionForm.labelServiceProvider", "提供商"},
            {"OptionForm.comboBoxServiceProvider.Microsoft Built In", "微软翻译（内置）"},
            {"OptionForm.comboBoxServiceProvider.Google Built In", "谷歌翻译（内置）"},
            {"OptionForm.comboBoxServiceProvider.Baidu", "百度翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Tencent", "腾讯翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Aliyun", "阿里翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Huoshan", "火山翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Caiyun", "彩云翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Niutrans", "小牛翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Youdao", "有道翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Xunfei", "讯飞翻译（需配置）"},
            {"OptionForm.comboBoxServiceProvider.Test", "测试翻译（内置）"},
            {"OptionForm.labelRequestType", "请求类型"},
            {"OptionForm.comboBoxRequestType.Plaintext", "仅纯文本"},
            {"OptionForm.comboBoxRequestType.OnlyFormattingWithXml", "包括格式标记，（用 Xml 表示）"},
            {"OptionForm.comboBoxRequestType.OnlyFormattingWithHtml", "包括格式标记，（用 Html 表示）"},
            {"OptionForm.comboBoxRequestType.BothFormattingAndTagsWithXml", "包括格式标记和内联标签，（用 Xml 表示）"},
            {"OptionForm.comboBoxRequestType.BothFormattingAndTagsWithHtml", "包括格式标记和内联标签，（用 Html 表示）"},
            {"OptionForm.checkBoxTagsToEnd", "将原文中的内联标签追加到译文后"},
            {"OptionForm.checkBoxNormalizeWhitespace", "归一化译文中内联标签旁边的空格"},
            {"OptionForm.checkBoxTranslateCache", "启用翻译缓存"},
            {"OptionForm.buttonOK", "确定"},
            {"OptionForm.buttonCancel", "取消"},

            {"AliyunOptionForm", "阿里翻译"},
            {"AliyunOptionForm.labelAppId", "Key Id"},
            {"AliyunOptionForm.labelAppKey", "Key Secret"},
            {"AliyunOptionForm.labelServiceType", "版 本"},
            {"AliyunOptionForm.radioButtonGeneral", "普通版"},
            {"AliyunOptionForm.radioButtonProfessional", "专业版"},
            {"AliyunOptionForm.linkLabelCheck", "检测"},
            {"AliyunOptionForm.buttonOK", "确认"},
            {"AliyunOptionForm.buttonCancel", "取消"},
            {"AliyunOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"AliyunOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"BaiduOptionForm", "百度翻译"},
            {"BaiduOptionForm.labelAppId", "App Id"},
            {"BaiduOptionForm.labelAppKey", "App Key"},
            {"BaiduOptionForm.linkLabelCheck", "检测"},
            {"BaiduOptionForm.buttonOK", "确认"},
            {"BaiduOptionForm.buttonCancel", "取消"},
            {"BaiduOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"BaiduOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"TencentOptionForm", "腾讯翻译"},
            {"TencentOptionForm.labelAppId", "Secret Id"},
            {"TencentOptionForm.labelAppKey", "Secret Key"},
            {"TencentOptionForm.linkLabelCheck", "检测"},
            {"TencentOptionForm.buttonOK", "确认"},
            {"TencentOptionForm.buttonCancel", "取消"},
            {"TencentOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"TencentOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"HuoshanOptionForm", "火山翻译"},
            {"HuoshanOptionForm.labelAppId", "Access Key"},
            {"HuoshanOptionForm.labelAppKey", "Secret Key"},
            {"HuoshanOptionForm.linkLabelCheck", "检测"},
            {"HuoshanOptionForm.buttonOK", "确认"},
            {"HuoshanOptionForm.buttonCancel", "取消"},
            {"HuoshanOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"HuoshanOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"CaiyunOptionForm", "彩云翻译"},
            {"CaiyunOptionForm.labelToken", "Token"},
            {"CaiyunOptionForm.linkLabelCheck", "检测"},
            {"CaiyunOptionForm.buttonOK", "确认"},
            {"CaiyunOptionForm.buttonCancel", "取消"},
            {"CaiyunOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"CaiyunOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"NiutransOptionForm", "小牛翻译"},
            {"NiutransOptionForm.labelApikey", "Api Key"},
            {"NiutransOptionForm.linkLabelCheck", "检测"},
            {"NiutransOptionForm.buttonOK", "确认"},
            {"NiutransOptionForm.buttonCancel", "取消"},
            {"NiutransOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"NiutransOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"YoudaoOptionForm", "有道翻译"},
            {"YoudaoOptionForm.labelAppId", "App Key"},
            {"YoudaoOptionForm.labelAppKey", "App Secret"},
            {"YoudaoOptionForm.linkLabelCheck", "检测"},
            {"YoudaoOptionForm.buttonOK", "确认"},
            {"YoudaoOptionForm.buttonCancel", "取消"},
            {"YoudaoOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"YoudaoOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

            {"XunfeiOptionForm", "讯飞翻译"},
            {"XunfeiOptionForm.labelAppId", "Api Id"},
            {"XunfeiOptionForm.labelApiKey", "Api Key"},
            {"XunfeiOptionForm.labelApiSecret", "Api Secret"},
            {"XunfeiOptionForm.linkLabelCheck", "检测"},
            {"XunfeiOptionForm.buttonOK", "确认"},
            {"XunfeiOptionForm.buttonCancel", "取消"},
            {"XunfeiOptionForm.labelCheckResult.CheckedSuccees", "检测成功！"},
            {"XunfeiOptionForm.labelCheckResult.CheckedFail", "检测失败！"},

        };

        private static readonly Dictionary<string, string> defaultTexts = new Dictionary<string, string>()
        {
            {"OptionForm", "Multi Supplier MT Plugin"},
            {"OptionForm.labelServiceProvider", "Service Provider"},
            {"OptionForm.comboBoxServiceProvider.Microsoft Built In", "Microsoft (Built In)"},
            {"OptionForm.comboBoxServiceProvider.Google Built In", "Google (Built In)"},
            {"OptionForm.comboBoxServiceProvider.Baidu", "Baidu (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Tencent", "Tencent (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Aliyun", "Aliyun (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Huoshan", "Huoshan (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Caiyun", "Caiyun (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Niutrans", "Niutrans (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Youdao", "Youdao (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Xunfei", "Xunfei (Need Config)"},
            {"OptionForm.comboBoxServiceProvider.Test", "Test (Built In)"},
            {"OptionForm.labelRequestType", "Request Type"},
            {"OptionForm.comboBoxRequestType.Plaintext", "Plaintext"},
            {"OptionForm.comboBoxRequestType.OnlyFormattingWithXml", "Include Formatting With Xml"},
            {"OptionForm.comboBoxRequestType.OnlyFormattingWithHtml", "Include Formatting With Html"},
            {"OptionForm.comboBoxRequestType.BothFormattingAndTagsWithXml", "Include Formatting And Tags With Xml"},
            {"OptionForm.comboBoxRequestType.BothFormattingAndTagsWithHtml", "Include Formatting And Tags With Html"},
            {"OptionForm.checkBoxTagsToEnd", "Insert Required Tags To End"},
            {"OptionForm.checkBoxNormalizeWhitespace", "Normalize Whitespace Around Tags"},
            {"OptionForm.checkBoxTranslateCache", "Enable Translate Cache"},
            {"OptionForm.buttonOK", "OK"},
            {"OptionForm.buttonCancel", "Cancel"},

            {"AliyunOptionForm", "Aliyun"},
            {"AliyunOptionForm.labelAppId", "Key Id"},
            {"AliyunOptionForm.labelAppKey", "Key Secret"},
            {"AliyunOptionForm.labelServiceType", "Type"},
            {"AliyunOptionForm.radioButtonGeneral", "General"},
            {"AliyunOptionForm.radioButtonProfessional", "Professional"},
            {"AliyunOptionForm.linkLabelCheck", "Check"},
            {"AliyunOptionForm.buttonOK", "OK"},
            {"AliyunOptionForm.buttonCancel", "Cancel"},
            {"AliyunOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"AliyunOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"BaiduOptionForm", "Baidu"},
            {"BaiduOptionForm.labelAppId", "App Id"},
            {"BaiduOptionForm.labelAppKey", "App Key"},
            {"BaiduOptionForm.linkLabelCheck", "Check"},
            {"BaiduOptionForm.buttonOK", "OK"},
            {"BaiduOptionForm.buttonCancel", "Cancel"},
            {"BaiduOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"BaiduOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"TencentOptionForm", "Tencent"},
            {"TencentOptionForm.labelAppId", "Secret Id"},
            {"TencentOptionForm.labelAppKey", "Secret Key"},
            {"TencentOptionForm.linkLabelCheck", "Check"},
            {"TencentOptionForm.buttonOK", "OK"},
            {"TencentOptionForm.buttonCancel", "Cancel"},
            {"TencentOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"TencentOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"HuoshanOptionForm", "Huoshan"},
            {"HuoshanOptionForm.labelAppId", "Access Key"},
            {"HuoshanOptionForm.labelAppKey", "Secret Key"},
            {"HuoshanOptionForm.linkLabelCheck", "Check"},
            {"HuoshanOptionForm.buttonOK", "OK"},
            {"HuoshanOptionForm.buttonCancel", "Cancel"},
            {"HuoshanOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"HuoshanOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"CaiyunOptionForm", "Caiyun"},
            {"CaiyunOptionForm.labelToken", "Token"},
            {"CaiyunOptionForm.linkLabelCheck", "Check"},
            {"CaiyunOptionForm.buttonOK", "OK"},
            {"CaiyunOptionForm.buttonCancel", "Cancel"},
            {"CaiyunOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"CaiyunOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"NiutransOptionForm", "Niutrans"},
            {"NiutransOptionForm.labelApikey", "Api Key"},
            {"NiutransOptionForm.linkLabelCheck", "Check"},
            {"NiutransOptionForm.buttonOK", "OK"},
            {"NiutransOptionForm.buttonCancel", "Cancel"},
            {"NiutransOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"NiutransOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"YoudaoOptionForm", "Youdao"},
            {"YoudaoOptionForm.labelAppId", "App Key"},
            {"YoudaoOptionForm.labelAppKey", "App Secret"},
            {"YoudaoOptionForm.linkLabelCheck", "Check"},
            {"YoudaoOptionForm.buttonOK", "OK"},
            {"YoudaoOptionForm.buttonCancel", "Cancel"},
            {"YoudaoOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"YoudaoOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},

            {"XunfeiOptionForm", "Xunfei"},
            {"XunfeiOptionForm.labelAppId", "App Id"},
            {"XunfeiOptionForm.labelApiKey", "Api Key"},
            {"XunfeiOptionForm.labelApiSecret", "Api Secret"},
            {"XunfeiOptionForm.linkLabelCheck", "Check"},
            {"XunfeiOptionForm.buttonOK", "OK"},
            {"XunfeiOptionForm.buttonCancel", "Cancel"},
            {"XunfeiOptionForm.labelCheckResult.CheckedSuccees", "Checked Succeess !"},
            {"XunfeiOptionForm.labelCheckResult.CheckedFail", "Checked Fail !"},
        };

        private static LocalizationHelper instance = new LocalizationHelper();

        private IEnvironment environment;

        private LocalizationHelper(){ }
        
        public static LocalizationHelper Instance
        {
            get { return instance; }
        }

        public void SetEnvironment(IEnvironment environment)
        {
            this.environment = environment;
        }

        public string GetResourceString(string key)
        {
            string localizedText = ""; // = environment.GetResourceString(MultiSupplierMTPluginDirector.PluginId, key);

            if (string.IsNullOrEmpty(localizedText))
            {
                if ("zh-Hans".Equals(environment.UILang))
                    chineseTexts.TryGetValue(key, out localizedText);
                else
                    defaultTexts.TryGetValue(key, out localizedText);
            }

            if (string.IsNullOrEmpty(localizedText))
                localizedText = key;

            return localizedText;
        }
    }
}
