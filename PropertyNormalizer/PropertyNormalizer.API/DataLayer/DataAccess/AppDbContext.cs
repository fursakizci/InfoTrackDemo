using Microsoft.EntityFrameworkCore;
using PropertyNormalizer.API.Models;

namespace PropertyNormalizer.API.DataLayer.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<InternalProperty> Properties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InternalProperty>().HasKey(p => p.Id);

        modelBuilder.Entity<InternalProperty>().OwnsOne(p => p.LotPlan);
        modelBuilder.Entity<InternalProperty>().OwnsOne(p => p.VolumeFolio);
        modelBuilder.Entity<InternalProperty>().OwnsOne(p => p.SourceTrace);

        base.OnModelCreating(modelBuilder);
    }
}