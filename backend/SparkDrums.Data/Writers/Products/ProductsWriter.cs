using EntityProducts = SparkDrums.Data.Models.Products;
using EntityInventories = SparkDrums.Data.Models.Inventories;


namespace SparkDrums.Data.Writers.Products
{
    public class ProductsWriter : IProductsWriter
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public ProductsWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductToDb(EntityProducts.Product productToAdd)
        {
            _dbContext.Products.Add(productToAdd);
            _dbContext.SaveChanges();
        }

        public void DeleteProductFromDb(EntityProducts.Product productToDelete)
        {
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public void AddProductInventoryRecordToDb(EntityInventories.ProductInventory productInventoryRecord)
        {
            _dbContext.ProductInventories.Add(productInventoryRecord);
            _dbContext.SaveChanges();
        }

        public void AddArchiveRecordToDb(EntityProducts.Product product)
        {
            _dbContext.Products.Update(product)
                .Entity
                .IsArchived = true;
            _dbContext.SaveChanges();
        }
    }
}