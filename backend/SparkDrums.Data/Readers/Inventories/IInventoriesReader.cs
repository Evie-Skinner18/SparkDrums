using SparkDrums.Data.Models.Inventories;
using System;
using System.Collections.Generic;

namespace SparkDrums.Data.Readers.Inventories
{
    public interface IInventoriesReader
    {
        IEnumerable<ProductInventory> GetCurrentProductInventoryFromDb();

        ProductInventory GetProductInventoryRecordFromDbByProductId(int id);

        IEnumerable<ProductInventorySnapshot> GetSnapshotHistoryFromDb(DateTime earliestTime);
    }
}
