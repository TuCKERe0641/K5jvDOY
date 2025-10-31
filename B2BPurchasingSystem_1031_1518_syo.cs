// 代码生成时间: 2025-10-31 15:18:57
// B2BPurchasingSystem.cs
// This is a simple B2B purchasing system implemented in C# using the .NET framework.

using System;
using System.Collections.Generic;
using System.Linq;

namespace B2BPurchasingSystem
{
    // Define a class to represent a Product
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

        public Product(int id, string name, decimal price, int quantityAvailable)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityAvailable = quantityAvailable;
        }
    }

    // Define a class to represent a Purchase Order
    public class PurchaseOrder
    {
        public List<Product> Products { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime OrderDate { get; private set; }

        public PurchaseOrder()
        {
            Products = new List<Product>();
            TotalCost = 0;
            OrderDate = DateTime.Now;
        }

        public void AddProduct(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (product.QuantityAvailable < quantity)
                throw new InvalidOperationException("Not enough stock available for the product.");

            Products.Add(product);
            TotalCost += product.Price * quantity;
        }

        public void ProcessOrder()
        {
            // Process the order logic here
            // For example, you can update inventory, validate payment, etc.
            Console.WriteLine($"Order placed on {OrderDate} with a total cost of ${TotalCost:C2}.");
        }
    }

    // Main Program Class
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a list of products
                List<Product> products = new List<Product>
                {
                    new Product(1, "Laptop", 1000, 10),
                    new Product(2, "Smartphone", 500, 20),
                    new Product(3, "Tablet", 300, 30)
                };

                // Create a new purchase order
                PurchaseOrder order = new PurchaseOrder();

                // Add products to the order
                order.AddProduct(products[0], 2); // Adding 2 laptops
                order.AddProduct(products[1], 3); // Adding 3 smartphones

                // Process the order
                order.ProcessOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
