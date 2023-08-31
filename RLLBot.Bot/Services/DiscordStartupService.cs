using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace RLLBot.Bot.Services
{
    internal class DiscordStartupService : IHostedService
    {
        private readonly DiscordSocketClient _client;
        private readonly IConfiguration _config;

        public DiscordStartupService(DiscordSocketClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _client.LoginAsync(TokenType.Bot, _config["Application:Token"]?.Trim());
            await _client.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.LogoutAsync();
            await _client.StopAsync();
        }
    }
}
