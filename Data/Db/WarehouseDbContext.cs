using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Configurations;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Db
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {
            
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
