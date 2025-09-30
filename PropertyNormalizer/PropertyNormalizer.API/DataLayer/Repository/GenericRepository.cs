using Microsoft.EntityFrameworkCore;
using PropertyNormalizer.API.DataLayer.DataAccess;
using PropertyNormalizer.API.DataLayer.Repository;

namespace PropertyNormalizer.API.DataLayer.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
    }
    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await _dbSet.AddAsync(entity);
        
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity); 

        _context.Entry(entity).State = EntityState.Modified; 

        await _context.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await GetByIdAsync(id);
        
        _dbSet.Remove(item);
        
        await _context.SaveChangesAsync();
    }
   
}