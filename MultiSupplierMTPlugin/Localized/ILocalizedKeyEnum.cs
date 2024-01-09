using System;
using System.Collections.Generic;
using System.Reflection;

namespace MultiSupplierMTPlugin.Localized
{
    public class ILocalizedKeyEnum
    {
        protected readonly string name;

        private static readonly Dictionary<Type, FieldInfo[]> TypeFieldsCache = new Dictionary<Type, FieldInfo[]>();

        protected ILocalizedKeyEnum(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }

        public static bool TryFromName<TEnum>(string name, out TEnum result) where TEnum : ILocalizedKeyEnum
        {
            FieldInfo[] fields;
            if (!TypeFieldsCache.TryGetValue(typeof(TEnum), out fields))
            {
                fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);
                TypeFieldsCache[typeof(TEnum)] = fields;
            }

            foreach (FieldInfo field in fields)
            {
                TEnum enumValue = (TEnum)field.GetValue(null);

                if (enumValue.name == name)
                {
                    result = enumValue;
                    return true;
                }
            }

            result = null;
            return false;
        }
    }


    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class LocalizedKeyAttribute : Attribute
    {
        public string GUID { get; }

        public string DefaultValue { get; }

        public LocalizedKeyAttribute(string guid, string defaultValue)
        {
            GUID = guid;
            DefaultValue = defaultValue;
        }
    }
}
