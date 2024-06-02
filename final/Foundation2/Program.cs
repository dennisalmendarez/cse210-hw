using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("400 Michigan State Circle", "St. Cloud", "FL", "USA");
        Address address2 = new Address("21 Ave Plaza", "San Pedro Sula", "Cortes", "Honduras");
        Address address3 = new Address("10136 Robert Frost Dr", "Winter Garden", "FL", "USA");
        Address address4 = new Address("47 SE Este no 88", "Barranquilla", "Colombia", "Honduras");

        // Create customers
        Customer customer1 = new Customer("Janet Morad", address1);
        Customer customer2 = new Customer("Dennis Almendarez", address2);
        Customer customer3 = new Customer("Tina Trem", address3);
        Customer customer4 = new Customer("Juan Sebas", address4);

        // Create products
        Product product1 = new Product("Earplugs", "A1523", 3.5, 2);
        Product product2 = new Product("Keyboard", "B4856", 40.0, 1);
        Product product3 = new Product("Comic", "C7869", 7.5, 3);
        Product product4 = new Product("Spanish Book", "V1523", 4.3, 3);
        Product product5 = new Product("Statue", "P4456", 80.0, 1);
        Product product6 = new Product("Catfish Toy", "M7819", 3.5, 4);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        Order order3 = new Order(customer1);
        order3.AddProduct(product4);
        order3.AddProduct(product5);

        Order order4 = new Order(customer2);
        order4.AddProduct(product6);
        order4.AddProduct(product2);
        order4.AddProduct(product4);


        // Display order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Shipping cost: ${order1.GetShippingCost()}");
        Console.WriteLine($"Total cost: ${order1.CalculateTotalCost()}");
        Console.WriteLine("----------------------------------------------------------\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Shipping cost: ${order2.GetShippingCost()}");
        Console.WriteLine($"Total cost: ${order2.CalculateTotalCost()}");
        Console.WriteLine("----------------------------------------------------------\n");

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Shipping cost: ${order3.GetShippingCost()}");
        Console.WriteLine($"Total cost: ${order3.CalculateTotalCost()}");
        Console.WriteLine("----------------------------------------------------------\n");

        Console.WriteLine(order4.GetPackingLabel());
        Console.WriteLine(order4.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Shipping cost: ${order4.GetShippingCost()}");
        Console.WriteLine($"Total cost: ${order4.CalculateTotalCost()}");
        Console.WriteLine("----------------------------------------------------------\n");
    }
}