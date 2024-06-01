using System;

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order("Customer1");
        order.AddProduct(new Product("Product1", 1, 100, 2));
        order.AddProduct(new Product("Product2", 2, 150, 1));

        int totalCost = order.GetTotalCost();
        Console.WriteLine($"Total Cost: {totalCost}");
    }
}