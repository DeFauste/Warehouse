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
             var entity = _context.Addresses.FirstOrDefault(a => a.ID == id);

            if (entity == null)
                throw new ArgumentException("Address not found!");

            _context.Addresses.Remove(entity);
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

        public void Update(int id, AddressEntity data)
        {
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            var entity = _context.Addresses.FirstOrDefault(a => a.ID == id);
            if (entity == null)
            {
                throw new AbandonedMutexException(nameof(entity));
            }
            entity.Country = data.Country;
            entity.City = data.City;
            entity.Street = data.Street;
        }
    }
}
