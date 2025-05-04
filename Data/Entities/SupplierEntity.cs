
namespace Warehouse.Data.Entity
{
    public class SupplierEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public AddressEntity? Address { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
