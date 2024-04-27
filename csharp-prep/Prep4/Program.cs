using System.Collections;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            Console.WriteLine("Enter Numbers:");
            string userinput = Console.ReadLine();
            
            if (userinput == "0")
                break;
            // Validate if user input is an integer
            if (!int.TryParse(userinput, out int usernumbers)) // Makes sure user enter an int
            {
                Console.WriteLine("Wrong entry. Please use a number.");
                continue;
            }

            numbers.Add(usernumbers);
        }
        int total = numbers.Sum();
        double avarage = numbers.Average();
        int maxnumber = numbers.Max();
        int minnumber = numbers.Min();
        int minpositivenum = numbers.Where(n => n > 0).Min(); // remenber to use lambda.
        Console.WriteLine("Numbers sorted:");
        numbers.Sort();
        foreach (int number in numbers)
            {
                Console.WriteLine(number);   
            }
        Console.WriteLine($"The total sum of the list is: {total}");
        Console.WriteLine($"The avarage number is: {avarage}");
        Console.WriteLine($"The max number is: {maxnumber}");
        Console.WriteLine($"The min positive number is: {minpositivenum}");
    }
}