namespace Sales.Backoffice.Dto.Responses;

public class EntityCreatedResponse
{
    public Guid Id { get; set; }
    public EntityCreatedResponse()
    {
        
    }

    public EntityCreatedResponse(Guid id)
    {
        Id = id;
    }
}
