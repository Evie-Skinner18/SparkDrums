using SparkDrums.Services.Models.Products;
using System;

namespace SparkDrums.Services.Models.Inventories
{
    public class ProductInventory
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int QuantityAvailable { get; set; }

        public int IdealQuantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
