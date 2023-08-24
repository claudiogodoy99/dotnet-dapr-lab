using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace consumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CounterController : ControllerBase
{
   
    private readonly ILogger<CounterController> _logger;

    public CounterController(ILogger<CounterController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub","count")]
    [HttpGet()]
    public IActionResult Post(int value) {
        _logger.LogInformation($"Counter value: {value}");
        return Ok(new {
            message = "success"
        });
    }
}
