using SparkDrums.Data.Models.Orders;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Orders
{
    public class OrdersReader : IOrdersReader
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public OrdersReader(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SalesOrder> GetAllSalesOrdersFromDb()
        {
            throw new System.NotImplementedException();
        }

        public SalesOrder GetSalesOrderFromDbById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
