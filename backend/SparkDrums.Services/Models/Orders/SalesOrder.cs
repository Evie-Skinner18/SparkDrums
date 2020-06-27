using SparkDrums.Services.Models.Customers;
using System;
using System.Collections.Generic;

namespace SparkDrums.Services.Models.Orders
{
    public class SalesOrder
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public List<SalesOrderItem> Items { get; set; }

        public bool IsPaid { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
