namespace Sales.Backoffice.Dto.Responses;

public class EntityAcceptedResponse
{
    public Guid Id { get; set; }
    public EntityAcceptedResponse() { }

    public EntityAcceptedResponse(Guid id)
    {
        Id = id;
    }
}
