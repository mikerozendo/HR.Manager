using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/agents")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class AgentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AgentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteAgentRequest(id), cancellationToken);
    }
}
