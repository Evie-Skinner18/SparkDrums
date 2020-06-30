using EntityOrders = SparkDrums.Data.Models.Orders;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            var allOrders = _dbContext.SalesOrders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .Include(o => o.Customer)
                    .ThenInclude(c => c.PrimaryAddress);

            return allOrders;
        }

        public EntityOrders.SalesOrder GetSalesOrderFromDbById(int id)
        {
       
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
