using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.DeepLX
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

        [LocalizedValue("d15bd1ef-a7bc-4c12-ac94-84be2fb40ec3", "DeepLX", "DeepLX")]
        public static LocalizedKey DeepLX { get; private set; }

        [LocalizedValue("0f41fb44-c096-423d-b842-6854872772aa", "Server", "Server")]
        public static LocalizedKey LabelServer { get; private set; }

        [LocalizedValue("58f2179a-5e51-45ec-a941-f66e81401e01", "Auth Key", "Auth Key")]
        public static LocalizedKey LinkLabelAuthKey { get; private set; }

        [LocalizedValue("a989f61e-dfc6-48cf-a6e0-3cdd54cc9690", "Endpoint", "Endpoint")]
        public static LocalizedKey LabelEndpoint { get; private set; }

        [LocalizedValue("4c9d9ec6-b291-47d6-a61a-6c2e19eb19c8", "Free", "Free")]
        public static LocalizedKey RadioFree { get; private set; }

        [LocalizedValue("d830be1b-53c6-4cc8-ba7d-3e08b8caa829", "Pro", "Pro")]
        public static LocalizedKey RadioPro { get; private set; }

        [LocalizedValue("d931b7f7-8b7a-4426-a646-88a72c6b56e0", "Official", "Official")]
        public static LocalizedKey RadioOfficial { get; private set; }
    }
}
