using SparkDrums.Data.Models.Orders;

namespace SparkDrums.Data.Writers.Orders
{
    public class OrdersWriter : IOrdersWriter
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public OrdersWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSalesOrderToDb(SalesOrder orderToAdd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSalesOrderFromDb(SalesOrder orderToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}
