namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IUpdateRepository<TEntity> where TEntity : class
{
    Task UpdateAsync(TEntity entity);
}