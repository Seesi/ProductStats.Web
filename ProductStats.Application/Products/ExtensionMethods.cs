using System.Text.RegularExpressions;

namespace ProductStats.Application
{
    public static class ExtensionMethods
    {
        public static List<string> FindTop10CommonWords(this List<Product> products)
        {
            var wrodFrequencies = new Dictionary<string, int>();

            foreach (var product in products)
            {
                if (!string.IsNullOrEmpty(product.Description))
                {
                    var words = Regex.Replace(product.Description, "[^a-zA-Z0-9]", " ")?
                        .Trim().Split(' ');

                    foreach (var word in words!)
                    {
                        if (wrodFrequencies.ContainsKey(word))
                        {
                            wrodFrequencies[word]++;
                        }
                        else
                        {
                            wrodFrequencies.Add(word, 1);
                        }
                    }
                }
            }

            return wrodFrequencies.OrderByDescending(x => x.Value).Skip(5).Take(10).Select(m => m.Key).ToList();
        }

        public static List<string> GetDisticntProductSizes(this List<Product> products)
        {
            var sizeList = new List<string>();

            foreach (var product in products)
            {
                if (product.Sizes.Any())
                {
                    foreach (var size in product.Sizes)
                    {
                        if (!sizeList.Contains(size))
                            sizeList.Add(size);
                    }
                }
            }
            return sizeList;
        }

        public static List<string> GetAllProductSizes(this List<Product> products)
        {
            var sizeList = new List<string>();

            foreach (var product in products)
            {
                if (product.Sizes.Any())
                    sizeList.AddRange(product.Sizes);
            }
            return sizeList;
        }

        public static (decimal, decimal) GetMaxMinPrice(this List<Product> products)
        {
            var priceArray = products.Select(m => m.Price).ToArray();

            Array.Sort(priceArray);

            return (priceArray.First(), priceArray.Last());
        }

        public static List<Product> GetFilteredProducts(this List<Product> products, string size, int maxPrice)
        {
            var query = products.AsEnumerable();

            if (!string.IsNullOrEmpty(size))
                query = query.Where(m => m.Sizes.Any(m => m == size));

            if (maxPrice is not 0)
                query = query.Where(m => m.Price == maxPrice);

            return query.ToList();
        }

        public static List<Product> GetHighlightedProducts(this List<Product> products, string hightlights)
        {
            var words = hightlights.Split(" ");
            if (!hightlights.Any())
                return products;

            foreach (var item in products)
            {
                foreach (var x in words)
                {
                    item.Description = item.Description.Replace(x, $"<mark>{x}</mark>");
                }
            }
            return products;
        }
    }
}