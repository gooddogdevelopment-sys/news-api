using news_api.Models.NewsApi;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace news_api.Services;

public interface INewsApiService
{
    Task<ArticlesResult> GetEverythingAsync(NewsApiRequest request);
}

public class NewsApiService : INewsApiService
{
    private readonly NewsApiClient _client;

    public NewsApiService(IConfiguration configuration)
    {
        var apiKey = configuration["NewsApi:ApiKey"]
            ?? throw new InvalidOperationException("NewsApi:ApiKey is not configured.");
        _client = new NewsApiClient(apiKey);
    }

    /// <summary>
    /// Query the /v2/everything endpoint for recent articles across the web.
    /// </summary>
    public async Task<ArticlesResult> GetEverythingAsync(
        NewsApiRequest request)
    {
        var newsRequest = new EverythingRequest
        {
            Q = request.Q,
            From = request.From,
            To = request.To,
            Language = request.Language,
            SortBy = request.SortBy,
            Page = request.Page,
            PageSize = request.PageSize
        };

        if (request.Sources is { Count: > 0 })
            newsRequest.Sources.AddRange(request.Sources);

        if (request.Domains is { Count: > 0 })
            newsRequest.Domains.AddRange(request.Domains);

        return await _client.GetEverythingAsync(newsRequest);
    }
}
