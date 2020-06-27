using SparkDrums.Data.Models.Inventories;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Inventories
{
    public interface IInventoriesReader
    {
        IEnumerable<ProductInventory> GetAllProductInventoryRecordsFromDb();

        ProductInventory GetProductInventoryRecordFromDbById(int id);

        IEnumerable<ProductInventorySnapshot> GetAllProductInventorySnapshotsFromDb();

        ProductInventorySnapshot GetProductInventorySnapshotById(int id);
    }
}
