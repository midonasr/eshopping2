using Products.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Products.Infrastructure.Data;

public class CatalogContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> Brands { get; set; }
    public DbSet<ProductType> Types { get; set; }
    public DbSet<User> Users { get; set; }

    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {

    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = 1; 
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = 1; 
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}