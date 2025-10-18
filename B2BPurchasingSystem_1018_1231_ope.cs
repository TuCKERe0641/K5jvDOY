// 代码生成时间: 2025-10-18 12:31:06
using System;
using System.Collections.Generic;
using System.Linq;

// Define a class to represent a product.
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

// Define a class to represent a supplier.
public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }

    public Supplier(int id, string name)
    {
        Id = id;
        Name = name;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
}

// Define a class to represent a purchase order.
public class PurchaseOrder
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public Supplier Supplier { get; set; }
    public decimal TotalCost { get; set; }

    public PurchaseOrder(int id, Supplier supplier)
    {
        Id = id;
        Supplier = supplier;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        TotalCost += product.Price;
    }
}

public class B2BPurchasingSystem
{
    private List<Supplier> suppliers;
    private List<PurchaseOrder> purchaseOrders;

    public B2BPurchasingSystem()
    {
        suppliers = new List<Supplier>();
        purchaseOrders = new List<PurchaseOrder>();
    }

    // Add a new supplier to the system.
    public void AddSupplier(Supplier supplier)
    {
        suppliers.Add(supplier);
    }

    // Add a new purchase order.
    public void AddPurchaseOrder(PurchaseOrder order)
    {
        purchaseOrders.Add(order);
    }

    // Get all purchase orders for a specific supplier.
    public List<PurchaseOrder> GetPurchaseOrdersForSupplier(int supplierId)
    {
        return purchaseOrders.Where(po => po.Supplier.Id == supplierId).ToList();
    }

    // Process a purchase order.
    public void ProcessPurchaseOrder(PurchaseOrder order)
    {
        try
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            if (!suppliers.Any(s => s.Id == order.Supplier.Id))
                throw new InvalidOperationException("The supplier does not exist.");

            if (order.Products == null || order.Products.Count == 0)
                throw new InvalidOperationException("The purchase order contains no products.");

            // Logic to process the purchase order goes here.
            Console.WriteLine("Purchase order processed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing purchase order: {ex.Message}");
        }
    }
}

// Example usage:
class Program
{
    static void Main(string[] args)
    {
        B2BPurchasingSystem system = new B2BPurchasingSystem();

        // Create suppliers and products.
        Supplier supplier1 = new Supplier(1, "Supplier A");
        supplier1.AddProduct(new Product(1, "Product 1", 10m));
        supplier1.AddProduct(new Product(2, "Product 2", 20m));

        // Add suppliers to the system.
        system.AddSupplier(supplier1);

        // Create purchase orders.
        PurchaseOrder order1 = new PurchaseOrder(1, supplier1);
        order1.AddProduct(new Product(1, "Product 1", 10m));
        order1.AddProduct(new Product(2, "Product 2", 20m));

        // Add purchase orders to the system.
        system.AddPurchaseOrder(order1);

        // Process a purchase order.
        system.ProcessPurchaseOrder(order1);
    }
}
