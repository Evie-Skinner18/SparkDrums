using SparkDrums.Data.Models;
using System.Collections.Generic;


namespace SparkDrums.Data.Readers.Products
{
    public interface IProductsReader
    {
        IEnumerable<Product> GetAllProductsFromDb();

        Product GetProductFromDbById(int id);
    }
}
