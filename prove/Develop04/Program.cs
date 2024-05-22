using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1) Start breathing activity");
            Console.WriteLine("2) Start reflecting activity");
            Console.WriteLine("3) Start listing activity");
            Console.WriteLine("4) Exit");

            string userInput = Console.ReadLine();
            int input;
            if (!int.TryParse(userInput, out input))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                continue;
            }

            switch (input)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();

                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;

                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}