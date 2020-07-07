using SparkDrums.Data.Models.Products;

namespace SparkDrums.Data.Writers.Products
{
    public interface IProductsWriter
    {
        void AddProductToDb(Product productToAdd);

        void DeleteProductFromDb(Product productToDelete);

        void AddArchiveRecordToDb(Product product);
    }
}
