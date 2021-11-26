namespace ProductStats.Application
{
    public class ProductAppService : IProductAppService
    {
        public ProductOutputDto GetProducts(List<Product> products, int maxPrice, string size, string hightlights)
        {
            var mostCommonWords = products.FindTop10CommonWords();

            var disticntProductSizes = products.GetDisticntProductSizes();

            var (min, max) = products.GetMaxMinPrice();

            var filteredProducts = products.GetFilteredProducts(size, maxPrice);

            var productList = filteredProducts.GetHighlightedProducts(hightlights);


            return new ProductOutputDto()
            {
                Products = productList,
                Filter = new FilterDto()
                {
                    TopCommonWords = mostCommonWords,
                    AvailableSizes = disticntProductSizes,
                    MaxPrice = max,
                    MinPrice = min
                }
            };
        }
    }
}
