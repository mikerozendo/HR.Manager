using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;


public class Agent : RegisterBase
{
    public AgentType PersonType { get; set; }
    public List<Document> Documents { get; set; } = [];
    public List<Adress> Adresses { get; set; } = [];
    public List<Contact> Contacts { get; set; } = [];


    public Agent() { }
    public Agent(AgentType personType)
    {
        PersonType = personType;
    }


    public void WithDocuments(List<Document> documents)
    {
        Documents = documents;
    }

    public void WithAdresses(List<Adress> adresses)
    {
        Adresses = adresses;
    }

    public void WithContacts(List<Contact> Contacts)
    {
        Contacts = Contacts;
    }
}
