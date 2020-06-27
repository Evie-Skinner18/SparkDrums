using EntityCustomers = SparkDrums.Data.Models.Customers;

namespace SparkDrums.Data.Writers.Customers
{
    public class CustomersWriter : ICustomersWriter
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public CustomersWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomerToDb(EntityCustomers.Customer customerToAdd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCustomerFromDb(EntityCustomers.Customer customerToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}
