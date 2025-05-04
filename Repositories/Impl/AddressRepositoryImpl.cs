using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Db;
using Warehouse.Data.Entity;

namespace Warehouse.Repositories.Impl
{
    public class AddressRepositoryImpl : IAddressRepository
    {
        private readonly WarehouseDbContext _context;
        public AddressRepositoryImpl(WarehouseDbContext context)
        {
            _context = context;
        }

        public void Create(AddressEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Addresses.Add(entity);
        }

        public void DeleteById(int id)
        {
            _context.Addresses
                .Where(a => a.ID == id)
                .ExecuteDelete();
        }

        public IEnumerable<AddressEntity> FindAll()
        {
            return _context.Addresses.AsNoTracking().ToList();
        }

        public AddressEntity FindById(int id)
        {
            return _context.Addresses.FirstOrDefault(a => a.ID == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(AddressEntity entity, AddressEntity data)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            _context.Addresses
                .Where(e => e.ID == entity.ID)
                .ExecuteUpdate(a => a
                .SetProperty(x => x.Country, data.Country)
                .SetProperty(x => x.City, data.City)
                .SetProperty(x => x.Street, data.Street)
                );
        }
    }
}
