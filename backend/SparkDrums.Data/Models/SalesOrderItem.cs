using System;

namespace SparkDrums.Data.Models
{
    public class SalesOrderItem
    {
        public int Id { get; set; }

        public int QuantityOrdered { get; set; }

        public Product Product { get; set; }
    }
}
