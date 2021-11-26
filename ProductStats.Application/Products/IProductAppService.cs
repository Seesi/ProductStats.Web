
namespace ProductStats.Application
{
    public interface IProductAppService
    {
        ProductOutputDto GetProducts(List<Product> products, int maxPrice, string size, string hightlights);
    }
}