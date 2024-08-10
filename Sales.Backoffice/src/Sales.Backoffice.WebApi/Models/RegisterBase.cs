namespace Sales.Backoffice.WebApi.Models;

public abstract class RegisterBase : EntityBase
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public void WithCreatedDate(DateTime createdDate)
    {
        CreatedAt = createdDate;
    }

    public void WithModifiedDate(DateTime modifiedDate)
    {
        ModifiedAt = modifiedDate;
    }
}
