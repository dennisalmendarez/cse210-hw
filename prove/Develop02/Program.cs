using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator random = new PromptGenerator(); // Corrected typo

        while (true)
        {
            Console.WriteLine("1) Write");
            Console.WriteLine("2) Display Journal");
            Console.WriteLine("3) Load");
            Console.WriteLine("4) Save");
            Console.WriteLine("5) Exit");

            string userInput = Console.ReadLine();
            int input = int.Parse(userInput);

            switch (input)
            {
                case 1:
                    string randomPrompt = PromptGenerator.GetRandomPrompt();
                    Entry newEntry = new Entry(randomPrompt);
                    Console.WriteLine(randomPrompt);
                    newEntry._response = Console.ReadLine();
                    theJournal.AddEntry(newEntry);
                    break;
                case 2:
                    theJournal.DisplayAll();
                    break;
                case 3:
                    Console.WriteLine("Enter the file name to load:");
                    string loadFileName = Console.ReadLine();
                    theJournal.LoadFromFile(loadFileName);
                    break;
                case 4:
                    Console.WriteLine("Enter the file name to save:");
                    string saveFileName = Console.ReadLine();
                    theJournal.SaveToFile(saveFileName);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
}