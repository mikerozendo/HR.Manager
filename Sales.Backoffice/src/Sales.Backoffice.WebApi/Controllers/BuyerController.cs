using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Models.Dto;

namespace Sales.Backoffice.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class BuyerController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;
    public BuyerController(ILogger<HealthCheckController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BuyerDto buyer)
    {
        await Task.Delay(1);
        _logger.LogInformation("Creating a new buyer");
        return Created();
    }

    [HttpGet]
    [Route(nameof(GetBuyers))]
    public async Task<ActionResult<BuyerDto>> GetBuyers()
    {
        return Ok(new List<BuyerDto> { new BuyerDto { Name = "Test Michael" } });
    }
}
