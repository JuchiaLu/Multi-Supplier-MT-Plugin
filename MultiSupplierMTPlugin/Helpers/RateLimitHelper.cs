using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Helpers
{
    public class RateLimitHelper
    {
        // 滑动日志的窗口大小，单位毫秒
        private readonly int windowSizeMs;

        // 滑动日志的窗口内的最大请求数
        private readonly int maxQueriesPerWindow;

        // 正在运行的最大线程数
        private readonly int maxThreadHold;

        private readonly SemaphoreSlim semaphoreSlim;

        private readonly Queue<DateTime> requestTimestamps;

        public RateLimitHelper(int maxQueriesPerWindow, int maxThreadHold, int windowSizeMs = 1000)
        {
            if (maxQueriesPerWindow > 0)
            {
                this.maxQueriesPerWindow = maxQueriesPerWindow;
                this.windowSizeMs = windowSizeMs;
                requestTimestamps = new Queue<DateTime>();
            }

            if (maxThreadHold > 0)
            {
                this.maxThreadHold = maxThreadHold;
                semaphoreSlim = new SemaphoreSlim(maxThreadHold);
            }
        }

        public int GetQpwWaittingMs()
        {
            if (requestTimestamps != null)
            {
                lock (requestTimestamps)
                {
                    var now = DateTime.Now;

                    // 移除超过一秒（假设 windowSizeMs = 1000）的时间戳
                    while (requestTimestamps.Count > 0 && (now - requestTimestamps.Peek()).TotalMilliseconds >= windowSizeMs)
                    {
                        requestTimestamps.Dequeue();
                    }

                    if (requestTimestamps.Count >= maxQueriesPerWindow)
                    {
                        //队列已满，需要等待，计算最短等待时间（ 注：该等待时间不是线程可执行时间，而是线程再次 GetQpwWaittingMs 的等待时间，因为可能会有多个线程在等待）
                        var timeToWaitMs = (int)(windowSizeMs - (now - requestTimestamps.Peek()).TotalMilliseconds);
                        return timeToWaitMs; // timeToWaitMs 一定大于零，因为不在窗口内的时间戳都被移除了
                    }
                    else
                    {
                        // 队列未满，无需等待，将当前时间戳加入队列
                        requestTimestamps.Enqueue(now);
                        return 0;
                    }
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
