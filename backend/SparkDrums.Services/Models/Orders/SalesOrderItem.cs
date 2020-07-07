using SparkDrums.Services.Models.Products;

namespace SparkDrums.Services.Models.Orders
{
    public class SalesOrderItem
    {
        public int Id { get; set; }

        public int QuantityOrdered { get; set; }

        public Product Product { get; set; }
    }
}
