using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Db;
using Warehouse.Data.Entity;

namespace Warehouse.Repositories.Impl
{
    public class SupplierRepositoryImpl : ISupplierRepository
    {
        private readonly WarehouseDbContext _context;
        public SupplierRepositoryImpl(WarehouseDbContext context)
        {
            _context = context;
        }
        public void Create(SupplierEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Suppliers.Add(entity);
        }

        public void DeleteById(int id)
        {
            _context.Suppliers
                .Where(a => a.ID == id)
                .ExecuteDelete();
        }

        public IEnumerable<SupplierEntity> FindAll()
        {
            return _context.Suppliers.AsNoTracking().ToList();
        }

        public SupplierEntity FindById(int id)
        {
            return _context.Suppliers.FirstOrDefault(a => a.ID == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(SupplierEntity entity, SupplierEntity data)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            _context.Suppliers
                .Where(e => e.ID == entity.ID)
                .ExecuteUpdate(a => a
                .SetProperty(x => x.Name, data.Name)
                .SetProperty(x => x.AddressId, data.AddressId)
                .SetProperty(x => x.PhoneNumber, data.PhoneNumber)
                );
        }
    }
}
