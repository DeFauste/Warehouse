namespace Warehouse.Data.Entity
{
    public class AddressEntity
    {
        public int ID { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
