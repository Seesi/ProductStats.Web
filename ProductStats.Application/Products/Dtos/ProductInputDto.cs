using System.Text.Json.Serialization;

namespace ProductStats.Application;

public class ProductInputDto
{
    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }
}
