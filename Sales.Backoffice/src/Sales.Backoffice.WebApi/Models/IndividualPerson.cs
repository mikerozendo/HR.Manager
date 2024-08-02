using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;

public class IndividualPerson : Person
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public SexType Sex { get; set; }
    public DateTime BirthDate { get; set; }
}
