using System.Collections.Concurrent;

namespace MultiSupplierMTPlugin.Helpers
{
    public class CacheHelper
    {
        private static readonly ConcurrentDictionary<string, string> cache = new ConcurrentDictionary<string, string>();

        public static void Store(string key, string value)
        {
            cache[key] = value;
        }

        public static bool TryGet(string key, out string value) 
        {
            return cache.TryGetValue(key, out value);
        }

        public static void Clear()
        {
            cache.Clear();
        }

        public static int Count()
        {
            return cache.Count;
        }
    }
}
