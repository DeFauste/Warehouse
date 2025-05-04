using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.
                HasKey(s => s.ID);

            builder.
                HasOne(s => s.Address);
        }
    }
}
