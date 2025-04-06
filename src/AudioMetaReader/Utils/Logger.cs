using Serilog;

namespace AudioMetaReader.Utils
{
    public static class Logger
    {
        private static ILogger _logger;

        static Logger()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/audiometareader-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Info(string message)
        {
            _logger.Information(message);
        }

        public static void Error(string message, Exception ex = null)
        {
            if (ex != null)
                _logger.Error(ex, message);
            else
                _logger.Error(message);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }
    }
}
