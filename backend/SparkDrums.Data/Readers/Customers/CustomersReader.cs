using EntityCustomers = SparkDrums.Data.Models.Customers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SparkDrums.Data.Readers.Customers
{
    public class CustomersReader : ICustomersReader
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public CustomersReader(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // test that this returns empty IEnumerable if it can't find any customers
        public IEnumerable<EntityCustomers.Customer> GetAllCustomersFromDb()
        {
            var allCustomers = _dbContext.Customers
                .Include(c => c.PrimaryAddress)
                .OrderBy(c => c.Surname);
            return allCustomers;
        }

        // to- do: replace all 'Find' statements with SingleOrDefault to avoid null situation
        public EntityCustomers.Customer GetCustomerFromDbById(int id)
        {
            var customerWithGivenId = _dbContext.Customers
                .SingleOrDefault(c=> c.Id == id);
            return customerWithGivenId;
        }
    }
}
