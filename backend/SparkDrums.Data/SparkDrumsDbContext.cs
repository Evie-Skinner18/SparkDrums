using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SparkDrums.Data.Models.Customers;
using SparkDrums.Data.Models.Inventories;
using SparkDrums.Data.Models.Orders;
using SparkDrums.Data.Models.Products;

namespace SparkDrums.Data
{
    public class SparkDrumsDbContext : IdentityDbContext
    {
        public SparkDrumsDbContext() { }

        public SparkDrumsDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductInventory> ProductInventories { get; set; }

        public virtual DbSet<ProductInventorySnapshot> ProductInventorySnapshots { get; set; }

        public virtual DbSet<SalesOrder> SalesOrders { get; set; }

        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
