namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IGetRepository<TEntity> : 
    IGetByIdRepository<TEntity>, 
    IGetAllRepository<TEntity> 
    where TEntity : class
{
}
