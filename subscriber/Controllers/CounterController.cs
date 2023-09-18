using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace consumer.Controllers;

[ApiController]
[Route("[controller]")]
public class CounterController : ControllerBase
{
    private static int _counter = 0;

    private readonly ILogger<CounterController> _logger;

    public CounterController(ILogger<CounterController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub","count")]
    [HttpPost("/count")]
    public IActionResult Post(int value) {
        _counter++;
        _logger.LogInformation($"Received  {_counter}");
        return Ok();
    }
}
