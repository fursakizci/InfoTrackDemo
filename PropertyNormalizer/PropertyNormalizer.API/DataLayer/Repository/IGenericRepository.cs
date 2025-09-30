namespace PropertyNormalizer.API.DataLayer.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}