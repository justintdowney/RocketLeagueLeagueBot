using Ballchasing.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RLLBot.Core.Services.Api;
using Replay = RLLBot.DAL.Models.Replay;

namespace RLLBot.Api
{
    public class BallchasingStager : IReplayStager
    {
        private readonly HttpClient _httpClient;
        private readonly IBallchasingAPI _api;
        private readonly ILogger<BallchasingStager> _logger;

        public BallchasingStager(HttpClient httpClient, IConfiguration configuration, ILogger<BallchasingStager> logger)
        {
            _httpClient = httpClient;
            _api = new BallchasingClient(configuration.GetValue<string>("API:Token"));
            _logger = logger;
        }

        public IList<Replay> StagedReplays => 

        public async Task<StageReplayResult> StageAsync(byte[] fileData)
        {
            var uploadResult = await _api.UploadReplayAsync(new MemoryStream(fileData), "test.replay", Privacy.Unlisted); // need to mess with filename for future

            return new StageReplayResult
            {
                Id = uploadResult.Upload.Id,
                Location = uploadResult.Upload.Location,
                Error = uploadResult.Error,
                Duplicate = uploadResult.Duplicate,
                Success = uploadResult.Success
            };
        }

        public async Task<RemoveReplayResult> UnstageAsync(string replayId)
        {
            var deleteResult = await _api.DeleteReplayAsync(replayId);

            return new RemoveReplayResult
            {
                Error = deleteResult.Error,
                Success = deleteResult.Success
            };
        }

        private async Task<IList<Replay>> InitializeStagedReplays()
        {
            var filterReplaysResult = await _api.FilterReplaysAsync(new FilterReplaysInfo { SortBy = SortBy.ReplayDate, Uploader = "me" });
            return filterReplaysResult.
        }
    }
}
