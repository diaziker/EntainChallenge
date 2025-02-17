using Polly;
using Polly.Retry;

namespace AsyncWebPageDownloader.Infrastructure;

public class HttpClientService
{
    private readonly HttpClient _httpClient = new();
    private readonly AsyncPolicy<HttpResponseMessage> _retryPolicy = GetRetryPolicy();

    public async Task GetPageWithRetriesAsync(string url, CancellationToken cancellationToken)
    {
        var response = await _retryPolicy.ExecuteAsync(async () =>
            await _httpClient.GetAsync(url, cancellationToken));

        response.EnsureSuccessStatusCode();
        
        await response.Content.ReadAsStringAsync(cancellationToken);
    }
    
    private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .Or<HttpRequestException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (result, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Retry {retryCount} after {timeSpan.TotalSeconds} seconds due to {result.Exception?.Message ?? result.Result.StatusCode.ToString()}");
                });
    }
}