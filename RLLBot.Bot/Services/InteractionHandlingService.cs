using System.Reflection;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RLLBot.Bot.Services;

public class InteractionHandlingService : IHostedService
{
    private readonly DiscordSocketClient _client;
    private readonly IConfiguration _configuration;
    private readonly InteractionService _handler;
    private readonly ILogger<InteractionHandlingService> _logger;
    private readonly IServiceProvider _services;

    public InteractionHandlingService(
        DiscordSocketClient client,
        InteractionService handler,
        IServiceProvider services,
        IConfiguration configuration,
        ILogger<InteractionHandlingService> logger)
    {
        _client = client;
        _handler = handler;
        _services = services;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _client.Ready += () => _handler.RegisterCommandsToGuildAsync(_configuration.GetValue<ulong>("Application:GuildName"));
        _client.InteractionCreated += OnInteractionAsync;
        _handler.SlashCommandExecuted += OnSlashCommandExecutedAsync;

        await _handler.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _handler.Dispose();
        return Task.CompletedTask;
    }

    private async Task OnInteractionAsync(SocketInteraction interaction)
    {
        try
        {
            var context = new SocketInteractionContext(_client, interaction);
            var result = await _handler.ExecuteCommandAsync(context, _services);

            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ToString());
        }
        catch
        {
            if (interaction.Type is InteractionType.ApplicationCommand)
                await interaction.GetOriginalResponseAsync()
                    .ContinueWith(async msg => await msg.Result.DeleteAsync());
        }
    }

    private async Task OnSlashCommandExecutedAsync(SlashCommandInfo info, IInteractionContext context, IResult result)
    {
        if (!result.IsSuccess)
        {
            var error = result.Error switch
            {
                InteractionCommandError.UnmetPrecondition => $"Unmet Precondition: {result.ErrorReason}",
                InteractionCommandError.UnknownCommand => "Unknown command",
                InteractionCommandError.BadArgs => "Invalid number or arguments",
                InteractionCommandError.Exception => $"Command exception: {result.ErrorReason}",
                InteractionCommandError.Unsuccessful => "Command could not be executed",
                _ => string.Empty
            };
            await context.Interaction.RespondAsync(error);
        }

        _logger.LogInformation($"/{info.Name} executed by {context.User.Username}, result was {result.IsSuccess}.");
    }
}