using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

public record HealthResponse(bool Success, DateTime Time);

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<HealthResponse> Get()
    {
        return Ok(new HealthResponse(true, DateTime.UtcNow));
    }
}