using EntityInventories = SparkDrums.Data.Models.Inventories;
using ServiceProducts = SparkDrums.Services.Models.Products;
using SparkDrums.Data.Readers.Products;
using SparkDrums.Data.Writers.Products;
using System;
using System.Collections.Generic;
using SparkDrums.Services.Serialisation;
using System.Linq;
using SparkDrums.Data.Writers.Inventories;

namespace SparkDrums.Services.Products
{
    public class ProductsService : IProductsService
    {

        private IProductsReader _productsReader { get; set; }

        private IProductsWriter _productsWriter { get; set; }

        private IInventoriesWriter _inventoriesWriter { get; set; }


        public ProductsService(IProductsReader productsReader, IProductsWriter productsWriter, IInventoriesWriter inventoriesWriter)
        {
            _productsReader = productsReader;
            _productsWriter = productsWriter;
            _inventoriesWriter = inventoriesWriter;
        }

        public IEnumerable<ServiceProducts.Product> GetAllProducts()
        {
            var entityProducts = _productsReader.GetAllProductsFromDb();
            var serviceProducts = entityProducts
                .Select(p => ProductMapper
                .SerialiseProduct(p));

            return serviceProducts;
        }

        public ServiceProducts.Product GetProductById(int id)
        {
            var entityProduct = _productsReader.GetProductFromDbById(id);
            var serviceProduct = ProductMapper.SerialiseProduct(entityProduct);
            return serviceProduct;
        }

        // these are quite repetitive. How can I improve? Uncle Bob would say separate your error handling from method's logic
        public ServiceResponse<ServiceProducts.Product> CreateProduct(ServiceProducts.Product productToAdd)
        {
            var now = DateTime.Now;
            var response = new ServiceResponse<ServiceProducts.Product>()
            {
                Time = now
            };
       
            try
            {
                var entityProduct = ProductMapper.SerialiseProduct(productToAdd);
                entityProduct.CreatedOn = now;
                entityProduct.UpdatedOn = now;
                _productsWriter.AddProductToDb(entityProduct);                
                CreateProductInventoryRecord(productToAdd);

                response.IsSuccessful = true;
                response.Message = ($"Successfully added {productToAdd.Name}");
                response.Data = ProductMapper.SerialiseProduct(entityProduct);
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = ($"Could not add {productToAdd.Name}. Stack trace: {e.StackTrace}");
                response.Data = productToAdd;
            }

            return response;
        }

        public ServiceResponse<ServiceProducts.Product> DeleteProduct(int id)
        {
            var response = new ServiceResponse<ServiceProducts.Product>()
            {
                Time = DateTime.Now
            };

            try
            {
                var entityProduct = _productsReader.GetProductFromDbById(id);
                _productsWriter.DeleteProductFromDb(entityProduct);
                var serviceProduct = ProductMapper.SerialiseProduct(entityProduct);

                response.Data = serviceProduct;
                response.IsSuccessful = true;
                response.Message = ($"Successfully deleted {serviceProduct.Name}");
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = ($"Could not delete product {response.Data.Name}. Stack trace: {e.StackTrace}");
            }

            return response;
        }

        public ServiceResponse<ServiceProducts.Product> ArchiveProduct(int id)
        {
            var response = new ServiceResponse<ServiceProducts.Product>()
            {
                Time = DateTime.Now
            };

            try
            {
                var entityProduct = _productsReader.GetProductFromDbById(id);
                _productsWriter.AddArchiveRecordToDb(entityProduct);
                var serviceProduct = ProductMapper.SerialiseProduct(entityProduct);

                response.Data = serviceProduct;
                response.IsSuccessful = true;
                response.Message = ($"Successfully archived {serviceProduct.Name}");
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = ($"Could not archive product {response.Data.Name}. Stack trace: {e.StackTrace}"); ;
            }

            return response; 
        }

        public void CreateProductInventoryRecord(ServiceProducts.Product product)
        {
            // there's no valid id we can use to retrieve by id, because it gets generated automatcially by DB when that product is added
            var entityProduct = _productsReader.GetMostRecentlyAddedProductFromDb();
            var now = DateTime.Now;

            try
            {
                var productInventoryRecord = new EntityInventories.ProductInventory()
                {
                    Product = entityProduct.Name == product.Name ? entityProduct : null,
                    QuantityAvailable = 0,
                    IdealQuantity = 15,
                    CreatedOn = now,
                    UpdatedOn = now
                };
                _inventoriesWriter.AddProductInventoryRecordToDb(productInventoryRecord);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Failed to add inventory record for product {product.Name}. Most recently added entity product retreived was {entityProduct.Name}");
            }
        }
    }
}
