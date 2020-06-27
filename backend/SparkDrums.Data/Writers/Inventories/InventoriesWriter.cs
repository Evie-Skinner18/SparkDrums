using EntityInventories = SparkDrums.Data.Models.Inventories;


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
            _dbContext.ProductInventories.Add(productInventoryRecord);
            _dbContext.SaveChanges();
        }

        public void UpdateQuantityAvailableInDb(int id, int adjustment)
        {
            throw new System.NotImplementedException();
        }

        public void AddProductInventorySnapshotToDb()
        {
            throw new System.NotImplementedException();
        }
    }
}
