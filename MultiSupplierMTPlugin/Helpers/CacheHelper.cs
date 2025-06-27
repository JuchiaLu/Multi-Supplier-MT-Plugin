using LiteDB;
using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace MultiSupplierMTPlugin.Helpers
{
    class CacheHelper
    {
        private static ILiteCollection<TranslationEntry> _collection;

        private static bool _useFallback;
        private static readonly ConcurrentDictionary<string, string> _fallbackCache = new ConcurrentDictionary<string, string>();

        private static bool _initialized;
        private static readonly object _lock = new object();

        public static void Init(LiteDatabase db, bool memoryCache = false)
        {
            if (_initialized) return;

            lock (_lock)
            {
                if (_initialized) return;

                if (memoryCache)
                {
                    _useFallback = true;
                    _initialized = true;
                    return;
                }

                try
                {
                    _collection = db.GetCollection<TranslationEntry>("translation_cache");
                    _collection.EnsureIndex(x => x.Id, true);
                }
                catch (Exception ex)
                {
                    _useFallback = true;
                    LoggingHelper.Warn("Database cache initialization failed. Use the memory cache: " + ex.Message);
                }

                _initialized = true;
            }
        }

        public static void Store(string provider, string format, string srcLang, string tgtLang, string srcText, string tgtText)
        {
            string id = GetId(provider, format, srcLang, tgtLang, srcText);

            if (_useFallback)
            {
                _fallbackCache[id] = tgtText;
                return;
            }

            var entry = new TranslationEntry
            {
                Id = id,
                Provider = provider,
                Format = format,
                SrcLang = srcLang,
                TgtLang = tgtLang,
                SrcText = srcText,
                TgtText = tgtText,
                CreatedAt = DateTime.UtcNow
            };

            _collection.Upsert(entry);
        }

        public static bool TryGet(string provider, string format, string srcLang, string tgtLang, string srcText, out string tgtText)
        {
            string id = GetId(provider, format, srcLang, tgtLang, srcText);
            tgtText = null;

            if (_useFallback)
                return _fallbackCache.TryGetValue(id, out tgtText);

            var entry = _collection.FindById(id);
            if (entry != null)
            {
                tgtText = entry.TgtText;
                return true;
            }

            return false;
        }

        public static void Clear()
        {
            if (_useFallback)
            {
                _fallbackCache.Clear();
            }
            else
            {
                _collection.DeleteAll();
            }
        }

        public static long Count()
        {
            return _useFallback ? _fallbackCache.Count : _collection.LongCount();
        }

        private static string GetId(string provider, string format, string srcLang, string tgtLang, string srcText)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes($"{provider}{format}{srcLang}{tgtLang}{srcText}"));
                return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private class TranslationEntry
        {
            [BsonId]
            public string Id { get; set; }

            public string Provider { get; set; } 

            public string Format { get; set; }

            public string SrcLang { get; set; }

            public string TgtLang { get; set; }

            public string SrcText { get; set; }

            public string TgtText { get; set; }

            public DateTime CreatedAt { get; set; }
        }
    }
}
