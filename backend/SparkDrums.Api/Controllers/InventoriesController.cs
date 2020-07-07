using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparkDrums.Services.Inventories;
using ServiceInventories = SparkDrums.Services.Models.Inventories;

namespace SparkDrums.Api.Controllers
{
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private ILogger<InventoriesController> _logger { get; set; }

        private IInventoriesService _inventoriesService { get; set; }

        public InventoriesController(ILogger<InventoriesController> logger, IInventoriesService inventoriesService)
        {
            _logger = logger;
            _inventoriesService = inventoriesService;
        }

        [HttpGet("/api/inventories")]
        public ActionResult GetCurrentInventory()
        {
            var currentInventory = _inventoriesService.GetCurrentProductInventory();
            return Ok(currentInventory);
        }

        [HttpGet("api/inventories/{id}")]
        public ActionResult GetCurrentInventoryForProduct(int id)
        {
            _logger.LogInformation($"Getting product inventory record for product {id}...");
            var inventoryForGivenProduct = _inventoriesService.GetProductInventoryRecordByProductId(id);
            return Ok(inventoryForGivenProduct);
        }

        [HttpPatch("/api/inventories")]
        public ActionResult UpdateInventory([FromBody] ServiceInventories.Shipment shipment)
        {
            _logger.LogInformation($"Updating inventory for a shipment of product {shipment.ProductId} with adjustment {shipment.Adjustment}");
            var inventoryResponse = _inventoriesService.UpdateQuantityAvailable(shipment.ProductId, shipment.Adjustment);
            return Ok(inventoryResponse);
        }

    }
}
