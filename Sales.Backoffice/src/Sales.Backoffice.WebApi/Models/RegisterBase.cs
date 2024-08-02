namespace Sales.Backoffice.WebApi.Models;

public abstract class RegisterBase : EntityBase
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
