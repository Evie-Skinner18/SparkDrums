using SparkDrums.Data.Models.Orders;

namespace SparkDrums.Data.Writers.Orders
{
    public interface IOrdersWriter
    {
        void AddSalesOrderToDb(SalesOrder orderToAdd);

        void DeleteSalesOrderFromDb(SalesOrder orderToDelete);
    }
}
