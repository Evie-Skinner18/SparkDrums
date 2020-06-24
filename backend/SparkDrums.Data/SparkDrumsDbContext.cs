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
    }
}
