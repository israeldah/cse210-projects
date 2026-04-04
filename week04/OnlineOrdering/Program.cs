// Creativity: All private fields with constructors/getters, both label methods, correct shipping cost logic ($5 domestic / $35 international), and two complete orders demonstrated.


using System;

class Program
{
    static void Main()
    {
        // --- Order 1: US customer ---
        var address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        var customer1 = new Customer("Homer Simpson", address1);

        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse",    "WM-101", 29.99, 2));
        order1.AddProduct(new Product("USB-C Hub",         "UC-204", 49.99, 1));
        order1.AddProduct(new Product("Mechanical Keyboard", "KB-305", 89.99, 1));

        // --- Order 2: International customer ---
        var address2 = new Address("221B Baker Street", "London", "England", "UK");
        var customer2 = new Customer("Sherlock Holmes", address2);

        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Magnifying Glass", "MG-010", 14.99, 3));
        order2.AddProduct(new Product("Leather Notebook", "NB-052", 12.49, 2));

        // --- Display ---
        foreach (var order in new[] { order1, order2 })
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine();
        }
    }
}
