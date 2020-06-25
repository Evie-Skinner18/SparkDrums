using SparkDrums.Data.Models.Customers;
using System;
using System.Collections.Generic;

namespace SparkDrums.Data.Models.Orders
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public List<SalesOrderItem> Items { get; set; }

        public bool IsPaid { get; set; }

        // when was the order placed?
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }

}
