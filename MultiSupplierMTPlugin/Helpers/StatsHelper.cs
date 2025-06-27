using LiteDB;
using System;
using System.Threading;

namespace MultiSupplierMTPlugin.Helpers
{
    class StatsHelper
    {
        private static ILiteCollection<RequestStatsEntry> _collection;
        private static bool _useFallback;
        private static bool _initialized;
        private static readonly object _lock = new object();

        private static long requestSuccess;
        private static long requestFailed;

        public static void Init(LiteDatabase db, bool useFallback = false)
        {
            if (_initialized) return;

            lock (_lock)
            {
                if (_initialized) return;

                if (useFallback)
                {
                    _useFallback = true;
                    _initialized = true;
                    return;
                }

                try
                {
                    _collection = db.GetCollection<RequestStatsEntry>("request_stats");
                    _collection.EnsureIndex(x => x.Id, true);

                    var existing = _collection.FindById("global");
                    if (existing != null)
                    {
                        requestSuccess = existing.RequestSuccess;
                        requestFailed = existing.RequestFailed;
                    }
                    else
                    {
                        _collection.Upsert(new RequestStatsEntry
                        {
                            Id = "global",
                            RequestSuccess = 0,
                            RequestFailed = 0,
                        });
                    }
                }
                catch (Exception ex)
                {                    
                    _useFallback = true;
                    LoggingHelper.Warn("Database Stats initialization failed. Use the memory Stats: " + ex.Message);
                }

                _initialized = true;
            }
        }

        public static void IncrementRequestSuccess()
        {
            Interlocked.Increment(ref requestSuccess);
            PersistIfNeeded();
        }

        public static void IncrementRequestSuccess(long value)
        {
            Interlocked.Add(ref requestSuccess, value);
            PersistIfNeeded();
        }

        public static void IncrementRequestFailed()
        {
            Interlocked.Increment(ref requestFailed);
            PersistIfNeeded();
        }

        public static void IncrementRequestFailed(long value)
        {
            Interlocked.Add(ref requestFailed, value);
            PersistIfNeeded();
        }

        public static void Reset()
        {
            Interlocked.Exchange(ref requestSuccess, 0);
            Interlocked.Exchange(ref requestFailed, 0);
            PersistIfNeeded();
        }

        public static long GetRequestSuccess()
        {
            return Interlocked.Read(ref requestSuccess);
        }

        public static long GetRequestFailed()
        {
            return Interlocked.Read(ref requestFailed);
        }

        private static void PersistIfNeeded()
        {
            if (_useFallback) return;

            var entry = new RequestStatsEntry
            {
                Id = "global",
                RequestSuccess = Interlocked.Read(ref requestSuccess),
                RequestFailed = Interlocked.Read(ref requestFailed),
            };

            _collection.Upsert(entry);
        }

        private class RequestStatsEntry
        {
            [BsonId]
            public string Id { get; set; } = "global"; // 单条统计，ID 固定

            public long RequestSuccess { get; set; }

            public long RequestFailed { get; set; }
        }
    }
}
