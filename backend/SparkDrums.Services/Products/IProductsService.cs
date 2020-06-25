using EntityProducts = SparkDrums.Data.Models.Products;
//using ServiceModels = SparkDrums.Services.Models;
using System.Collections.Generic;

namespace SparkDrums.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<EntityProducts.Product> GetAllProducts();

        EntityProducts.Product GetProductById(int id);

        ServiceResponse<EntityProducts.Product> CreateProduct(EntityProducts.Product productToAdd);

        ServiceResponse<EntityProducts.Product> DeleteProduct(int id);

        ServiceResponse<EntityProducts.Product> ArchiveProduct(int id);

        void CreateProductInventoryRecord(EntityProducts.Product product);
    }
}
