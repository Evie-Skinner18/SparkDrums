using System;

namespace SparkDrums.Data.Models.Products
{
    // this will help us keep audit trail
    public class ProductInventorySnapshot
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        // at this point in time, how many were there in the inventory?
        public int QuantityAvailable { get; set; }

        // when was this snapshot taken?
        public DateTime SnapshotTime { get; set; }
    }

    // at half four on Fri 15th May, there were {QuantityAvailable} cowbells in stock

}
