using System.Text;
using AsyncWebPageDownloader.Services;
using Microsoft.Extensions.Configuration;

namespace AsyncWebPageDownloader.Application;

public class WebPageDownloaderApp(WebPageDownloader downloader, IConfiguration configuration)
{
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        string[] urls = configuration.GetSection("Urls").Get<string[]>() ?? [];
        
        if (urls.Length == 0)
        {
            Console.WriteLine("No URLs provided. Exiting.");
            return;
        }

        await downloader.DownloadPagesAsync(urls, cancellationToken);
    }
}