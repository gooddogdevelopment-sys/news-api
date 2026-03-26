using Microsoft.AspNetCore.Mvc;

namespace news_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public ActionResult Ping()
    {
        return Ok("Pong");
    }
}