using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Running Activity:");
        Running running = new Running("12/22/2024", 30, 3.0);
        Console.WriteLine(running.GetSummary());
        Console.WriteLine();

        Console.WriteLine("Cycling Activity");
        Cycling cycling = new Cycling("05/24/2024", 40, 15.5);
        Console.WriteLine(cycling.GetSummary());
        Console.WriteLine();

        Console.WriteLine("Swimming Activity");
        Swimming swimming = new Swimming("02/07/2024", 10, 5);
        Console.WriteLine(swimming.GetSummary());

        Console.WriteLine();

    }
}