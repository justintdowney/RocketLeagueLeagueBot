using Microsoft.Extensions.Logging;

namespace RLLBot.Core.Services
{
    //Convert to IHttpClientFactory? .CreateClient() to download file
    public class FileService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FileService> _logger;

        public FileService(HttpClient httpClient, ILogger<FileService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<byte[]> DownloadFileAsync(string url)
        {
            var response = await _httpClient.GetByteArrayAsync(url);
            _logger.LogInformation("File downloaded.");
            return response;
        }
    }
}
