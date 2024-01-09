using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiSupplierMTPlugin.Localized
{
    public class LocalizedHelper
    {
        private static readonly ResourceManager resourceManager;

        static LocalizedHelper()
        {
            resourceManager = new ResourceManager("MultiSupplierMTPlugin.Languages.Lang", Assembly.GetExecutingAssembly());
            
            cultureInfo = Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        public static CultureInfo cultureInfo { get; set; }

        public static string G(ILocalizedKeyEnum key, params object[] slots)
        {
            var keyString = key.ToString();

            try
            {
                var fieldInfo = key.GetType().GetField(keyString);
                var localizedKeyAttribute = (LocalizedKeyAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(LocalizedKeyAttribute));

                var guid = localizedKeyAttribute.GUID;
                var defaultValue = localizedKeyAttribute.DefaultValue;

                try
                {
                    return string.Format(resourceManager.GetString(guid, cultureInfo), slots);
                }
                catch
                {
                    return string.Format(defaultValue, slots);
                }
            }
            catch
            {
                return keyString;
            }
        }
    }
}
