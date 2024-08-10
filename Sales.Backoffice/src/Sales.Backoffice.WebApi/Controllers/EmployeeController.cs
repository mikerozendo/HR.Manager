using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;
using System.Net;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
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
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }
}
