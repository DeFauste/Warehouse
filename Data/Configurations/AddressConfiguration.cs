using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.
                HasKey(a => a.ID);
        }
    }
}
