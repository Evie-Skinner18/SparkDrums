using EntityProducts = SparkDrums.Data.Models.Products;
using SparkDrums.Data.Readers.Products;
using SparkDrums.Data.Writers.Products;
using System;
using System.Collections.Generic;

namespace SparkDrums.Services.Products
{
    public class ProductsService : IProductsService
    {

        private IProductsReader _productsReader { get; set; }

        private IProductsWriter _productsWriter { get; set; }


        public ProductsService(IProductsReader productsReader, IProductsWriter productsWriter)
        {
            _productsReader = productsReader;
            _productsWriter = productsWriter;
        }

        public IEnumerable<EntityProducts.Product> GetAllProducts()
        {
            var allProducts = _productsReader.GetAllProductsFromDb();
            return allProducts;
        }

        public EntityProducts.Product GetProductById(int id)
        {
            var productWithGivenId = _productsReader.GetProductFromDbById(id);
            return productWithGivenId;
        }

        public ServiceResponse<EntityProducts.Product> CreateProduct(EntityProducts.Product productToAdd)
        {
            var response = new ServiceResponse<EntityProducts.Product>()
            {
                Data = productToAdd,
                Time = DateTime.Now
            };
       
            try
            {
                CreateProductInventoryRecord(productToAdd);
                _productsWriter.AddProductToDb(productToAdd);

                response.IsSuccessful = true;
                response.Message = ($"Successfully added {productToAdd.Name}");
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = ($"Could not add {productToAdd.Name}");
            }

            return response;
        }

        public ServiceResponse<EntityProducts.Product> DeleteProduct(int id)
        {
            var response = new ServiceResponse<EntityProducts.Product>()
            {
                Time = DateTime.Now
            };

            try
            {
                var productToDelete = _productsReader.GetProductFromDbById(id);
                _productsWriter.DeleteProductFromDb(productToDelete);

                response.Data = productToDelete;
                response.IsSuccessful = true;
                response.Message = ($"Successfully deleted {productToDelete.Name}");
            }
            catch (Exception e)
            {
                response.IsSuccessful = false;
                response.Message = ($"Could not delete product {response.Data.Name}");
            }

            return response;
        }

        // to-do: implement this method
        public ServiceResponse<EntityProducts.Product> ArchiveProduct(int id)
        {
            _productsWriter.AddArchiveRecordToDb();

            throw new NotImplementedException();
        }

        public void CreateProductInventoryRecord(EntityProducts.Product product)
        {
            try
            {
                var productInventoryRecord = new EntityProducts.ProductInventory()
                {
                    Product = product,
                    QuantityAvailable = 0,
                    IdealQuantity = 10
                };
                _productsWriter.AddProductInventoryRecordToDb(productInventoryRecord);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add inventory record to a product that does not exist!");
            }
        }
    }
}
