using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;
using System.Net;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/agents")]
[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
public class AgentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AgentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await _mediator.Send(new DeleteAgentRequest(id));
    }
}
