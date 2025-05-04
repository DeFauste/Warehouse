using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Db;
using Warehouse.Data.Entity;

namespace Warehouse.Repositories.Impl
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly WarehouseDbContext _context;
        public CategoryRepositoryImpl(WarehouseDbContext context)
        {
            _context = context;
        }

        public void Create(CategoryEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Categories.Add(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _context.Categories.FirstOrDefault(a => a.ID == id);

            if (entity == null)
                throw new ArgumentException("Category not found!");

            _context.Categories.Remove(entity);
        }

        public IEnumerable<CategoryEntity> FindAll()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public CategoryEntity FindById(int id)
        {
            return _context.Categories.FirstOrDefault(a => a.ID == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(int id, CategoryEntity data)
        {
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            var entity = _context.Categories.FirstOrDefault(a => a.ID == id);
            if (entity == null)
            {
                throw new AbandonedMutexException(nameof(entity));
            }
            entity.Name = data.Name;
        }
    }
}
