using Microsoft.AspNetCore.Mvc;
using news_api.Models.NewsApi;
using news_api.Services;

namespace news_api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsApiController (INewsApiService newsApiService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> GetEverything([FromBody] NewsApiRequest request)
    {
        return Ok(await newsApiService.GetEverythingAsync(request));
    }
}