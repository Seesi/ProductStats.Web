using ProductStats.Application;
using ProductStats.Web.Tests.Base;
using Shouldly;
using System.Linq;
using Xunit;

namespace ProductStats.Web.Tests
{
    public class ProductExtensionMethod_Tests : AppTestBase
    {
        [Fact]
        public void FindTop10CommonWords_should_return_the_ten_frequent_words_in_product_descriptions_excluding_the_first_top_five()
        {
            // Act
            var words = ProductList.FindTop10CommonWords();

            // Assert
            words.ShouldNotBeEmpty();
            words.Count.ShouldBeLessThanOrEqualTo(10);
            words.ShouldNotContain("pairs");
            words.ShouldNotContain("with");
            words.ShouldNotContain("a");
            words.ShouldNotContain("perfectly");
            words.ShouldNotContain("This");
            words.ShouldContain("Tie");
            words.ShouldContain("blue");
        }

        [Fact]
        public void GetMaxMinPrice_should_return_the_minimum_and_maximum_price_of_all_products()
        {
            // Act
            var (min, max) = ProductList.GetMaxMinPrice();

            // Assert
            min.ShouldNotBe(0);
            min.ShouldBe(10);
            max.ShouldBe(45);
        }

        [Fact]
        public void GetHighlightedProducts_should_highlight_given_text_in_product_descriptions()
        {
            // Act
            var list = ProductList.GetHighlightedProducts("red voilet blue");

            // Assert
            list.Any(m => m.Description.Contains("<mark>red</mark>")).ShouldNotBe(false);
            list.Where(m => m.Description.Contains("<mark>voilet</mark>")).Count().ShouldBeGreaterThan(1);
            list.Where(m => m.Description.Contains("<mark>blue</mark>")).Count().ShouldBe(4);
        }
    }
}