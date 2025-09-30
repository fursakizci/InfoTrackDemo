using Microsoft.EntityFrameworkCore;
using PropertyNormalizer.API.DataLayer.DataAccess;
using PropertyNormalizer.API.Models;

namespace PropertyNormalizer.API.DataLayer.Repository;

public class PropertyRepository : GenericRepository<InternalProperty>, IPropertyRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<InternalProperty> _dbSet;
    
    public PropertyRepository(AppDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<InternalProperty>();
    }
}