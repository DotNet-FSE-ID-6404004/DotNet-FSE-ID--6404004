using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var context = new AppDbContext();

        Console.WriteLine("📦 Product List:");
        var products = await context.Products.Include(p => p.Category).ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"- {p.Name} | ₹{p.Price:0.00} | Category: {p.Category?.Name}");
        }

        Console.WriteLine("\n🔍 Find by ID (Product ID = 1):");
        var product = await context.Products.FindAsync(1);
        Console.WriteLine(product != null ? $"Found: {product.Name}" : "Product not found");

        Console.WriteLine("\n💰 First Expensive Product (Price > ₹50000):");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine(expensive != null ? $"Expensive: {expensive.Name}" : "No expensive product found");
    }
}
