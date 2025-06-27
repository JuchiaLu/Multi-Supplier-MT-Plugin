using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Huoshan
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


        [LocalizedValue("d4682b5e-a68b-49bb-9811-4d0138c0b50a", "Huoshan", "火山")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("134a02b6-6c85-4425-981c-36f0dd5e121f", "Access Key", "Access Key")]
        public static LocalizedKey LabelAccessKey { get; private set; }

        [LocalizedValue("6961769b-5c4f-4166-ad37-ea1f3fa756b7", "Secret Key", "Secret Key")]
        public static LocalizedKey LinkLabelSecretKey { get; private set; }
    }
}
