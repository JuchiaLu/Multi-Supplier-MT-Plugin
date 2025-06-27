using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiSupplierMTPlugin.Helpers
{
    static class LoggingHelper
    {
        private static readonly Logger _logger = new Logger();

        public static void Init(string logDir, string prefix, bool enable, LogLevel logLevel, int retentionDays)
        {
            _logger.Init(logDir, prefix, enable, logLevel, retentionDays);
        }

        public static void Debug(string message)
        {
            _logger.Log(message, LogLevel.Debug);
        }

        public static void Info(string message)
        {
            _logger.Log(message, LogLevel.Info);
        }

        public static void Warn(string message)
        {
            _logger.Log(message, LogLevel.Warn);
        }

        public static void Error(string message)
        {
            _logger.Log(message, LogLevel.Error);
        }        

        public static bool TryGetLogFilePath(out string logFilePath) 
        {
            return _logger.TryGetLogFilePath(out logFilePath);
        }

        public static bool Enable 
        {
            get => _logger.Enable;
            set => _logger.Enable = value;
        }

        public static LogLevel MinLogLevel
        {
            get => _logger.MinLogLevel;
            set => _logger.MinLogLevel = value;
        }

        public static void Dispose()
        {
            _logger.Dispose();
        }
    }

    sealed class Logger : IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;
        private BlockingCollection<string> _messageQueue;
        private Task _writerTask;

        private string _logDirectory;
        private string _filePrefix;
        private DateTime _currentDate;

        private int _retentionDays;

        private string _currentLogFile;
        
        private bool _isInitialized;

        public void Init(string logDir, string prefix, bool enable, LogLevel logLevel, int retentionDays)
        {
            if (_isInitialized) return;

            try
            {
                Directory.CreateDirectory(logDir);

                _logDirectory = logDir;
                _filePrefix = prefix;
                _currentDate = DateTime.Today;

                _currentLogFile = GetLogFilePath(_currentDate);

                _cancellationTokenSource = new CancellationTokenSource();
                _messageQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());
                _writerTask = Task.Run(() => ProcessQueueAsync(_cancellationTokenSource.Token));
                
                _isInitialized = true;

                Enable = enable;
                MinLogLevel = logLevel;
                _retentionDays = retentionDays;

                Task.Run(() => CleanupOldLogsAsync());
            }
            catch
            {
                _isInitialized = false;
            }
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (!_isInitialized || !Enable || logLevel < MinLogLevel) return;

            try
            {
                if (!_messageQueue.IsAddingCompleted)
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    _messageQueue.Add($"{timestamp} [{logLevel.ToString().ToUpper()}] - {message}");
                }
            }
            catch { } // 吞掉异常
        }

        public bool TryGetLogFilePath(out string logFilePath)
        {
            logFilePath = _isInitialized ? _currentLogFile : null;
            
            return _isInitialized;
        }

        public bool Enable { get; set; } = true;

        public LogLevel MinLogLevel { get; set; } = LogLevel.Info;


        private async Task ProcessQueueAsync(CancellationToken token)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(_currentLogFile, true, Encoding.UTF8);

                foreach (var message in _messageQueue.GetConsumingEnumerable(token))
                {
                    var today = DateTime.Today;
                    if (today != _currentDate)
                    {
                        await writer.FlushAsync();
                        writer.Dispose();

                        _currentDate = today;
                        _currentLogFile = GetLogFilePath(_currentDate);
                        writer = new StreamWriter(_currentLogFile, true, Encoding.UTF8);
                    }

                    await writer.WriteLineAsync(message);
                    await writer.FlushAsync();
                }
            }
            catch { } // 吞掉异常
            finally
            {
                writer?.Dispose();
            }
        }

        private string GetLogFilePath(DateTime date)
        {
            string fileName = $"{_filePrefix}.{date:yyyy-MM-dd}.txt";
            return Path.Combine(_logDirectory, fileName);
        }

        private async Task CleanupOldLogsAsync()
        {
            if (_retentionDays < 0) return;

            try
            {
                DateTime threshold = DateTime.Today.AddDays(-_retentionDays);

                var files = Directory.GetFiles(_logDirectory, $"{_filePrefix}.*.txt");

                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var datePart = Path.GetFileNameWithoutExtension(fileName).Replace(_filePrefix + ".", "");

                    if (DateTime.TryParseExact(datePart, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var fileDate))
                    {
                        if (fileDate < threshold)
                        {
                            try
                            {
                                RecycleBinHelper.MoveToRecycleBin(file);
                            }
                            catch
                            {
                                Log($"Log cleanup in progress: failed to move '{file}' to Recycle Bin.", LogLevel.Warn);
                            }
                        }
                    }
                }
            }
            catch { } // 吞掉异常
        }

        public void Dispose()
        {
            if (!_isInitialized) return;

            try
            {
                _cancellationTokenSource?.Cancel();
                _messageQueue?.CompleteAdding();
                _writerTask?.Wait();

                _messageQueue?.Dispose();
                _cancellationTokenSource?.Dispose();
            }
            catch { } // 吞掉异常
            finally
            {
                _isInitialized = false;
            }
        }
    }

    enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error,
    }
}