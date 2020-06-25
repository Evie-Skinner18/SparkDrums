using SparkDrums.Data.Models;
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

        public IEnumerable<Product> GetAllProducts()
        {
            var allProducts = _productsReader.GetAllProductsFromDb();
            return allProducts;
        }

        public Product GetProductById(int id)
        {
            var productWithGivenId = _productsReader.GetProductFromDbById(id);
            return productWithGivenId;
        }

        public void CreateProduct(Product productToAdd)
        {
            _productsWriter.AddProductToDb(productToAdd);
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _productsReader.GetProductFromDbById(id);
            _productsWriter.DeleteProductFromDb(productToDelete);
        }
    }
}
