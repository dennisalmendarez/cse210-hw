using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade?");
        string userinput = Console.ReadLine();
        int number = int.Parse(userinput);
        int grade = number % 10;
        string minussing = "-";
        string plussing = "+";
        if (number >= 90)
            {   if (grade <= 3)
                    Console.WriteLine($"Your grade is A{minussing}");
                else
                    Console.WriteLine("Your grade is A");
            }
        else if (number >= 80)
            {
                if (grade <= 3)
                    Console.WriteLine($"Your grade is B{minussing}");
                else if (grade >= 7)
                    Console.WriteLine($"Your grade is B{plussing}");
                else
                    Console.WriteLine("Your grade is B");
            }
        else if (number >= 70)
            {
                if (grade <= 3)
                    Console.WriteLine($"Your grade is C{minussing}");
                else if (grade >= 7)
                    Console.WriteLine($"Your grade is C{plussing}");
                else
                    Console.WriteLine("Your grade is C");
            }
        else if (number >= 60)
            {
                if (grade <= 3)
                    Console.WriteLine($"Your grade is D{minussing}");
                else if (grade >= 7)
                    Console.WriteLine($"Your grade is D{plussing}");
                else
                    Console.WriteLine("Your grade is D");;
            }
        else
            {
                Console.WriteLine("Your grade is F");
            }
    }
}