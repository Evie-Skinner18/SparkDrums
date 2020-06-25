using SparkDrums.Data.Models;
using System.Collections.Generic;

namespace SparkDrums.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        void CreateProduct(Product productToAdd);

        void DeleteProduct(int id);
    }
}
