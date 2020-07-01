using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SparkDrums.Services.Customers;
using ServiceCustomers = SparkDrums.Services.Models.Customers;

namespace SparkDrums.Api.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ILogger<CustomersController> _logger { get; set; }

        private ICustomersService _customersService { get; set; }

        public CustomersController(ICustomersService customersService, ILogger<CustomersController> logger)
        {
            _logger = logger;
            _customersService = customersService;
        }


        [HttpGet("/api/customers")]
        public ActionResult GetAllCustomers()
        {
            _logger.LogInformation("Getting all customers...");
            var allCustomers = _customersService.GetAllCustomers();
            return Ok(allCustomers);
        }

        [HttpPost("/api/customers")]
        public ActionResult CreateCustomer([FromBody] ServiceCustomers.Customer customer)
        {
            _logger.LogInformation($"Creating customer {customer.GivenName} {customer.Surname}");
            var customerResponse =_customersService.CreateCustomer(customer);
            return Ok(customerResponse);
        }

        [HttpDelete("/api/customers/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation($"Deleting customer {id}...");
            var customerResponse = _customersService.DeleteCustomer(id);
            return Ok(customerResponse);
        }
        
    }
}
