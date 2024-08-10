using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Dto.Requests.Queries;
using System.Net;

namespace Sales.Backoffice.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly IMediator _mediator;
    public DepartmentController(ILogger<DepartmentController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateDepartmentRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return NoContent();
    }

    [HttpGet("/{id}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        return await _mediator.Send(new GetDepartmentByIdRequest(id));
    }
}
