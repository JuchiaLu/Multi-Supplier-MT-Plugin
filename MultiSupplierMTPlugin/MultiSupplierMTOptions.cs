using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Options;

namespace MultiSupplierMTPlugin
{
    public class MultiSupplierMTOptions : PluginSettingsObject<MultiSupplierMTGeneralOptions, MultiSupplierMTSecureOptions>
    {
        public MultiSupplierMTOptions(PluginSettings serializedSettings) : base(serializedSettings)
        {

        }

        public MultiSupplierMTOptions(MultiSupplierMTGeneralOptions generalOptions, MultiSupplierMTSecureOptions secureOptions) : base(generalOptions, secureOptions)
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

    public class MultiSupplierMTGeneralOptions
    {
        public bool EnableCache = true;
        public bool InsertRequiredTagsToEnd = false;
        public bool NormalizeWhitespaceAroundTags = false;

        public string CurrentServiceProvider = "MicrosoftBuiltIn";

        public RequestType RequestType = RequestType.Plaintext;

        public BaiduGeneralOptions BaiduGeneralOptions = new BaiduGeneralOptions();

        public TencentGeneralOptions TencentGeneralOptions = new TencentGeneralOptions();

        public AliyunGeneralOptions AliyunGeneralOptions = new AliyunGeneralOptions();

        public HuoshanGeneralOptions HuoshanGeneralOptions = new HuoshanGeneralOptions();

        public CaiyunGeneralOptions CaiyunGeneralOptions = new CaiyunGeneralOptions();

        public NiutransGeneralOptions NiutransGeneralOptions = new NiutransGeneralOptions();

        public YoudaoGeneralOptions YoudaoGeneralOptions = new YoudaoGeneralOptions();

        public XunfeiGeneralOptions XunfeiGeneralOptions = new XunfeiGeneralOptions();

        public OpenaiGeneralOptions OpenaiGeneralOptions = new OpenaiGeneralOptions();
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

        public OpenaiSecureOptions OpenaiSecureOptions = new OpenaiSecureOptions();
    }
}
