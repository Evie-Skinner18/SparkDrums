using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SparkDrums.Data.Models;

namespace SparkDrums.Data
{
    public class SparkDrumsDbContext : IdentityDbContext
    {
        public SparkDrumsDbContext() { }

        public SparkDrumsDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductInventory> ProductInventoriess { get; set; }

        public virtual DbSet<ProductInventorySnapshot> ProductInventorySnapshots { get; set; }

        public virtual DbSet<SalesOrder> SalesOrders { get; set; }

        public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
