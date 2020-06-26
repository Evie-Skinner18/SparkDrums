using EntityProducts = SparkDrums.Data.Models.Products;
using ServiceProducts = SparkDrums.Services.Models.Products;

namespace SparkDrums.Services.Serialisation
{
    // would it be worth moving this mapping logic to the models themselves? Otherwise rn there is a third dependency in ProductsService
    public static class ProductMapper
    {
        // in goes an entity model and out comes a service model
        public static ServiceProducts.Product SerialiseProduct(EntityProducts.Product entityProduct)
        {
            var serviceProduct = new ServiceProducts.Product()
            {
                Id = entityProduct.Id,
                Name = entityProduct.Name,
                Description = entityProduct.Description,
                Category = entityProduct.Category,
                Price = entityProduct.Price,
                IsOnSale = entityProduct.IsOnSale,
                IsArchived = entityProduct.IsArchived,
                IsTaxable = entityProduct.IsTaxable,
                CreatedOn = entityProduct.CreatedOn,
                UpdatedOn = entityProduct.UpdatedOn
            };

            return serviceProduct;
        }

        // in comes a service model and out goes an entity model
        public static EntityProducts.Product SerialiseProduct(ServiceProducts.Product serviceProduct)
        {
            var entityProduct = new EntityProducts.Product()
            {
                Id = serviceProduct.Id,
                Name = serviceProduct.Name,
                Description = serviceProduct.Description,
                Category = serviceProduct.Category,
                Price = serviceProduct.Price,
                IsOnSale = serviceProduct.IsOnSale,
                IsArchived = serviceProduct.IsArchived,
                IsTaxable = serviceProduct.IsTaxable,
                CreatedOn = serviceProduct.CreatedOn,
                UpdatedOn = serviceProduct.UpdatedOn
            };

            return entityProduct;
        }
    }
}
