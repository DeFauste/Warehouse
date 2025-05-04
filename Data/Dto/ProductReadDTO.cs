using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Dto
{
    public class ProductReadDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonPropertyName("category")]
        public CategoryEntity? Category { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; } = 1;
        [JsonPropertyName("available_stock")]
        public long AvailableStock { get; set; } = 0; // число закупленных экземпляров товара
        [JsonPropertyName("valid_untile")]
        public DateTime ValidUntile { get; set; } = DateTime.UtcNow; // Годен до ..
        [JsonPropertyName("supplier_id")]
        public int SupplierId { get; set; }
        [JsonPropertyName("supplier")]
        public SupplierEntity? Supplier { get; set; }

    }
}
