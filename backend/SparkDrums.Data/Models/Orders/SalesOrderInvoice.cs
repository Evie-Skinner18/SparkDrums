using SparkDrums.Data.Models.Customers;

namespace SparkDrums.Data.Models.Orders
{
    public class SalesOrderInvoice
    {
        public int Id { get; set; }

        public SalesOrder Order { get; set; }

        public decimal Price { get; set; }

        public CustomerAddress RecipientAddress { get; set; }
    }
}
