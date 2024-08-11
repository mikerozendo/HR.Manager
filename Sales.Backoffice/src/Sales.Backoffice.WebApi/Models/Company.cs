using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;

public class Company : Agent
{
    public Company() : base(AgentType.Company) { }
}
