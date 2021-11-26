using ProductStats.Application;
using System.Collections.Generic;

namespace ProductStats.Web.Tests.Base
{
    public class AppTestBase
    {
        public List<Product> ProductList { get; set; }

        public AppTestBase()
        {
            SeedProducts();
        }
        private void SeedProducts()
        {
            ProductList = new List<Product>()
            {
                new Product(){ Title = "Red Trousers",  Description = "This Trousers perfectly pairs with a red shoe.", Price=12, Sizes= new List<string>(){ "medium","large" } },
                new Product(){ Title = "A Blue Tie",    Description = "This Tie perfectly pairs with a voilet shoe.", Price=15, Sizes= new List<string>(){ "small","medium","large" } },
                new Product(){ Title = "A Green Shirt", Description = "This Shirt perfectly pairs with a blue shoe.", Price=25, Sizes= new List<string>(){ "small","large" } },
                new Product(){ Title = "Red Shorts",    Description = "This Shorts perfectly pairs with a green shoe.", Price=10, },
                new Product(){ Title = "Blue Trouser",  Description = "This Trousers perfectly pairs with a pink shoe.", Price=14, Sizes= new List<string>(){ "medium","large" } },
                new Product(){ Title = "A Green Dress", Description = "This Dress perfectly pairs with a red shoe.", Price=24, Sizes= new List<string>(){ "small","medium","large" } },
                new Product(){ Title = "A Red Tie",     Description = "This Tie perfectly pairs with a pink shoe.", Price=16, Sizes= new List<string>(){ "medium","large" } },
                new Product(){ Title = "A Blue Shirt",  Description = "This Shirt perfectly pairs with a blue shoe.", Price=12, Sizes= new List<string>(){ "small","medium","large" } },
                new Product(){ Title = "Green Shorts", Description = "This Shorts perfectly pairs with a green shoe.", Price=16, Sizes= new List<string>(){ "small", } },
                new Product(){ Title = "A Red Dress",   Description = "This Dress perfectly pairs with a pink shoe.", Price=10, Sizes= new List<string>(){ "small","medium","large" } },
                new Product(){ Title = "A Blue Dress",  Description = "This Dress perfectly pairs with a blue shoe.", Price=12, Sizes= new List<string>(){ "large" } },
                new Product(){ Title = "A Green Tie",   Description = "This Tie perfectly pairs with a green shoe.", Price=10, Sizes= new List<string>(){ "small","medium","large" } },
                new Product(){ Title = "A Red Shirt",   Description = "This Shirt perfectly pairs with a pink shoe.", Price=12, Sizes= new List<string>(){ "medium", } },
                new Product(){ Title = "Blue Trouser",  Description = "This Trouser perfectly pairs with a blue shoe.", Price=25, Sizes= new List<string>(){ "small","large" } },
                new Product(){ Title = "A Green Tie",   Description = "This Tie perfectly pairs with a voilet shoe.", Price=45, Sizes= new List<string>(){ "small","medium" } },
            };
        }
    }

}
