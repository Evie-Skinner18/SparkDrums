using EntityInventories = SparkDrums.Data.Models.Inventories;
using EntityProducts = SparkDrums.Data.Models.Products;

namespace SparkDrums.Data.Writers.Inventories
{
    public class InventoriesWriter : IInventoriesWriter
    {

        private SparkDrumsDbContext _dbContext { get; set; }

        public InventoriesWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductInventoryRecordToDb(EntityInventories.ProductInventory productInventoryRecord)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProductInventoryRecordFromDb(EntityProducts.Product productToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}
