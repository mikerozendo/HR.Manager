using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Application.Handlers.Commands;

public class DeleteAgentRequestHandler : IRequestHandler<DeleteAgentRequest, ObjectResult>
{
    private readonly IAgentRepository _agentRepository;
    public DeleteAgentRequestHandler(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public async Task<ObjectResult> Handle(DeleteAgentRequest request, CancellationToken cancellationToken)
    {
        var agentInDb = await _agentRepository.GetByIdAsync(request.Id);
        if (agentInDb is null)
            return new BadRequestObjectResult("Attempt to delete a entity that does not even exist");

        await _agentRepository.DeleteAsync(agentInDb);
        return new OkObjectResult($"Success to delete entity with Id {agentInDb.Id}");
    }
}
