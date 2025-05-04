using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Warehouse.Data.Dto
{
    public class CategoryReadDTO
    {
        [Required, MaxLength(30)]
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
