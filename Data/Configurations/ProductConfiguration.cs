using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.ID);

            builder.
                HasOne(p => p.Supplier);
        }
    }
}
