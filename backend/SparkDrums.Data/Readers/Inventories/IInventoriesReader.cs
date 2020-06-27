using SparkDrums.Data.Models.Inventories;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Inventories
{
    public interface IInventoriesReader
    {
        IEnumerable<ProductInventory> GetCurrentProductInventoryFromDb();

        ProductInventory GetProductInventoryRecordFromDbById(int id);

        IEnumerable<ProductInventorySnapshot> GetSnapshotHistoryFromDb();
    }
}
