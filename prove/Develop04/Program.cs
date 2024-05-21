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

                    var name = "Breathing Activity.";
                    Console.WriteLine(name);
                    Console.WriteLine();
                    var description = "The activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing.";
                    Console.WriteLine(description);
                    Console.WriteLine();
                    Console.WriteLine("How long do you want your sesion last in seconds?");

                    Console.WriteLine("How long will you sesion last in seconds?");


                    string userInput2 = Console.ReadLine();
                    int input2;
                    if (!int.TryParse(userInput2, out input2)) {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    
                    var duration = input2;

                    BreathingActivity breathingActivity = new BreathingActivity(name, description, duration);
                    breathingActivity.Run();

                    break;
                case 2:

                    name = "Reflecting Activity.";
                    Console.WriteLine(name);
                    Console.WriteLine();
                    description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
                    Console.WriteLine(description);
                    Console.WriteLine();
                    Console.WriteLine("How long do you want your sesion last in seconds?");

                    string userInput3 = Console.ReadLine();
                    int input3;
                    if (!int.TryParse(userInput3, out input3)) {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    duration = input3;
                    ReflectingActivity reflectingActivity = new ReflectingActivity(name, description, duration);
                    reflectingActivity.Run();
                    break;

                case 3:

                    name = "Listing Activity.";
                    Console.WriteLine(name);
                    Console.WriteLine();
                    description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";                    Console.WriteLine();
                    Console.WriteLine(description);
                    Console.WriteLine();
                    Console.WriteLine("How long do you want your sesion last in seconds?");

                    string userInput4 = Console.ReadLine();
                    int input4;
                    if (!int.TryParse(userInput4, out input4)) {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    Console.WriteLine();
                    duration = input4;
                    Console.WriteLine("list as many response you can to the following prompt");
                    ListingActivity listingActivity = new ListingActivity(name, description, duration);
                    listingActivity.Run();

                    Console.WriteLine();
                    Console.WriteLine("Well Done!");
                    Console.WriteLine();
                    Console.WriteLine($"You have complete another {duration} seconds of the Listing Activity");
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