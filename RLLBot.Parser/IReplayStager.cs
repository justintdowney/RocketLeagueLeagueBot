using RLLBot.Core.Services.Api;
using RLLBot.DAL.Models;
namespace RLLBot.Api
{
    internal interface IReplayStager
    {
        // Allows for implementation of different staging methods i.e. ballchasing.com or in-memory for example
        Task<StageReplayResult> StageAsync(byte[] fileData);
        Task<RemoveReplayResult> UnstageAsync(string replayId);
        IList<Replay> StagedReplays { get; }
    }
}
