using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Warehouse.Data.Dto
{
    public class CategoryCreateDTO
    {
        [JsonPropertyName("name")]
        [Required, MaxLength(255)]
        public string Name { get; set; } = string.Empty;
    }
}
