namespace Sales.Backoffice.Dto.Responses;

public class EntityAcceptedResponse
{
    public EntityAcceptedResponse()
    {
    }

    public EntityAcceptedResponse(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}