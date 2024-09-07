using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class AgentRepository(ApplicationDbContext dbContext) : IAgentRepository
{
    public async Task DeleteAsync(Agent agent)
    {
        dbContext.Agents.Remove(agent);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Agent?> GetByIdAsync(Guid id)
    {
        return await dbContext.Agents.SingleOrDefaultAsync(x => x.Id == id);
    }
}