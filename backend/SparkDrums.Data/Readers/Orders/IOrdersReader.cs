using SparkDrums.Data.Models.Orders;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Orders
{
    public interface IOrdersReader
    {
        IEnumerable<SalesOrder> GetAllSalesOrdersFromDb();

        SalesOrder GetSalesOrderFromDbById(int id);
    }
}
