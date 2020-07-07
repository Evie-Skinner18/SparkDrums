using SparkDrums.Data.Models.Customers;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Customers
{
    public interface ICustomersReader
    {
        IEnumerable<Customer> GetAllCustomersFromDb();
        Customer GetCustomerFromDbById(int id);        
    }
}
