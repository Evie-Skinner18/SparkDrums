using SparkDrums.Data.Models.Inventories;
using SparkDrums.Data.Models.Products;

namespace SparkDrums.Data.Writers.Inventories
{
    public class InventoriesWriter : IInventoriesWriter
    {

        private SparkDrumsDbContext _dbContext { get; set; }

        public InventoriesWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductInventoryRecordToDb(ProductInventory productInventoryRecord)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProductInventoryRecordFromDb(Product productToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}
