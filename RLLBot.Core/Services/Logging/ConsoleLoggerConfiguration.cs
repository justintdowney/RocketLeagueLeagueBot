using Microsoft.Extensions.Logging;

namespace RLLBot.Core.Services.Logging
{
    public sealed class ConsoleLoggerConfiguration
    {
        public int EventId { get; set; }

        public Dictionary<LogLevel, ConsoleColor> LogLevelToColorMap { get; set; }
    }
}
