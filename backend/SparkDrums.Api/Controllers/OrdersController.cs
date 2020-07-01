using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparkDrums.Services.Customers;
using SparkDrums.Services.Orders;
using ServiceOrders = SparkDrums.Services.Models.Orders;

namespace SparkDrums.Api.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ILogger<OrdersController> _logger { get; set; }

        private IOrdersService _ordersService { get; set; }

        private ICustomersService _customersService { get; set; }

        public OrdersController(ILogger<OrdersController> logger, IOrdersService ordersService, ICustomersService customersService)
        {
            _logger = logger;
            _ordersService = ordersService;
            _customersService = customersService;
        }

        [HttpPost("/api/placeorder")]
        public ActionResult PlaceOrder([FromBody] ServiceOrders.SalesOrder order)
        {
            _logger.LogInformation($"Placing order {order.Id} for customer {order.CustomerId}");
            var orderResponse = _ordersService.PlaceOrder(order);
            return Ok(orderResponse);
        }
    }
}
