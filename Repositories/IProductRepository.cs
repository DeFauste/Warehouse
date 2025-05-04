using Warehouse.Data.Entity;

namespace Warehouse.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity, int>
    {
    }
}
