using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin
{
    public class RateLimitHelper
    {
        private readonly int maxThreadHold;

        private readonly SemaphoreSlim semaphoreSlim;

        private readonly int maxQueriesPerSecond;

        private readonly Queue<DateTime> requestTimestamps;

        public RateLimitHelper(int maxQueriesPerSecond, int maxThreadHold)
        {
            if (maxQueriesPerSecond > 0)
            {
                this.maxQueriesPerSecond = maxQueriesPerSecond;
                requestTimestamps = new Queue<DateTime>();
            }

            if (maxThreadHold > 0)
            {
                this.maxThreadHold = maxThreadHold;
                semaphoreSlim = new SemaphoreSlim(maxThreadHold);
            }
        }

        public int GetQpsWaittingMs()
        {
            if (requestTimestamps != null)
            {
                lock (requestTimestamps)
                {
                    // 移除超过一秒的时间戳
                    while (requestTimestamps.Count > 0 && (DateTime.Now - requestTimestamps.Peek()).TotalMilliseconds >= 1000)
                    {
                        requestTimestamps.Dequeue();
                    }

                    // 如果队列已满，计算等待时间并返回
                    if (requestTimestamps.Count >= maxQueriesPerSecond)
                    {
                        var timeToWait = (int)(1000 - (DateTime.Now - requestTimestamps.Peek()).TotalMilliseconds);
                        if (timeToWait > 0)
                        {
                            return timeToWait + 150;
                        }
                    }

                    // 将当前时间戳加入队列
                    requestTimestamps.Enqueue(DateTime.Now);
                }
            }

            return 0;
        }

        public async Task<bool> ThreadHoldWaitting()
        {
            if (semaphoreSlim != null)
            {
                await semaphoreSlim.WaitAsync();
            }

            return true;
        }

        public void ThreadHoldRelease()
        {
            if (semaphoreSlim != null)
            {
                semaphoreSlim.Release();
            }
        }
    }
}
