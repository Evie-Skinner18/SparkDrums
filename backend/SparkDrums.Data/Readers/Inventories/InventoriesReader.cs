using EntityInventories = SparkDrums.Data.Models.Inventories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace SparkDrums.Data.Readers.Inventories
{
    public class InventoriesReader : IInventoriesReader
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public InventoriesReader(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<EntityInventories.ProductInventory> GetCurrentProductInventoryFromDb()
        {
            var allProductInventories = _dbContext.ProductInventories
                .Include(pi => pi.Product)
                .Where(pi => !pi.Product.IsArchived);
            return allProductInventories;
        }

        public EntityInventories.ProductInventory GetProductInventoryRecordFromDbByProductId(int id)
        {
            var productInventoryForGivenProduct = _dbContext.ProductInventories
                .Include(pi => pi.Product)
                .SingleOrDefault(pi => pi.Product.Id == id);
            return productInventoryForGivenProduct;
        }

        public IEnumerable<EntityInventories.ProductInventorySnapshot> GetSnapshotHistoryFromDb(DateTime earliestTime)
        {
            var snapshotHistory = _dbContext.ProductInventorySnapshots
                .Include(s => s.Product)
                .Where(s => s.SnapshotTime > earliestTime && !s.Product.IsArchived);
            return snapshotHistory;
        }
    }
}
