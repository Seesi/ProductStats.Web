using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductStats.Application;
using System.Text.Json;

namespace ProductStats.Web.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        #region Fields

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductAppService _productAppService;
        private List<Product> _products;
        private const string _baseUrl = "http://www.mocky.io/v2/5e307edf3200005d00858b49";
        #endregion

        #region Constructor

        public ProductsController(IProductAppService productAppService, ILogger<ProductsController> logger)
        {
            _productAppService = productAppService;
            _logger = logger;
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<ActionResult> Get(int? maxPrice = null, string? size = null, string? highlights = null)
        {
            try
            {
                await SeedProductsAsync();
                var dto = _productAppService.GetProducts(_products, maxPrice ?? 0, size ?? "", highlights ?? "");
                return Ok(new OutputDto<ProductOutputDto>()
                {
                    Results = dto,
                    IsSuccess = true,
                });
            }
            catch (HttpRequestException error)
            {
                _logger.LogError($"Request fail with exception: {error.Message}");
                return Ok(new OutputDto<ProductOutputDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = $"Sorry, could not load product list. Reason: {error.Message}"
                });
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return Ok(new OutputDto<ProductOutputDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = error.Message
                });
            }
        }
        #endregion

        #region Helper Methods

        private async Task SeedProductsAsync()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var resBody = await response.Content.ReadAsStringAsync();
                _products = JsonSerializer.Deserialize<ProductInputDto>(resBody)?.Products ?? new List<Product>();
            }
            else
            {
                _logger.LogError($"Request was not successful with reason: {response.ReasonPhrase} and status code {response.StatusCode}");
                _products = new List<Product>();
            }
        }
        #endregion
    }
}