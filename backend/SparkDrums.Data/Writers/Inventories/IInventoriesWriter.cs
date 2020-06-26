using SparkDrums.Data.Models.Inventories;
using SparkDrums.Data.Models.Products;

namespace SparkDrums.Data.Writers.Inventories
{
    public interface IInventoriesWriter
    {
        void AddProductInventoryRecordToDb(ProductInventory productInventoryRecord);

        void DeleteProductInventoryRecordFromDb(Product productToDelete);
    }
}
