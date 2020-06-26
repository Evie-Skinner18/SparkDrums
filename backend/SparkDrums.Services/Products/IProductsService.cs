using EntityProducts = SparkDrums.Data.Models.Products;
using ServiceProducts = SparkDrums.Services.Models.Products;
using System.Collections.Generic;

namespace SparkDrums.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<ServiceProducts.Product> GetAllProducts();

        EntityProducts.Product GetProductById(int id);

        ServiceResponse<EntityProducts.Product> CreateProduct(EntityProducts.Product productToAdd);

        ServiceResponse<EntityProducts.Product> DeleteProduct(int id);

        ServiceResponse<EntityProducts.Product> ArchiveProduct(int id);

        void CreateProductInventoryRecord(EntityProducts.Product product);
    }
}
