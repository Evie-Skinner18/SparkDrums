using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            return Ok();
        }
    }
}
