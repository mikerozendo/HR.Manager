using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Responses;

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
    public async Task<IActionResult> Post([FromBody] GetEmployeesResponse buyer)
    {
        await Task.Delay(1);
        _logger.LogInformation("Creating a new buyer");
        return Created();
    }

    [HttpGet]
    [Route(nameof(GetBuyers))]
    public async Task<ActionResult<GetEmployeesResponse>> GetBuyers()
    {
        return Ok(new List<GetEmployeesResponse> { new GetEmployeesResponse { Name = "Test Michael" } });
    }
}
