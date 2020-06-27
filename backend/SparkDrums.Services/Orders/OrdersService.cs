using ServiceOrders = SparkDrums.Services.Models.Orders;
using SparkDrums.Data.Readers.Orders;
using SparkDrums.Data.Writers.Orders;
using System.Collections.Generic;

namespace SparkDrums.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private IOrdersReader _ordersReader { get; set; }

        private IOrdersWriter _ordersWriter { get; set; }

        public OrdersService(IOrdersReader ordersReader, IOrdersWriter ordersWriter)
        {
            _ordersReader = ordersReader;
            _ordersWriter = ordersWriter;
        }

        public ServiceResponse<ServiceOrders.SalesOrder> CreateSalesOrder(ServiceOrders.SalesOrder orderToAdd)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<ServiceOrders.SalesOrder> DeleteSalesOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceOrders.SalesOrder> GetAllSalesOrders()
        {
            throw new System.NotImplementedException();
        }

        public ServiceOrders.SalesOrder GetSalesOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> GenerateInvoiceForOrder(ServiceOrders.SalesOrder order)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> MarkOrderAsFulfilled(int id)
        {
            throw new System.NotImplementedException();
        }


        public IEnumerable<ServiceOrders.SalesOrderItem> GetAllOrderItemsForSalesOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceOrders.SalesOrderItem GetOrderItemById(int id)
        {
            throw new System.NotImplementedException();
        }       
    }
}
