using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Warehouse.Data.Dto
{
    public class ProductCreateDTO
    {
        [Required, MaxLength(255)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [Required, Range(1.0, int.MaxValue)]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [Required, Range(1.0, double.MaxValue)]
        [JsonPropertyName("price")]
        public double Price { get; set; } = 1;
        [JsonPropertyName("available_stock")]
        public long AvailableStock { get; set; } = 0; // число закупленных экземпляров товара
        [JsonPropertyName("valid_untile")]
        public DateTime ValidUntile { get; set; } = DateTime.UtcNow; // Годен до ..
        [JsonPropertyName("supplier_id")]
        public int SupplierId { get; set; }
    }
}
