using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class AgentRepository : IAgentRepository
{
    private readonly ApplicationDbContext _dbContext;
    public AgentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAsync(Agent agent)
    {
        _dbContext.Agents.Remove(agent);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Agent?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Agents.SingleOrDefaultAsync(x => x.Id == id);
    }
}
