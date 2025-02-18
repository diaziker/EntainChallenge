using System.Text;
using AsyncWebPageDownloader.Services;
using Microsoft.Extensions.Configuration;

namespace AsyncWebPageDownloader.Application;

public class WebPageDownloaderApp(WebPageDownloader downloader, IConfiguration configuration)
{
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var urls = configuration.GetSection("Urls").Get<List<string>>() ?? [];
        
        if (urls.Count == 0)
        {
            Console.WriteLine("No URLs provided. Exiting.");
            return;
        }

        await downloader.DownloadPagesAsync(urls, cancellationToken);
    }
}