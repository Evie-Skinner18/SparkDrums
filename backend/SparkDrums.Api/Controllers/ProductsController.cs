using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparkDrums.Services.Products;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPatch("/api/products/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation($"Archiving product {id}");
            var archiveResponse = _productsService.ArchiveProduct(id);
            return Ok(archiveResponse);
        }


    }
}
