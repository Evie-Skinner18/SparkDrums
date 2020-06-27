using SparkDrums.Data.Models.Customers;

namespace SparkDrums.Data.Writers.Customers
{
    public class CustomersWriter : ICustomersWriter
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public CustomersWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomerToDb(Customer customerToAdd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCustomerFromDb(Customer customerToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}
