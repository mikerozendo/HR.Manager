using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Contact : AssignedToAnAgent
{
    public ContactType ContactType { get; set; }
    public string Value { get; set; }
}
