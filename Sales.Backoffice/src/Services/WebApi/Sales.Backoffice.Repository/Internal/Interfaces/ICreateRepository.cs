namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface ICreateRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity);
}