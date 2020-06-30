using SparkDrums.Data.Models.Inventories;

namespace SparkDrums.Data.Writers.Inventories
{
    public interface IInventoriesWriter
    {
        void AddProductInventoryRecordToDb(ProductInventory productInventoryRecord);

        void UpdateQuantityAvailableInDb(int id, int adjustment);

        void AddProductInventorySnapshotToDb(ProductInventory productInventoryRecord);
    }
}
