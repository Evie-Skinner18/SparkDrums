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

       // to-do: add a Dimensions or Size prop to the Product model. so you can have the same product but e.g in 5A, 14" by 7" etc
        [HttpGet("/api/products")]
        public ActionResult GetAllProducts()
        {
            _logger.LogInformation("Getting all products...");
            var allProducts = _productsService.GetAllProducts();
            return Ok(allProducts);
        }
    }
}
