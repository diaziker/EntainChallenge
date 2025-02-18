using AsyncWebPageDownloader.Infrastructure;
using AsyncWebPageDownloader.Services;
using Moq;
using Serilog;

namespace AsyncWebPageDownloaderTest;

public class WebPageDownloaderTests
{
    private readonly Mock<IHttpClientService> _httpClientServiceMock;
    private readonly Mock<ILogger> _loggerMock;
    private readonly WebPageDownloader _webPageDownloader;

    public WebPageDownloaderTests()
    {
        _httpClientServiceMock = new Mock<IHttpClientService>();
        _loggerMock = new Mock<ILogger>();
        _webPageDownloader = new WebPageDownloader(_httpClientServiceMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task ShouldDownloadAllPages()
    {
        var urls = new List<string> { "https://example.com/1", "https://example.com/2" };
        var cancellationToken = CancellationToken.None;
        _httpClientServiceMock
            .Setup(service => service.GetPageWithRetriesAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        await _webPageDownloader.DownloadPagesAsync(urls, cancellationToken);
        
        urls.ForEach(url => _httpClientServiceMock.Verify(service => service.GetPageWithRetriesAsync(url, cancellationToken), Times.Once));
        _loggerMock.Verify(logger => logger.Information("All downloads completed."), Times.Once);
    }

    [Fact]
    public async Task ShouldHandleTaskCanceledException()
    {
        var urls = new List<string> { "https://example.com" };
        var cancellationToken = CancellationToken.None;
        _httpClientServiceMock
            .Setup(service => service.GetPageWithRetriesAsync(It.IsAny<string>(), cancellationToken))
            .ThrowsAsync(new TaskCanceledException());

        await _webPageDownloader.DownloadPagesAsync(urls, cancellationToken);

        _loggerMock.Verify(logger => logger.Warning($"Download canceled: {urls.First()}"), Times.Once);
    }

    [Fact]
    public async Task ShouldLogErrorWhenExceptionOccurs()
    {
        var urls = new List<string> { "https://example.com" };
        var cancellationToken = CancellationToken.None;
        var exception = new Exception("Exception");
        _httpClientServiceMock
            .Setup(service => service.GetPageWithRetriesAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(exception);

        await _webPageDownloader.DownloadPagesAsync(urls, cancellationToken);

        _loggerMock.Verify(
            logger => logger.Error("Error downloading https://example.com: Exception"),
            Times.Once
        );
    }
}