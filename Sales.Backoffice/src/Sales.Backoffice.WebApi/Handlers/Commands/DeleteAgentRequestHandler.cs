using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.WebApi.Repositories;

namespace Sales.Backoffice.WebApi.Handlers.Commands;

public class DeleteAgentRequestHandler : IRequestHandler<DeleteAgentRequest, ObjectResult>
{
    private readonly ApplicationDbContext _dbContext;
    public DeleteAgentRequestHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ObjectResult> Handle(DeleteAgentRequest request, CancellationToken cancellationToken)
    {
        var agentInDb = await _dbContext.Agents.SingleOrDefaultAsync(x => x.Id == request.Id);
        if (agentInDb is null)
            return new BadRequestObjectResult("Attempt to delete a entity that does not even exist");

        _dbContext.Agents.Remove(agentInDb);
        await _dbContext.SaveChangesAsync();    
        return new OkObjectResult($"Success to delete entity with Id {agentInDb.Id}");
    }
}
