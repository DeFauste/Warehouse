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
            var entity = _context.Products.FirstOrDefault(a => a.ID == id);

            if (entity == null)
                throw new ArgumentException("Product not found!");

            _context.Products.Remove(entity);
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

        public void Update(int id, ProductEntity data)
        {
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            var entity = _context.Products.FirstOrDefault(a => a.ID == id);
            if (entity == null)
            {
                throw new AbandonedMutexException(nameof(entity));
            }
            entity.Name = data.Name;
            entity.CategoryId = data.CategoryId;
            entity.Price = data.Price;
            entity.AvailableStock = data.AvailableStock;
            entity.SupplierId = data.SupplierId;
            entity.Price = data.Price;
        }
    }
}
