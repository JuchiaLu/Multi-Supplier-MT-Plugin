using System;
using System.Reflection;

namespace MultiSupplierMTPlugin.Localized
{
    class LocalizedKeyBase
    {
        protected readonly string _name;

        protected LocalizedKeyBase(string propertyName)
        {
            _name = propertyName;
        }

        public override string ToString()
        {
            return _name;
        }

        protected static void AutoInit<T>() where T : LocalizedKeyBase
        {
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (prop.PropertyType == typeof(T) && prop.GetValue(null) == null)
                {
                    var instance = (T)Activator.CreateInstance(typeof(T), prop.Name);
                    prop.SetValue(null, instance);
                }
            }
        }

        public static bool TryFromName<T>(string name, out T localizedKey) where T : LocalizedKeyBase
        {
            var property = typeof(T).GetProperty(name);

            localizedKey = property?.GetValue(null) as T;

            return localizedKey != null;
        }
    }


    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class LocalizedValueAttribute : Attribute
    {
        public string GUID { get; }

        public string EN_US { get; }

        public string ZH_CN { get; }

        public LocalizedValueAttribute(string guid, string en_us, string zh_cn)
        {
            GUID = guid;
            EN_US = en_us;
            ZH_CN = zh_cn;
        }
    }
}
