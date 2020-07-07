using SparkDrums.Data.Models.Inventories;

namespace SparkDrums.Data.Writers.Inventories
{
    public interface IInventoriesWriter
    {
        void AddProductInventoryRecordToDb(ProductInventory productInventoryRecord);

        void UpdateQuantityAvailableInDb(int productId, int adjustment);

        void AddProductInventorySnapshotToDb(ProductInventory productInventoryRecord);
    }
}
