using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[Route("api/health-check")]
public class HealthCheckController() : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
