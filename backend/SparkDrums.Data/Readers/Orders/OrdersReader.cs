using EntityOrders = SparkDrums.Data.Models.Orders;
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

        public IEnumerable<EntityOrders.SalesOrder> GetAllSalesOrdersFromDb()
        {
            throw new System.NotImplementedException();
        }

        public EntityOrders.SalesOrder GetSalesOrderFromDbById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EntityOrders.SalesOrderItem> GetOrderItemsFromDbByOrderId(int id)
        {
            throw new System.NotImplementedException();
        }

        public EntityOrders.SalesOrderItem GetOrderItemFromDbById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
