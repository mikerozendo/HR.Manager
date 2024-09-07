using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IAgentRepository : IGetByIdRepository<Agent>
{
    Task DeleteAsync(Agent agent);
}