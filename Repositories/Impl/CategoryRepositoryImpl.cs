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
            _context.Categories
                .Where(a => a.ID == id)
                .ExecuteDelete();
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

        public void Update(CategoryEntity entity, CategoryEntity data)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            _context.Categories
                .Where(e => e.ID == entity.ID)
                .ExecuteUpdate(a => a
                .SetProperty(x => x.Name, data.Name)
                );
        }
    }
}
