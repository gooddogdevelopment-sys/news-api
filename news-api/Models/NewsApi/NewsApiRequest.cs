using NewsAPI.Constants;

namespace news_api.Models.NewsApi;

public class NewsApiRequest
{
    public string? Q { get; set; }
    public List<string>? Sources { get; set; }
    public List<string>? Domains { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public Languages Language { get; set; } = Languages.EN;
    public SortBys? SortBy { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}