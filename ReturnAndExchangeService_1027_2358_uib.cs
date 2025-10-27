// 代码生成时间: 2025-10-27 23:58:47
using System;
using System.Collections.Generic;

namespace ReturnAndExchangeApp
{
    // Represents a product that can be returned or exchanged.
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    // Handles the logic for processing returns and exchanges.
    public class ReturnAndExchangeService
    {
        private readonly IProductRepository _productRepository;

        // Constructor injection for dependency
        public ReturnAndExchangeService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        // Processes a return request for a product.
        public bool ProcessReturn(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ArgumentException("Product ID cannot be null or empty.", nameof(productId));
            }

            var product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                // Log error and return false if product is not found.
                Console.WriteLine($"Product with ID {productId} not found.");
                return false;
            }

            // Here you would add the logic to handle the actual return process,
            // such as updating inventory, refunding payment, etc.

            // For demonstration, we'll just log the return and return true.
            Console.WriteLine($"Product {product.Name} returned successfully.");
            return true;
        }

        // Processes an exchange request for a product.
        public bool ProcessExchange(string currentProductId, string newProductId)
        {
            if (string.IsNullOrEmpty(currentProductId) || string.IsNullOrEmpty(newProductId))
            {
                throw new ArgumentException("Both product IDs must be provided.", nameof(currentProductId));
            }

            var currentProduct = _productRepository.GetProductById(currentProductId);
            var newProduct = _productRepository.GetProductById(newProductId);

            if (currentProduct == null || newProduct == null)
            {
                // Log error and return false if either product is not found.
                Console.WriteLine($"One or both products not found. Current: {currentProductId}, New: {newProductId}");
                return false;
            }

            // Here you would add the logic to handle the actual exchange process,
            // such as updating inventory, handling price differences, etc.

            // For demonstration, we'll just log the exchange and return true.
            Console.WriteLine($"Product {currentProduct.Name} exchanged for {newProduct.Name} successfully.");
            return true;
        }
    }

    // Interface for product repository to support dependency inversion and testing.
    public interface IProductRepository
    {
        Product GetProductById(string id);
    }

    // Example implementation of the product repository.
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<string, Product> _products;

        public ProductRepository()
        {
            _products = new Dictionary<string, Product>();
            // Initialize with some products for demonstration.
            _products.Add("1", new Product { Id = "1", Name = "Laptop", Price = 1000.00 });
            _products.Add("2", new Product { Id = "2", Name = "Smartphone", Price = 500.00 });
        }

        public Product GetProductById(string id)
        {
            if (_products.TryGetValue(id, out var product))
            {
                return product;
            }
            return null;
        }
    }

    // Program class to run the application.
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var returnAndExchangeService = new ReturnAndExchangeService(productRepository);

            // Process a return request.
            var returnSuccess = returnAndExchangeService.ProcessReturn("1");
            Console.WriteLine($"Return success: {returnSuccess}");

            // Process an exchange request.
            var exchangeSuccess = returnAndExchangeService.ProcessExchange("1", "2");
            Console.WriteLine($"Exchange success: {exchangeSuccess}");
        }
    }
}