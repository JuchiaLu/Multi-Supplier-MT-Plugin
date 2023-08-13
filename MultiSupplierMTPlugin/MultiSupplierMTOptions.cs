using MemoQ.MTInterfaces;
using System.Collections.Generic;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTOptions : PluginSettingsObject<MultiSupplierMTGeneralOptions, MultiSupplierMTSecureOptions>
    {
        public MultiSupplierMTOptions(PluginSettings serializedSettings)
            : base(serializedSettings)
        {

        }

        public MultiSupplierMTOptions(MultiSupplierMTGeneralOptions generalOptions, MultiSupplierMTSecureOptions secureOptions)
            : base(generalOptions, secureOptions)
        {

        }
    }

    public enum RequestType
    {
        Plaintext = 0,
        OnlyFormattingWithXml = 1,
        OnlyFormattingWithHtml = 2,
        BothFormattingAndTagsWithXml = 3,
        BothFormattingAndTagsWithHtml = 4,
    }

    public class BaiduGeneralOptions
    {
        public bool Checked = false;
    }

    public class TencentGeneralOptions
    {
        public bool Checked = false;
    }

    public class AliyunGeneralOptions 
    {
        public bool Checked = false;

        public string ServiceType = "general";
    }

    public class HuoshanGeneralOptions
    {
        public bool Checked = false;
    }

    public class CaiyunGeneralOptions
    {
        public bool Checked = false;
    }

    public class NiutransGeneralOptions
    {
        public bool Checked = false;
    }

    public class YoudaoGeneralOptions
    {
        public bool Checked = false;
    }

    public class XunfeiGeneralOptions
    {
        public bool Checked = false;
    }

    public class BaiduSecureOptions
    {
        public string AppId = string.Empty;
        public string AppKey = string.Empty;
    }

    public class TencentSecureOptions
    {
        public string SecretId = string.Empty;
        public string SecretKey = string.Empty;
    }

    public class AliyunSecureOptions
    {
        public string AccessKeyId = string.Empty;
        public string AccessKeySecret = string.Empty;
    }

    public class HuoshanSecureOptions
    {
        public string AccessKey = string.Empty;
        public string SecretKey = string.Empty;
    }

    public class CaiyunSecureOptions
    {
        public string Token = string.Empty;
    }

    public class NiutransSecureOptions
    {
        public string Apikey = string.Empty;
    }

    public class YoudaoSecureOptions
    {
        public string AppKey = string.Empty;
        public string AppSecret = string.Empty;
    }

    public class XunfeiSecureOptions
    {
        public string AppId = string.Empty;
        public string ApiKey = string.Empty;
        public string ApiSecret = string.Empty;
    }

    public class MultiSupplierMTGeneralOptions
    {
        public bool EnableCache = true;
        public bool InsertRequiredTagsToEnd = false;
        public bool NormalizeWhitespaceAroundTags = false;

        public string CurrentServiceProvider = "Microsoft Built In";

        public RequestType RequestType = RequestType.Plaintext;

        public BaiduGeneralOptions BaiduGeneralOptions = new BaiduGeneralOptions();

        public TencentGeneralOptions TencentGeneralOptions = new TencentGeneralOptions();

        public AliyunGeneralOptions AliyunGeneralOptions = new AliyunGeneralOptions();

        public HuoshanGeneralOptions HuoshanGeneralOptions = new HuoshanGeneralOptions();

        public CaiyunGeneralOptions CaiyunGeneralOptions = new CaiyunGeneralOptions();

        public NiutransGeneralOptions NiutransGeneralOptions = new NiutransGeneralOptions();

        public YoudaoGeneralOptions YoudaoGeneralOptions = new YoudaoGeneralOptions();

        public XunfeiGeneralOptions XunfeiGeneralOptions = new XunfeiGeneralOptions();
    }

    public class MultiSupplierMTSecureOptions
    {
        public BaiduSecureOptions BaiduSecureOptions = new BaiduSecureOptions();

        public TencentSecureOptions TencentSecureOptions = new TencentSecureOptions();

        public AliyunSecureOptions AliyunSecureOptions = new AliyunSecureOptions();

        public HuoshanSecureOptions HuoshanSecureOptions = new HuoshanSecureOptions();

        public CaiyunSecureOptions CaiyunSecureOptions = new CaiyunSecureOptions();

        public NiutransSecureOptions NiutransSecureOptions = new NiutransSecureOptions();

        public YoudaoSecureOptions YoudaoSecureOptions = new YoudaoSecureOptions();

        public XunfeiSecureOptions XunfeiSecureOptions = new XunfeiSecureOptions();
    }
}
