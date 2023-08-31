using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RLLBot.Bot.Services
{
    public class LoggingService : IHostedService
    {
        private readonly ILogger<LoggingService> _logger;
        private readonly DiscordSocketClient _client;
        private readonly InteractionService _interactionService;

        public LoggingService(ILogger<LoggingService> logger, DiscordSocketClient client, InteractionService interactionService)
        {
            _logger = logger;
            _client = client;
            _interactionService = interactionService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _client.Log += OnLogAsync;
            _interactionService.Log += OnLogAsync;
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Log -= OnLogAsync;
            _interactionService.Log -= OnLogAsync;
            return Task.CompletedTask;
        }

        private Task OnLogAsync(LogMessage msg)
        {
            var message = msg.Exception?.ToString() ?? msg.Message;
            switch (msg.Severity)
            {
                case LogSeverity.Debug:
                    _logger.LogDebug(message);
                    break;
                case LogSeverity.Warning:
                    _logger.LogWarning(message);
                    break;
                case LogSeverity.Error:
                    _logger.LogError(message);
                    break;
                case LogSeverity.Critical:
                    _logger.LogCritical(message);
                    break;
                default:
                    _logger.LogInformation(message);
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
