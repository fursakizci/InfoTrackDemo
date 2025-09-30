using PropertyNormalizer.API.DataLayer.Repository;
using PropertyNormalizer.API.Models;

public class FakeRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly List<TEntity> _store = new();

    public Task<TEntity> GetByIdAsync(Guid id) => Task.FromResult(_store.FirstOrDefault());

    public Task<IEnumerable<TEntity>> GetAllAsync() => Task.FromResult<IEnumerable<TEntity>>(_store);

    public Task<TEntity> AddAsync(TEntity entity)
    {
        _store.Add(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(TEntity entity) => Task.CompletedTask;

    public Task DeleteAsync(Guid id) => Task.CompletedTask;
}