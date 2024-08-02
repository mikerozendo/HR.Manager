namespace Sales.Backoffice.WebApi.Models;

public class AssignedToAnAgent : RegisterBase
{
    public Agent Agent { get; set; }
    public Guid AgentId { get; set; }
}
