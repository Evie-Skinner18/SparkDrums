using SparkDrums.Data.Models.Inventories;
using SparkDrums.Data.Models.Products;

namespace SparkDrums.Data.Writers.Inventories
{
    public interface IInventoriesWriter
    {
        void UpdateQuantityAvailableInDb(int id, int adjustment);

        void AddProductInventorySnapshotToDb();
    }
}
