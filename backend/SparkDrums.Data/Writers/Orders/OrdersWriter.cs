using System.Collections.Generic;
using EntityOrders = SparkDrums.Data.Models.Orders;

namespace SparkDrums.Data.Writers.Orders
{
    public class OrdersWriter : IOrdersWriter
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public OrdersWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSalesOrderToDb(EntityOrders.SalesOrder orderToAdd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSalesOrderFromDb(EntityOrders.SalesOrder orderToDelete)
        {
            throw new System.NotImplementedException();
        }

        public void AddItemsToSalesOrderInDb(List<EntityOrders.SalesOrderItem> orderItems)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteItemsFromSalesOrderInDb(List<int> orderItemIds)
        {
            throw new System.NotImplementedException();
        }

        public void MarkOrderAsFulfilledInDb(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
