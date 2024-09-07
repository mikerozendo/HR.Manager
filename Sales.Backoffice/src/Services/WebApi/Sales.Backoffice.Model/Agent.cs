using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public abstract class Agent : RegisterBase
{
    protected Agent(AgentType personType)
    {
        PersonType = personType;
    }

    public AgentType PersonType { get; protected set; }
    public List<Document> Documents { get; protected set; } = [];
    public List<Adress> Adresses { get; protected set; } = [];
    public List<Contact> Contacts { get; protected set; } = [];


    public void WithDocuments(List<Document> documents)
    {
        Documents = documents;
    }

    public void WithAdresses(List<Adress> adresses)
    {
        Adresses = adresses;
    }

    public void WithContacts(List<Contact> contacts)
    {
        Contacts = contacts;
    }
}