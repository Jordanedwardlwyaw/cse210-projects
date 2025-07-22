using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product prod1 = new Product("Wireless Mouse", "WM123", 15.99, 2);
        Product prod2 = new Product("Mechanical Keyboard", "MK456", 89.99, 1);
        Product prod3 = new Product("USB-C Cable", "UC789", 9.99, 3);

        Product prod4 = new Product("Bluetooth Speaker", "BS321", 45.50, 1);
        Product prod5 = new Product("Webcam HD", "WC654", 70.00, 1);

        // Create customers with addresses
        Address addr1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer cust1 = new Customer("John Doe", addr1);

        Address addr2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Jane Smith", addr2);

        // Create orders and add products
        Order order1 = new Order(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);
        order1.AddProduct(prod3);

        Order order2 = new Order(cust2);
        order2.AddProduct(prod4);
        order2.AddProduct(prod5);

        // Display order 1 info
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");
        Console.WriteLine();

        // Display order 2 info
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}
