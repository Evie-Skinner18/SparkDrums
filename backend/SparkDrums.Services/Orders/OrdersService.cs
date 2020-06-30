using ServiceOrders = SparkDrums.Services.Models.Orders;
using SparkDrums.Data.Readers.Orders;
using SparkDrums.Data.Writers.Orders;
using System.Collections.Generic;
using System;
using SparkDrums.Services.Serialisation;
using Microsoft.Extensions.Logging;
using SparkDrums.Data.Readers.Products;
using SparkDrums.Data.Readers.Inventories;
using SparkDrums.Data.Writers.Inventories;

namespace SparkDrums.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        // this class has too many dependencies now :s
        private IOrdersReader _ordersReader { get; set; }

        private IOrdersWriter _ordersWriter { get; set; }

        private IProductsReader _productsReader { get; set; }

        private IInventoriesWriter _inventoriesWriter { get; set; }

        private ILogger<OrdersService> _logger { get; set; }

        public OrdersService(IOrdersReader ordersReader, IOrdersWriter ordersWriter, IProductsReader productsReader, IInventoriesWriter inventoriesWriter, ILogger<OrdersService> logger)
        {
            _ordersReader = ordersReader;
            _ordersWriter = ordersWriter;
            _productsReader = productsReader;
            _inventoriesWriter = inventoriesWriter;
            _logger = logger;         
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
            //var entityOrder = OrderMapper.SerialiseSalesOrder(order);
   
            foreach (var item in order.Items)
            {
                var entityProductWithGivenId = _productsReader.GetProductFromDbById(item.Product.Id);
                var serviceProduct = ProductMapper.SerialiseProduct(entityProductWithGivenId);
                item.Product = serviceProduct;

                // find the inventory record that matches given product id as opposed to find inventory record with given inventory record id
                _inventoriesWriter.UpdateQuantityAvailableInDb(item.Product.Id, -item.QuantityOrdered);
                item.Product.UpdatedOn = DateTime.Now;
            }

        }

        public ServiceResponse<bool> MarkOrderAsPaid(int id)
        {
            var response = new ServiceResponse<bool>()
            {
                Time = DateTime.Now
            };

            try
            {
                _ordersWriter.MarkOrderAsPaidInDb(id);
                response.IsSuccessful = true;
                response.Data = true;
                response.Message = $"Order {id} successfully marked as paid!";
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Data = false;
                response.Message = $"Failed to mark order {id}  as paid. Stack trace: {e.StackTrace}";
            }

            return response;
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
