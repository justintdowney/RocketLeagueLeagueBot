using System.Net.Http;
using System;
using Microsoft.Extensions.Logging;

namespace RLLBot.Api
{
    // Responsible for downloading discord attachments
    public class AttachmentDownloadService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public AttachmentDownloadService(HttpClient httpClient, ILogger<AttachmentDownloadService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<byte[]> DownloadReplayAsync(string url)
        {
            var response = await _httpClient.GetByteArrayAsync(url);
            _logger.LogInformation("File downloaded.");
            return response;
        }
    }
}