using System.Collections.Generic;
using System.Linq;
using EntityOrders = SparkDrums.Data.Models.Orders;
using ServiceOrders = SparkDrums.Services.Models.Orders;


namespace SparkDrums.Services.Serialisation
{
    public static class OrderMapper
    {
        // in goes an entity model and out comes a service model
        public static ServiceOrders.SalesOrder SerialiseSalesOrder(EntityOrders.SalesOrder entityOrder)
        {
            var serviceOrder = new ServiceOrders.SalesOrder()
            {
                Id = entityOrder.Id,
                Customer = CustomerMapper.SerialiseCustomer(entityOrder.Customer),
                Items = SerialiseSalesOrderItems(entityOrder.Items),
                IsPaid = entityOrder.IsPaid,
                CreatedOn = entityOrder.CreatedOn,
                UpdatedOn = entityOrder.UpdatedOn
            };

            return serviceOrder;
        }

        public static List<ServiceOrders.SalesOrderItem> SerialiseSalesOrderItems(List<EntityOrders.SalesOrderItem> entityOrderItems)
        {
            var serviceOrderItems = entityOrderItems
                .Select(i => SerialiseIndividualSalesOrderItem(i))
                .ToList();

            return serviceOrderItems;
        }

        public static ServiceOrders.SalesOrderItem SerialiseIndividualSalesOrderItem(EntityOrders.SalesOrderItem entityOrderItem)
        {
            var serviceOrderItem = new ServiceOrders.SalesOrderItem()
            {
                Id = entityOrderItem.Id,
                Product = ProductMapper.SerialiseProduct(entityOrderItem.Product),
                QuantityOrdered = entityOrderItem.QuantityOrdered
            };

            return serviceOrderItem;
        }


        // in comes a service model and out goes an entity model
        public static EntityOrders.SalesOrder SerialiseSalesOrder(ServiceOrders.SalesOrder serviceOrder)
        {
            var entityOrder = new EntityOrders.SalesOrder()
            {
                Id = serviceOrder.Id,
                Customer = CustomerMapper.SerialiseCustomer(serviceOrder.Customer),
                Items = SerialiseSalesOrderItems(serviceOrder.Items),
                IsPaid = serviceOrder.IsPaid,
                CreatedOn = serviceOrder.CreatedOn,
                UpdatedOn = serviceOrder.UpdatedOn
            };

            return entityOrder;
        }

        public static List<EntityOrders.SalesOrderItem> SerialiseSalesOrderItems(List<ServiceOrders.SalesOrderItem> serviceOrderItems)
        {
            var entityOrderItems = serviceOrderItems
                .Select(i => SerialiseIndividualSalesOrderItem(i))
                .ToList();

            return entityOrderItems;
        }

        public static EntityOrders.SalesOrderItem SerialiseIndividualSalesOrderItem(ServiceOrders.SalesOrderItem serviceOrderItem)
        {
            var entityOrderItem = new EntityOrders.SalesOrderItem()
            {
                Id = serviceOrderItem.Id,
                Product = ProductMapper.SerialiseProduct(serviceOrderItem.Product),
                QuantityOrdered = serviceOrderItem.QuantityOrdered
            };

            return entityOrderItem;
        }
    }
}
