using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;

namespace Sales.Backoffice.WebApi.Controllers;

[ApiController]
//[Authorize]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IMediator _mediator;
    public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //var response = await _mediator.Send(request);
        return NoContent();
    }
}
