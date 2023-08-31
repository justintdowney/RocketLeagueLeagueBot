using Ballchasing.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RLLBot.DAL.Models;
using Replay = RLLBot.DAL.Models.Replay;
using Team = Ballchasing.Net.Team;

namespace RLLBot.Core.Services.Api
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IBallchasingAPI _api;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, IConfiguration configuration, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _api = new BallchasingClient(configuration.GetValue<string>("API:Token"));
            _logger = logger;
        }

        public async Task<StageReplayResult> StageReplayFromUrlAsync(string url)
        {
            var uploadResult = await _api.UploadReplayAsync(new MemoryStream(file), "test.replay", Privacy.Unlisted); // need to mess with filename for future

            return new StageReplayResult()
            {
                Id = uploadResult.Upload.Id,
                Location = uploadResult.Upload.Location,
                Error = uploadResult.Error,
                Duplicate = uploadResult.Duplicate,
                Success = uploadResult.Success
            };
        }

        public async Task<RemoveReplayResult> DeleteStagedReplayAsync(string replayId)
        {
            var deleteResult = await _api.DeleteReplayAsync(replayId);

            return new RemoveReplayResult()
            {
                Error = deleteResult.Error,
                Success = deleteResult.Success
            };
        }
    }
}
