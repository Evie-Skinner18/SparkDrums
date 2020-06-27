using EntityCustomers = SparkDrums.Data.Models.Customers;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Customers
{
    public class CustomersReader : ICustomersReader
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public CustomersReader(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EntityCustomers.Customer> GetAllCustomersFromDb()
        {
            throw new System.NotImplementedException();
        }

        public EntityCustomers.Customer GetCustomerFromDbById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
