using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests;

namespace Sales.Backoffice.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
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
        var response = await _mediator.Send(request);
        return Created(); 
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //var response = await _mediator.Send(request);
        return NoContent();
    }
}
