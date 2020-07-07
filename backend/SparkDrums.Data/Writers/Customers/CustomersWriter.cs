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
            _dbContext.Add(customerToAdd);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomerFromDb(EntityCustomers.Customer customerToDelete)
        {
            _dbContext.Remove(customerToDelete);
            _dbContext.SaveChanges();
        }
    }
}
