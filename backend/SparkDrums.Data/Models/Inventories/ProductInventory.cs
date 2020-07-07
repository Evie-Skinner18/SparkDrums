using SparkDrums.Data.Models.Products;
using System;

namespace SparkDrums.Data.Models.Inventories
{
    public class ProductInventory
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        // how many do we actually have at the mo?
        public int QuantityAvailable { get; set; }

        // how many of this product constitutes a healthy stock level? This could help with WhatsIn
        public int IdealQuantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
