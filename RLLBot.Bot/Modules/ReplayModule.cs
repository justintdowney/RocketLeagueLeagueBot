using Discord.Interactions;
using Discord;
using RLLBot.Attributes;
using Ballchasing.Net;
using Microsoft.EntityFrameworkCore;
using RLLBot.DAL;
using RLLBot.Core.Services.Api;

namespace RLLBot.Bot.Modules
{
    public class ReplayModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly ApiService _apiService;
        private readonly IBallchasingAPI _api;
        private DbContext _context;

        public ReplayModule(ApiService service, IBallchasingAPI api, DbContext context)
        {
            _apiService = service;
            _api = api;
            _context = context;
        }

        [SlashCommand("stage-replay", "Attach and stage a RLL match replay for submission to the DB.")]
        public async Task StageReplay([DoFileExtensionCheck(".replay")]IAttachment attachment)
        {
            // await stager.Stage(attachment.Url);
            // 
            var stageResult = await _apiService.StageReplayFromUrlAsync(attachment.Url);

            if (stageResult.Success)
                await RespondAsync($"Replay {attachment.Filename} uploaded to staging area.", ephemeral:true);
            else
                await RespondAsync($"Replay {attachment.Filename} failed to upload.", ephemeral: true);
        }

        [SlashCommand("get-staged-replays", "Retrieves all staged replays.")]
        public async Task GetStagedReplays() // filteredreplays return stats that are null for both teams and players
        {
            var getResult = await _api.FilterReplaysAsync(new FilterReplaysInfo { SortBy = SortBy.ReplayDate, Uploader = "me"});
            var embeds = new List<Embed>();


            if (!getResult.Success)
            {
                await RespondAsync($"Failed to retrieve any replays. Error: {getResult.Error}", ephemeral: true);
            }

            foreach (var replay in getResult.Replays)
            {
                var embed = new EmbedBuilder()
                    .WithTitle($"{replay.Orange.Name} vs {replay.Blue.Name}")
                    .WithUrl(replay.Link)
                    .WithDescription($"{replay.Date} - {replay.Duration / 60} minutes")
                    .AddField("Map: ", replay.MapName)
                    .AddField(replay.Orange.Name, string.Join(", ", replay.Orange.Players.Select(player => player.Name)))
                    .AddField(replay.Blue.Name, string.Join(", ", replay.Blue.Players.Select(player => player.Name)))
                    .AddField("Replay ID: ", replay.Id)
                    .Build();
                embeds.Add(embed);
            }

            await RespondAsync(embeds: embeds.ToArray(), ephemeral: true);
        }

        [SlashCommand("remove-replay", "Remove a replay from the staging area.")]
        public async Task RemoveReplay(string replayId)
        {
            var deleteResult = await _apiService.DeleteStagedReplayAsync(replayId);

            if (deleteResult.Success)
                await RespondAsync($"Replay {replayId} was successfully removed.", ephemeral: true);
            else
                await RespondAsync($"Replay {replayId} failed to be removed. Error: {deleteResult.Error}", ephemeral: true);
        }
    }
}
