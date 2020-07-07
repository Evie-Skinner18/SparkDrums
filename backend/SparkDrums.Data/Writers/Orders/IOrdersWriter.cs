using SparkDrums.Data.Models.Orders;
using System.Collections.Generic;

namespace SparkDrums.Data.Writers.Orders
{
    public interface IOrdersWriter
    {
        void AddSalesOrderToDb(SalesOrder orderToAdd);

        void MarkOrderAsPaidInDb(int id);

        void DeleteSalesOrderFromDb(SalesOrder orderToDelete);

        void AddItemsToSalesOrderInDb(List<SalesOrderItem> orderItems);

        void DeleteItemsFromSalesOrderInDb(List<int> orderItemIds);
    }
}
