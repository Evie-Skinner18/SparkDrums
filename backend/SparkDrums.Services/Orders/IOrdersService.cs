using System.Collections.Generic;
using ServiceOrders = SparkDrums.Services.Models.Orders;

namespace SparkDrums.Services.Orders
{
    public interface IOrdersService
    {
        IEnumerable<ServiceOrders.SalesOrder> GetAllSalesOrders();

        ServiceOrders.SalesOrder GetSalesOrderById(int id);

        ServiceResponse<bool> GenerateInvoiceForOrder(ServiceOrders.SalesOrder order);

        ServiceResponse<bool> MarkOrderAsPaid(int id);

        ServiceResponse<ServiceOrders.SalesOrder> CreateSalesOrder(ServiceOrders.SalesOrder orderToAdd);

        ServiceResponse<ServiceOrders.SalesOrder> DeleteSalesOrder(int id);


        IEnumerable<ServiceOrders.SalesOrderItem> GetAllOrderItemsForSalesOrder(int id);

        ServiceOrders.SalesOrderItem GetOrderItemById(int id);
    }
}
