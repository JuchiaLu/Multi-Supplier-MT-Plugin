using MultiSupplierMTPlugin.Localized;

namespace MultiSupplierMTPlugin.Providers.DeepLBuiltIn
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
