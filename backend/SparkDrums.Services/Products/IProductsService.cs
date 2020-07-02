using ServiceProducts = SparkDrums.Services.Models.Products;
using System.Collections.Generic;

namespace SparkDrums.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<ServiceProducts.Product> GetAllProducts();

        ServiceProducts.Product GetProductById(int id);

        ServiceResponse<ServiceProducts.Product> CreateProduct(ServiceProducts.Product productToAdd);

        ServiceResponse<ServiceProducts.Product> DeleteProduct(int id);

        ServiceResponse<ServiceProducts.Product> ArchiveProduct(int id);

        void CreateProductInventoryRecord(ServiceProducts.Product product);
    }
}
