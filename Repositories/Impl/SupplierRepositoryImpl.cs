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
            var entity = _context.Suppliers.FirstOrDefault(a => a.ID == id);

            if (entity == null)
                throw new ArgumentException("Supplier not found!");

            _context.Suppliers.Remove(entity);
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

        public void Update(int id, SupplierEntity data)
        {
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            var entity = _context.Suppliers.FirstOrDefault(a => a.ID == id);
            if (entity == null)
            {
                throw new AbandonedMutexException(nameof(entity));
            }
            entity.Name = data.Name;
            entity.AddressId = data.AddressId;
            entity.PhoneNumber = data.PhoneNumber;
        }
    }
}
