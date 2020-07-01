using System;
using System.Collections.Generic;

namespace SparkDrums.Services.Models.Orders
{
    public class SalesOrder
    {
        public int Id { get; set; }

        // in goes a customer id in the POST request for placing an order, and the customers reader injected into OrdersService grabs the relevant customer from the DB
        // from this id
        public int CustomerId { get; set; }

        public List<SalesOrderItem> Items { get; set; }

        public bool IsPaid { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
