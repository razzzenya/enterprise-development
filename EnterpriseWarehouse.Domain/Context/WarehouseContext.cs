using EnterpriseWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouse.Domain.Context;

public class WarehouseContext(DbContextOptions<WarehouseContext> options) : DbContext(options)
{
    public DbSet<Cell> Cells { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Supply> Supplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cell>()
            .Navigation(c => c.Product)
            .AutoInclude();
        modelBuilder.Entity<Supply>()
            .Navigation(s => s.Product)
            .AutoInclude();
        modelBuilder.Entity<Supply>()
            .Navigation(s => s.Organization)
            .AutoInclude();
    }
}
