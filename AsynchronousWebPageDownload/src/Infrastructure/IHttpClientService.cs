namespace AsyncWebPageDownloader.Infrastructure;

public interface IHttpClientService
{
    Task GetPageWithRetriesAsync(string url, CancellationToken cancellationToken);
}