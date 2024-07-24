using System.Threading;

namespace MultiSupplierMTPlugin.Helpers
{
    public class StatsHelper
    {
        // 请求数应该不会超出 long, 所以暂不考虑 long 溢出问题。
        private static long requestTotal;
        private static long requestFailed;

        public static void IncrementRequestTotal()
        {
            Interlocked.Increment(ref requestTotal);
        }

        public static void IncrementRequestTotal(long value)
        {
            Interlocked.Add(ref requestTotal, value);
        }

        public static void IncrementRequestFailed()
        {
            Interlocked.Increment(ref requestFailed);
        }

        public static void IncrementRequestFailed(long value)
        {
            Interlocked.Add(ref requestFailed, value);
        }

        public static long GetRequestTotal()
        {
            return Interlocked.Read(ref requestTotal);
        }

        public static long GetRequestFailed()
        {
            return Interlocked.Read(ref requestFailed);
        }

        public static double GetFailureRate()
        {
            long total = GetRequestTotal();
            if (total == 0) return 0;
            return (double)GetRequestFailed() / total;
        }

        public static (long Total, long Failed, double FailureRate) GetStats()
        {
            long total = GetRequestTotal();
            long failed = GetRequestFailed();
            double failureRate = total == 0 ? 0 : (double)failed / total;
            return (total, failed, failureRate);
        }

        public static void Reset()
        {
            Interlocked.Exchange(ref requestTotal, 0);
            Interlocked.Exchange(ref requestFailed, 0);
        }
    }
}
