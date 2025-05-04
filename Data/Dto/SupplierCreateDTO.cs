using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Warehouse.Data.Dto
{
    public class SupplierCreateDTO
    {
        [Required, MaxLength(30)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [Required, Range(1.0, int.MaxValue)]
        [JsonPropertyName("address_id")]
        public int AddressId { get; set; }
        [Required, MaxLength(30)]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
