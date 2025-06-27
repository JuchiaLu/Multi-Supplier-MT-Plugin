using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Aliyun
{
    class LocalizedKey : LocalizedKeyBase
    {
        public LocalizedKey(string name) : base(name)
        {
        }

        static LocalizedKey()
        {
            AutoInit<LocalizedKey>();
        }

        [LocalizedValue("81752443-6399-441a-9243-82563c012d8f", "Aliyun", "阿里")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("b5661636-c435-49a7-81c6-cfd668a39e36", "Key Id", "Key Id")]
        public static LocalizedKey LabelKeyId { get; private set; }

        [LocalizedValue("61ceadf9-9ab8-4158-9faa-c7068d6d893c", "Key Secret", "Key Secret")]
        public static LocalizedKey LinkLabelKeySecret { get; private set; }

        [LocalizedValue("8e1fd442-84b4-4051-aa7e-2da7adef70c6", "Type", "版 本")]
        public static LocalizedKey LabelServiceType { get; private set; }

        [LocalizedValue("9ce291a1-d735-4b7b-b8a6-0a4fe9f58d27", "General", "普通版")]
        public static LocalizedKey RadioButtonGeneral { get; private set; }

        [LocalizedValue("18adb34c-014b-44fb-b7a7-86e7f90572f7", "Professional", "专业版")]
        public static LocalizedKey RadioButtonProfessional { get; private set; }
    }
}
