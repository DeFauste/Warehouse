
namespace Warehouse.Data.Entity
{
    public class ProductEntity
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public double Price { get; set; } = 0;
        public long AvailableStock { get; set; } = 0; // число закупленных экземпляров товара
        public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow; // дата последней закупки
        public DateTime ValidUntile { get; set; } = DateTime.UtcNow; // срок годности
        public int SupplierId { get; set; }
        public SupplierEntity? Supplier { get; set; }
    }
}
