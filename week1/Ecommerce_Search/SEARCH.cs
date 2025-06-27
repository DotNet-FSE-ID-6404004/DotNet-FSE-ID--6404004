using System;
using System.Linq;

public class SEARCH
{
    public class Product
    {
        public int productId { get; }
        public string productName { get; }
        public string category { get; }

        public Product(int id, string name, string cat)
        {
            productId = id;
            productName = name;
            category = cat;
        }

        public override string ToString() => $"{productId} - {productName} [{category}]";
    }

    public static Product? LinearSearch(Product[] products, string target)
    {
        foreach (var p in products)
        {
            if (string.Equals(p.productName, target, StringComparison.OrdinalIgnoreCase))
                return p;
        }
        return null;
    }

    public static Product? BinarySearch(Product[] products, string target)
    {
        int low = 0, high = products.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int cmp = string.Compare(products[mid].productName, target, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0)
                return products[mid];
            else if (cmp < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return null;
    }

    public static void Main()
    {
        var products = new Product[]
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Shoes", "Footwear"),
            new Product(103, "Phone", "Electronics"),
            new Product(104, "Book", "Education")
        };

        Console.WriteLine("=== Linear Search ===");
        var res1 = LinearSearch(products, "Shoes");

        Console.WriteLine(res1 != null ? $"Found: {res1}" : "Product not found");

        products = products.OrderBy(p => p.productName, StringComparer.OrdinalIgnoreCase).ToArray();

        Console.WriteLine("\n=== Binary Search ===");
        var res2 = BinarySearch(products, "Phone");


        Console.WriteLine(res2 != null ? $"Found: {res2}" : "Product not found");

        Console.WriteLine("\n=== Time Complexity Notes ===");
        Console.WriteLine("Linear Search: O(n)");
        Console.WriteLine("Binary Search: O(log n) — requires sorted array");
    }
}
