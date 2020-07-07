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
using SparkDrums.Data.Readers.Customers;
using System.Linq;

namespace SparkDrums.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        // this class has too many dependencies now :s
        private IOrdersReader _ordersReader { get; set; }

        private IOrdersWriter _ordersWriter { get; set; }

        private IProductsReader _productsReader { get; set; }

        private IInventoriesWriter _inventoriesWriter { get; set; }

        private ICustomersReader _customersReader { get; set; }

        private ILogger<OrdersService> _logger { get; set; }

        public OrdersService(IOrdersReader ordersReader, IOrdersWriter ordersWriter, IProductsReader productsReader, IInventoriesWriter inventoriesWriter, ICustomersReader customersReader,
            ILogger<OrdersService> logger)
        {
            _ordersReader = ordersReader;
            _ordersWriter = ordersWriter;
            _productsReader = productsReader;
            _inventoriesWriter = inventoriesWriter;
            _customersReader = customersReader;
            _logger = logger;         
        }
       

        public ServiceResponse<ServiceOrders.SalesOrder> DeleteSalesOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceOrders.SalesOrder> GetAllSalesOrders()
        {
            var entityOrders = _ordersReader.GetAllSalesOrdersFromDb();
            var serviceOrders = entityOrders
                .Select(o => OrderMapper
                .SerialiseSalesOrder(o));
            return serviceOrders;
        }

        public ServiceOrders.SalesOrder GetSalesOrderById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> PlaceOrder(ServiceOrders.SalesOrder order)
        {
            _logger.LogInformation($"Getting items from new order placed by customer {order.CustomerId}");

            var boolResponse = new ServiceResponse<bool>()
            {
                Time = DateTime.Now
            };

            foreach (var item in order.Items)
            {
                var entityProductWithGivenId = _productsReader.GetProductFromDbById(item.Product.Id);
                var serviceProduct = ProductMapper.SerialiseProduct(entityProductWithGivenId);
                item.Product = serviceProduct;

                // find the inventory record that matches given product id as opposed to find inventory record with given inventory record id. Like this we only need to inject
                // product reader and inventoies writer no need for inventories reader aswell
                try
                {
                    _inventoriesWriter.UpdateQuantityAvailableInDb(item.Product.Id, -item.QuantityOrdered);
                    item.Product.UpdatedOn = DateTime.Now;
                }
                catch (Exception e)
                {
                    boolResponse.Data = false;
                    boolResponse.IsSuccessful = false;
                    boolResponse.Message = $"Failed to update quanitity available in DB. stack trace: {e.StackTrace}";
                }
            }

            _logger.LogInformation("Updated quantity available of each item in this order. Now creating sales order in DB...");
            var orderResponse = CreateSalesOrder(order);
            boolResponse.Data = orderResponse.IsSuccessful;
            boolResponse.IsSuccessful = orderResponse.IsSuccessful;
            boolResponse.Message = $"Successfully placed order {order.Id}!";            

            return boolResponse;
        }

        public ServiceResponse<ServiceOrders.SalesOrder> CreateSalesOrder(ServiceOrders.SalesOrder orderToAdd)
        {
            var response = new ServiceResponse<ServiceOrders.SalesOrder>()
            {
                Time = DateTime.Now,
                Data = orderToAdd
            };

            try
            {
                var entityCustomer = _customersReader.GetCustomerFromDbById(orderToAdd.CustomerId);
                var entityOrder = OrderMapper.SerialiseSalesOrder(orderToAdd);
                entityOrder.Customer = entityCustomer;
                _ordersWriter.AddSalesOrderToDb(entityOrder);
                response.IsSuccessful = true;
                response.Message = $"Order number {orderToAdd.Id} successfully created";
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = $"Failed to create order number {orderToAdd.Id} placed by customer {orderToAdd.CustomerId} {orderToAdd.CustomerId}. Stack trace: {e.StackTrace}";
            }

            return response;
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
