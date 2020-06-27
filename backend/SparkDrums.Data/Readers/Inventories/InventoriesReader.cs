using SparkDrums.Data.Models.Inventories;
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

        public IEnumerable<ProductInventory> GetAllProductInventoryRecordsFromDb()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductInventorySnapshot> GetAllProductInventorySnapshotsFromDb()
        {
            throw new System.NotImplementedException();
        }

        public ProductInventory GetProductInventoryRecordFromDbById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ProductInventorySnapshot GetProductInventorySnapshotById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
