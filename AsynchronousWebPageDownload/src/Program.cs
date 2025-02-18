using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AsyncWebPageDownloader.Application;
using AsyncWebPageDownloader.Infrastructure;
using AsyncWebPageDownloader.Services;
using Microsoft.Extensions.Configuration;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

using var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((_, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((_, services) =>
    {
        services.AddSingleton<WebPageDownloaderApp>();
        services.AddSingleton<IHttpClientService, HttpClientService>();
        services.AddSingleton<WebPageDownloader>();
        services.AddSingleton(Log.Logger);
    })
    .Build();

using var ctx = new CancellationTokenSource();
Console.CancelKeyPress += (sender, eventArgs) =>
{
    eventArgs.Cancel = true; 
    ctx.Cancel();
    Console.WriteLine("\nCancellation requested. Stopping downloads...");
};

var app = host.Services.GetRequiredService<WebPageDownloaderApp>();
await app.RunAsync(ctx.Token);