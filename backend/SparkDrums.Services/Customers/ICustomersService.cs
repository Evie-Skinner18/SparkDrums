using System.Collections.Generic;
using EntityCustomers = SparkDrums.Data.Models.Customers;

namespace SparkDrums.Services.Customers
{
    public interface ICustomersService
    {
        IEnumerable<EntityCustomers.Customer> GetAllCustomers();
        EntityCustomers.Customer GetCustomerById(int id);
        ServiceResponse<EntityCustomers.Customer> CreateCustomer(EntityCustomers.Customer customerToAdd);
        ServiceResponse<EntityCustomers.Customer> DeleteCustomer(int id);
    }
}
