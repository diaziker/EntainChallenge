using AsyncWebPageDownloader.Infrastructure;
using Serilog;

namespace AsyncWebPageDownloader.Services;

public class WebPageDownloader(IHttpClientService httpClientService, ILogger logger)
{
    public async Task DownloadPagesAsync(List<string> urls, CancellationToken cancellationToken)
    {
        var downloadTasks = urls
            .Select(url => DownloadPageAsync(url, cancellationToken))
            .ToList();

        try
        {
            await Task.WhenAll(downloadTasks);

            if (!cancellationToken.IsCancellationRequested)
                logger.Information("All downloads completed.");
        }
        catch (OperationCanceledException)
        {
            logger.Warning("Download operation was canceled.");
        }
    }

    private async Task DownloadPageAsync(string url, CancellationToken cancellationToken)
    {
        try
        {
            logger.Information($"Downloading: {url}");
            await httpClientService.GetPageWithRetriesAsync(url, cancellationToken);
            logger.Information($"Download completed: {url}");
        }
        catch (TaskCanceledException)
        {
            logger.Warning($"Download canceled: {url}");
        }
        catch (Exception ex)
        {
            logger.Error($"Error downloading {url}: {ex.Message}");
        }
    }
}