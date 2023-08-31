using Ballchasing.Net;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RLLBot.Bot.Services;
using RLLBot.DAL;
using RLLBot.Core.Services.Logging;
using RLLBot.Core.Services;
using RLLBot.Core.Services.Api;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile($"Properties/appsettings.json", optional: false);

builder.Services.AddDbContext<DbContext, LeagueContext>(
    options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("LeagueContext")));
builder.Services.AddHttpClient<IBallchasingAPI, BallchasingClient>((x, provider) =>
    ActivatorUtilities.CreateInstance<BallchasingClient>(provider, builder.Configuration.GetValue<string>("API:Token")));
builder.Services.AddHttpClient<FileService>();
builder.Services.AddSingleton<DiscordSocketClient>();
builder.Services.AddSingleton<InteractionService>();
builder.Services.AddSingleton<ApiService>();
builder.Services.AddHostedService<InteractionHandlingService>();
builder.Services.AddHostedService<DiscordStartupService>();
builder.Services.AddHostedService<LoggingService>();
builder.Logging.ClearProviders().AddConsoleLogger();

var app = builder.Build();
await app.RunAsync();




