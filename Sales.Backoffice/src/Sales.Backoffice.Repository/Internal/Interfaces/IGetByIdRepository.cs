namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IGetByIdRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id);
}
