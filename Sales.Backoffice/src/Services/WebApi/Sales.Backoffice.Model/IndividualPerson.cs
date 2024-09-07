using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class IndividualPerson : Agent
{
    public IndividualPerson()
        : base(AgentType.Individual)
    {
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    public SexType Sex { get; set; }
    public DateTime BirthDate { get; set; }
}