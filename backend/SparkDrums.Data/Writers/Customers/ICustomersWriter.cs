using SparkDrums.Data.Models.Customers;

namespace SparkDrums.Data.Writers.Customers
{
    public interface ICustomersWriter
    {
        void AddCustomerToDb(Customer customerToAdd);
        void DeleteCustomerFromDb(Customer customerToDelete);        
    }
}
