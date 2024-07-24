using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Helpers
{
    public class LoggingHelper : IDisposable
    {
        private readonly string logFilePath;
        private readonly BlockingCollection<string> messageQueue;
        private readonly Task writerTask;
        private readonly CancellationTokenSource cancellationTokenSource;

        public LoggingHelper(string logFilePath)
        {
            this.logFilePath = logFilePath;
            messageQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());
            writerTask = Task.Run(ProcessLogQueue);
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void Log(string message)
        {
            if (!messageQueue.IsAddingCompleted)
            {
                messageQueue.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {message}");
            }
        }

        private async Task ProcessLogQueue()
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true, System.Text.Encoding.UTF8))
            {
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    string message;
                    try
                    {
                        message = messageQueue.Take(cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }

                    await writer.WriteLineAsync(message);
                    await writer.FlushAsync();
                }
            }
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
            messageQueue.CompleteAdding();
            writerTask.Wait();
            messageQueue.Dispose();
            cancellationTokenSource.Dispose();
        }
    }
}