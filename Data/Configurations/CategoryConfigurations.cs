using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.
                HasKey(c => c.ID);
        }
    }
}
