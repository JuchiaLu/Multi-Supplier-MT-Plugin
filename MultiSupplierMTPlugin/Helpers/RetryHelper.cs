using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Helpers
{
    class RetryHelper
    {
        private readonly int _failedTimeoutMs;
        private readonly int _retryWaitingMs;
        private readonly int _numberOfRetries;

        public RetryHelper(int failedTimeoutMs, int retryWaitingMs, int numberOfRetries)
        {
            this._failedTimeoutMs = Math.Max(failedTimeoutMs, 0);
            this._retryWaitingMs = Math.Max(retryWaitingMs, 0);
            this._numberOfRetries = Math.Max(numberOfRetries, 0);
        }

        public async Task<T> ExecWithRetryAsync<T>(Func<CancellationToken, Task<T>> action)
        {
            var exceptions = new List<Exception>();

            for (int attempt = 0; attempt <= _numberOfRetries; attempt++)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                try
                {
                    if (_failedTimeoutMs <= 0)
                    {
                        return await action(cts.Token);
                    }

                    var mainTask = action(cts.Token);
                    var timeoutTask = Task.Delay(_failedTimeoutMs, cts.Token);

                    var completedTask = await Task.WhenAny(mainTask, timeoutTask);

                    if (completedTask == mainTask)
                    {
                        return await mainTask; // 正常完成
                    }

                    // 超时处理：取消任务并等待其响应
                    cts.Cancel();
                    try { await mainTask; } catch { /* 忽略取消或异常 */ }

                    throw new TimeoutException(LLH.G(LLK.RetryHelper_Exception_TimeoutMsg, _failedTimeoutMs));
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);

                    if (attempt < _numberOfRetries)
                    {
                        await Task.Delay(_retryWaitingMs);
                    }
                }
                finally
                {
                    cts.Cancel();
                    cts.Dispose();
                }
            }

            throw new AggregateException(
                LLH.G(LLK.RetryHelper_Exception_AllAttemptFailMsg, _numberOfRetries + 1),
                exceptions
            );
        }

        public Task ExecWithRetryAsync(Func<CancellationToken, Task> action)
        {
            return ExecWithRetryAsync(async (ct) => { await action(ct); return true; });
        }

        public T ExecWithRetry<T>(Func<T> action)
        {
            return ExecWithRetryAsync(ct => Task.FromResult(action())).GetAwaiter().GetResult();
        }

        public void ExecWithRetry(Action action)
        {
            ExecWithRetry(() => { action(); return true; });
        }
    }
}
