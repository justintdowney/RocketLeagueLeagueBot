using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace RLLBot.Core.Services.Logging
{
    public static class ConsoleLoggerExtensions
    {
        public static ILoggingBuilder AddConsoleLogger(
            this ILoggingBuilder builder)
        {
            builder.AddConfiguration();

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());

            LoggerProviderOptions.RegisterProviderOptions<ConsoleLoggerConfiguration, ConsoleLoggerProvider>(builder.Services);

            return builder;
        }

        public static ILoggingBuilder AddConsoleLogger(
            this ILoggingBuilder builder,
            Action<ConsoleLoggerConfiguration> configure)
        {
            builder.AddConsoleLogger();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
