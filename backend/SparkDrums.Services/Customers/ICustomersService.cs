using System.Collections.Generic;
using ServiceCustomers = SparkDrums.Services.Models.Customers;

namespace SparkDrums.Services.Customers
{
    public interface ICustomersService
    {
        IEnumerable<ServiceCustomers.Customer> GetAllCustomers();
        ServiceCustomers.Customer GetCustomerById(int id);
        ServiceResponse<ServiceCustomers.Customer> CreateCustomer(ServiceCustomers.Customer customerToAdd);
        ServiceResponse<ServiceCustomers.Customer> DeleteCustomer(int id);
    }
}
