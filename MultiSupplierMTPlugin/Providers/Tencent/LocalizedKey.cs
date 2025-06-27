using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Tencent
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

        [LocalizedValue("44835cf9-2e46-401b-aafb-380bfa0b45c4", "Tencent", "腾讯")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("3b683478-2921-4ae5-89a4-ff32d98bfd57", "Secret Id", "Secret Id")]
        public static LocalizedKey LabelSecretId { get; private set; }

        [LocalizedValue("73ce8a1b-a18a-4ba6-b0da-e0f9dc61a31b", "Secret Key", "Secret Key")]
        public static LocalizedKey LinkLabelSecretKey { get; private set; }
    }
}
