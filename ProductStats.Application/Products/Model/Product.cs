using System.Text.Json.Serialization;

namespace ProductStats.Application;
public class Product
{
    public Product()
    {
        Sizes = new List<string>();
    }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("price")]
    public int Price { get; set; }
    [JsonPropertyName("sizes")]
    public List<string> Sizes { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
}