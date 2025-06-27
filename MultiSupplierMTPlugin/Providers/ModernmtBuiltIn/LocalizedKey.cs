using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.ModernmtBuiltIn
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

        
    }
}
