using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.Papago
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

        [LocalizedValue("76845133-ca2a-4cd5-a5a2-3218e656b381", "Papago", "Papago")]
        public static LocalizedKey Form { get; private set; }

        [LocalizedValue("445a5731-6292-4d94-9b54-a7bf456058c2", "Client ID", "Client ID")]
        public static LocalizedKey LabelClientID { get; private set; }

        [LocalizedValue("f66898c7-cc1c-4b2d-9a46-ce31c53dff2f", "Client Secret", "Client Secret")]
        public static LocalizedKey LinkLabelClientSecret { get; private set; }
    }
}
