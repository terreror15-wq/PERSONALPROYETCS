using System.Text.Json.Serialization;

namespace VirtualStore.DTO_s
{
    public class ProductDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
