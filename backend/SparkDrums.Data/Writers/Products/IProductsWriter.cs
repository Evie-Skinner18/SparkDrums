using SparkDrums.Data.Models;


namespace SparkDrums.Data.Writers.Products
{
    public interface IProductsWriter
    {
        void AddProductToDb(Product productToAdd);

        void DeleteProductFromDb(Product productToDelete);
    }
}
