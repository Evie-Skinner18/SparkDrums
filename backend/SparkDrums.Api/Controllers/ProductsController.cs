using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparkDrums.Services.Products;
using ServiceProducts = SparkDrums.Services.Models.Products;

namespace SparkDrums.Api.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> _logger { get; set; }
        private IProductsService _productsService { get; set; }

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet("/api/products")]
        public ActionResult GetAllProducts()
        {
            _logger.LogInformation("Getting all products...");
            var allProducts = _productsService.GetAllProducts();
            return Ok(allProducts);
        }

        [HttpPost("/api/products")]
        public ActionResult CreateProduct([FromBody] ServiceProducts.Product product)
        {
            _logger.LogInformation($"Creating product {product.Name}...");
            var productResponse = _productsService.CreateProduct(product);
            return Ok(productResponse);
        }

        [HttpPatch("/api/products/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation($"Archiving product {id}");
            var archiveResponse = _productsService.ArchiveProduct(id);
            return Ok(archiveResponse);
        }


    }
}
