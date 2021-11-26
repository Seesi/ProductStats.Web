namespace ProductStats.Application;
public class FilterDto
{
    public decimal MaxPrice { get; set; }
    public decimal MinPrice { get; set; }
    public List<string> AvailableSizes { get; set; }
    public List<string> TopCommonWords { get; set; }
}