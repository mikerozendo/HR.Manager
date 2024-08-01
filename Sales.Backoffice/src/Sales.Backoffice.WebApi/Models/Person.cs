using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;


public class Person : RegisterBase
{
    public PersonType PersonType { get; set; }
    public List<Document> Documents { get; set; }
    public List<Adress> Adresses { get; set; }
    public List<Contact> Contacts { get; set; }
}
