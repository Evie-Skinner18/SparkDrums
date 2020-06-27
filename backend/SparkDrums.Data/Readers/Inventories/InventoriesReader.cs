using EntityInventories = SparkDrums.Data.Models.Inventories;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public EntityInventories.ProductInventory GetProductInventoryRecordFromDbById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EntityInventories.ProductInventorySnapshot> GetSnapshotHistoryFromDb()
        {
            throw new System.NotImplementedException();
        }
    }
}
