using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;

public class Contact : RegisterBase
{
    public ContactType ContactType { get; set; }
    public string ContactAdress { get; set; }
}
