using SparkDrums.Data.Models;


namespace SparkDrums.Data.Writers.Products
{
    public class ProductsWriter : IProductsWriter
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public ProductsWriter(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductToDb(Product productToAdd)
        {
            _dbContext.Products.Add(productToAdd);
            _dbContext.SaveChanges();
        }

        public void DeleteProductFromDb(Product productToDelete)
        {
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }
    }
}