using System.Text.Json.Serialization;
using Warehouse.Data.Entity;

namespace Warehouse.Data.Dto
{
    public class SupplierReadDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("address_id")]
        public int AddressId { get; set; }
        [JsonPropertyName("address")]
        public AddressEntity? Address { get; set; }
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
