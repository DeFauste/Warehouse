using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Db;
using Warehouse.Data.Entity;

namespace Warehouse.Repositories.Impl
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly WarehouseDbContext _context;
        public ProductRepositoryImpl(WarehouseDbContext context)
        {
            _context = context;
        }
        public void Create(ProductEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Products.Add(entity);
        }

        public void DeleteById(int id)
        {
            _context.Products
                .Where(a => a.ID == id)
                .ExecuteDelete();
        }

        public IEnumerable<ProductEntity> FindAll()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        public ProductEntity FindById(int id)
        {
            return _context.Products.FirstOrDefault(a => a.ID == id);

        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(ProductEntity entity, ProductEntity data)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            _context.Products
                 .Where(e => e.ID == entity.ID)
                 .ExecuteUpdate(a => a
                 .SetProperty(x => x.Name, data.Name)
                 .SetProperty(x => x.CategoryId, data.CategoryId)
                 .SetProperty(x => x.Price, data.Price)
                 .SetProperty(x => x.AvailableStock, data.AvailableStock)
                 .SetProperty(x => x.SupplierId, data.SupplierId)
                 .SetProperty(x => x.Price, data.Price)
                 );
        }
    }
}
