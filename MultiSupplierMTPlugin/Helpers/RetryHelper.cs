using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Helpers
{
    public class RetryHelper
    {
        private readonly int failedTimeoutMs;
        private readonly int retryWaitingMs;
        private readonly int numberOfRetries;

        public RetryHelper(int failedTimeoutMs, int retryWaitingMs, int numberOfRetries)
        {
            this.failedTimeoutMs = failedTimeoutMs;
            this.retryWaitingMs = retryWaitingMs;
            this.numberOfRetries = numberOfRetries;
        }

        public async Task<T> ExecWithRetryAsync<T>(Func<CancellationToken, Task<T>> action)
        {
            List<Exception> exceptions = new List<Exception>();
            var cts = new CancellationTokenSource();

            try
            {
                for (int attempt = 0; attempt <= numberOfRetries; attempt++)
                {
                    try
                    {
                        if (failedTimeoutMs <= 0)
                        {
                            return await action(cts.Token);
                        }
                        else
                        {
                            var mainTask = action(cts.Token);
                            var timeoutTask = Task.Delay(failedTimeoutMs, cts.Token);

                            var completedTask = await Task.WhenAny(mainTask, timeoutTask);

                            if (completedTask == mainTask)
                            {
                                return await mainTask;
                            }

                            throw new TimeoutException(LLH.G(LLK.RetryHelper_Exception_TimeoutMsg, failedTimeoutMs));
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex);

                        cts.Cancel();
                        cts.Dispose();

                        cts = new CancellationTokenSource();

                        await Task.Delay(retryWaitingMs);
                    }
                }
                throw new AggregateException(LLH.G(LLK.RetryHelper_Exception_AllAttemptFailMsg, numberOfRetries+1), exceptions);
            }
            finally
            {
                cts.Cancel();
                cts.Dispose();
            }
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
