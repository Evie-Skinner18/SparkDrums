using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EntityInventories = SparkDrums.Data.Models.Inventories;


namespace SparkDrums.Data.Writers.Inventories
{
    public class InventoriesWriter : IInventoriesWriter
    {

        private SparkDrumsDbContext _dbContext { get; set; }

        public InventoriesWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void AddProductInventoryRecordToDb(EntityInventories.ProductInventory productInventoryRecord)
        {
            _dbContext.Add(productInventoryRecord);
            _dbContext.SaveChanges();
        }

        public void UpdateQuantityAvailableInDb(int productId, int adjustment)
        {
            var currentInventoryForGivenProduct = _dbContext.ProductInventories
                .Include(pi => pi.Product)
                .SingleOrDefault(pi => pi.Product.Id == productId);

            currentInventoryForGivenProduct.QuantityAvailable += adjustment;

            _dbContext.ProductInventories.Update(currentInventoryForGivenProduct);
            _dbContext.SaveChanges();            
        }

        public void AddProductInventorySnapshotToDb(EntityInventories.ProductInventory productInventoryRecord)
        {
            var snapshotToAdd = new EntityInventories.ProductInventorySnapshot()
            {
                Product = productInventoryRecord.Product,
                QuantityAvailable = productInventoryRecord.QuantityAvailable,
                SnapshotTime = DateTime.Now
            };

            _dbContext.Add(snapshotToAdd);
            _dbContext.SaveChanges();
        }
    }
}
