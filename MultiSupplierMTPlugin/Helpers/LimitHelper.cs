using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Helpers
{
    public class LimitHelper
    {
        // 正在运行的最大线程数
        private readonly int maxThreadHold;

        // 滑动日志的窗口内的最大请求数
        private readonly int maxRequestsPerWindow;

        // 滑动日志的窗口大小，单位毫秒
        private readonly int windowSizeMs;

        // 每个请求之间的最小间隔时间，单位毫秒
        private readonly int minIntervalMs;

        private readonly SemaphoreSlim semaphoreSlim;

        private readonly Queue<long> requestTimestamps;

        public LimitHelper(int maxThreadHold, int maxRequestsPerWindow, int windowSizeMs = 1000, double smoothness = 1.0)
        {
            if (windowSizeMs <= 0)
            {
                throw new ArgumentException("windowSizeMs must be greater than 0");
            }

            if (smoothness < 0 && smoothness > 1)
            {
                throw new ArgumentException("smoothness must be between 0 and 1");
            }

            if (maxThreadHold > 0)
            {
                this.maxThreadHold = maxThreadHold;
                semaphoreSlim = new SemaphoreSlim(maxThreadHold);
            }

            if (maxRequestsPerWindow > 0)
            {
                this.maxRequestsPerWindow = maxRequestsPerWindow;
                this.windowSizeMs = windowSizeMs;
                minIntervalMs = (int)(windowSizeMs / (double)maxRequestsPerWindow * smoothness);
                requestTimestamps = new Queue<long>();
            }
        }

        public int GetRateWaittingMs()
        {
            if (requestTimestamps != null)
            {
                lock (requestTimestamps)
                {
                    var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                    // 移除超过一秒（假设 windowSizeMs = 1000）的时间戳
                    while (requestTimestamps.Count > 0 && (now - requestTimestamps.Peek()) >= windowSizeMs)
                    {
                        requestTimestamps.Dequeue();
                    }

                    if (requestTimestamps.Count >= maxRequestsPerWindow)
                    {
                        //队列已满，需要等待，计算最短等待时间（ 注：该等待时间不是线程可执行时间，而是线程再次 GetQpwWaittingMs 的等待时间，因为可能会有多个线程在等待）
                        var timeToWaitMs = (int)(windowSizeMs - (now - requestTimestamps.Peek()));
                        return Math.Max(timeToWaitMs, 1); // timeToWaitMs 理论上一定大于零，因为不在窗口内的时间戳都被移除了，为了安全返回一个和 1 比较的较大值
                    }
                    else
                    {
                        // 队列未满，
                        
                        if (requestTimestamps.Count > 0)
                        {
                            // 最近一个请求执行时间到当前时间的间隔
                            var timeSinceLastRequest = (now - requestTimestamps.Last());
                            
                            // 如果这个间隔小于最小间隔时间，需要等待
                            if (timeSinceLastRequest < minIntervalMs)
                            {
                                var timeToWaitMs = (int)(minIntervalMs - timeSinceLastRequest);
                                return Math.Max(timeToWaitMs, 1);
                            }
                        }

                        // 无需等待，将当前时间戳加入队列
                        requestTimestamps.Enqueue(now);
                        return 0;
                    }
                }
            }
            return 0;
        }

        public async Task ThreadHoldWaitting()
        {
            if (semaphoreSlim != null)
            {
                await semaphoreSlim.WaitAsync();
            }
        }

        public int ThreadHoldRelease()
        {
            if (semaphoreSlim != null)
            {
                return semaphoreSlim.Release();
            }
            return 0;
        }
    }
}
