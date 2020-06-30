using SparkDrums.Data.Models.Products;
using System.Collections.Generic;
using System.Linq;

namespace SparkDrums.Data.Readers.Products
{

    public class ProductsReader : IProductsReader
    {
        private SparkDrumsDbContext _dbContext { get; set; }

        public ProductsReader(SparkDrumsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProductsFromDb()
        {
            var allProducts = _dbContext.Products;
            return allProducts;
        }

        public Product GetProductFromDbById(int id)
        {
            var productWithGivenId = _dbContext
                .Products
                .SingleOrDefault(p => p.Id == id);
            return productWithGivenId;
        }
    }
}
