using SparkDrums.Data.Models.Customers;
using System.Collections.Generic;

namespace SparkDrums.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        public ServiceResponse<Customer> CreateCustomer(Customer customerToAdd)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<Customer> DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
