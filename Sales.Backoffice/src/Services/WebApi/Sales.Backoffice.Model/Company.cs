using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Company : Agent
{
    public Company() : base(AgentType.Company)
    {
    }
}