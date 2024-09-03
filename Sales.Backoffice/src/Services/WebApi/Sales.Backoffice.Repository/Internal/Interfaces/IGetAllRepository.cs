namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IGetAllRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
}
