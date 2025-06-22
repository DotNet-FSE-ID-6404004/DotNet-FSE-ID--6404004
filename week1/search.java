import java.util.Arrays;
import java.util.Comparator;

public class search {

    static class Product {
        int id;
        String name;
        String category;

        public Product(int id, String name, String category) {
            this.id = id;
            this.name = name;
            this.category = category;
        }

        public String toString() {
            return id + " - " + name + " [" + category + "]";
        }
    }

    public static Product linearSearch(Product[] productList, String targetName) {
        for (Product product : productList) {
            if (product.name.equalsIgnoreCase(targetName)) {
                return product;
            }
        }
        return null;
    }

    public static Product binarySearch(Product[] productList, String targetName) {
        int low = 0;
        int high = productList.length - 1;

        while (low <= high) {
            int mid = (low + high) / 2;
            int cmp = productList[mid].name.compareToIgnoreCase(targetName);

            if (cmp == 0) {
                return productList[mid];
            } else if (cmp < 0) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }

        return null;
    }

    public static void main(String[] args) {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Shoes", "Footwear"),
            new Product(103, "Phone", "Electronics"),
            new Product(104, "Book", "Education")
        };

        System.out.println("=== Linear Search ===");
        Product result1 = linearSearch(products, "Phone");
        if (result1 != null) {
            System.out.println("Found: " + result1);
        } else {
            System.out.println("Product not found.");
        }

        Arrays.sort(products, Comparator.comparing(p -> p.name));

        System.out.println("\n=== Binary Search ===");
        Product result2 = binarySearch(products, "Phone");
        if (result2 != null) {
            System.out.println("Found: " + result2);
        } else {
            System.out.println("Product not found.");
        }

        System.out.println("\n=== Time Complexity Notes ===");
        System.out.println("Linear Search: O(n)");
        System.out.println("Binary Search: O(log n) — requires sorted array");
    }
}
