// 代码生成时间: 2025-10-06 03:55:23
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSearchEngine
{
    /// <summary>
    /// Represents a product that can be searched.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    /// <summary>
    /// The product search engine that allows searching products by name.
    /// </summary>
    public class ProductSearchEngine
    {
        private List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the ProductSearchEngine class.
        /// </summary>
        /// <param name="products">The list of products to search through.</param>
        public ProductSearchEngine(List<Product> products)
        {
            _products = products ?? throw new ArgumentNullException(nameof(products));
        }

        /// <summary>
        /// Searches for products by name.
        /// </summary>
        /// <param name="searchTerm">The term to search for in product names.</param>
        /// <returns>A list of products that match the search term.</returns>
        public List<Product> SearchProductsByName(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ArgumentException("Search term cannot be null or whitespace.", nameof(searchTerm));
            }

            return _products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

    /// <summary>
    /// A sample class to demonstrate the usage of ProductSearchEngine.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // Sample data for demonstration
                var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Laptop", Description = "A high-performance laptop", Price = 999.99m },
                    new Product { Id = 2, Name = "Smartphone", Description = "A powerful smartphone", Price = 699.99m },
                    new Product { Id = 3, Name = "Tablet", Description = "A versatile tablet", Price = 499.99m }
                };

                // Create an instance of the ProductSearchEngine
                var searchEngine = new ProductSearchEngine(products);

                // Search for products containing the term "Smart"
                var results = searchEngine.SearchProductsByName("Smart");

                // Display the results
                foreach (var product in results)
                {
                    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
