using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;

public class Contact : AssignedToAnAgent
{
    public ContactType ContactType { get; set; }
    public string Value { get; set; }
}
