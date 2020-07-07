using SparkDrums.Services.Models.Products;
using System;

namespace SparkDrums.Services.Models.Inventories
{
    public class ProductInventorySnapshot
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int QuantityAvailable { get; set; }

        public DateTime SnapshotTime { get; set; }
    }
}
