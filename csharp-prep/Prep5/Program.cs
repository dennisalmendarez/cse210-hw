using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayResult();
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        string usernumber = Console.ReadLine();
        int number = int.Parse(usernumber);
        return number;
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please Enter your name");
        string username = Console.ReadLine();
        string name = username;
        return name;
    }

    static int SquareNumber()
    {
        int number = PromptUserNumber();
        int squared = number * number;
        return squared;
    }

    static void DisplayResult()
    {
        
        string name = PromptUserName();
        int number = SquareNumber();
        
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}