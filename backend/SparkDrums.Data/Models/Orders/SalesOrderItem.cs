using SparkDrums.Data.Models.Products;

namespace SparkDrums.Data.Models.Orders
{
    public class SalesOrderItem
    {
        public int Id { get; set; }

        public int QuantityOrdered { get; set; }

        public Product Product { get; set; }
    }
}
