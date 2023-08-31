using Microsoft.Extensions.Logging;

namespace RLLBot.Core.Services.Logging
{
    public sealed class ConsoleLogger : ILogger
    {
        private readonly string _name;
        private readonly Func<ConsoleLoggerConfiguration> _getCurrentConfig;

        public ConsoleLogger(
            string name,
            Func<ConsoleLoggerConfiguration> getCurrentConfig) =>
            (_name, _getCurrentConfig) = (name, getCurrentConfig);

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

        public bool IsEnabled(LogLevel logLevel)
        {
            return _getCurrentConfig().LogLevelToColorMap.ContainsKey(logLevel);
        }

        public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception? exception, 
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var config = _getCurrentConfig();
            if (config.EventId != 0 && config.EventId != eventId.Id)
                return;

            var originalColor = Console.ForegroundColor;

            Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
            Console.WriteLine($"[{DateTime.Now}] [{logLevel}]");

            Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
            Console.Write($"{_name} - ");

            Console.ForegroundColor = originalColor;
            Console.Write($"{formatter(state, exception)}");

            Console.ForegroundColor = originalColor;
            Console.WriteLine();

        }
    }
}
