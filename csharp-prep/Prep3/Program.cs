using System;

class Program
{
    static void Main(string[] args)
    {
        while (true) //this stament helps repeat the loop after user promts yes to play again.
        {
            int count = 0;
            Console.WriteLine("What is your magic number?");
            string userinput = Console.ReadLine();
            
            int usernumber; // Works with line 16
            // Validate if user input is an integer
            while (!int.TryParse(userinput, out usernumber)) // Makes sure user enter an int
            {
                Console.WriteLine("Wrong entry. Please use a number.");
                Console.WriteLine("What is your magic number?");
                userinput = Console.ReadLine();
            }

            Random randomGenerator = new Random(); //Genereates a random number
            int number = randomGenerator.Next(1, 100);
            
            while (usernumber != number)
            {   count++; // Counts the numbers of time users plays until guess right
                if (usernumber < number)
                {
                    Console.WriteLine("Higher.");
                    Console.WriteLine("What is your magic number?");
                }

                else // Use if inside an else if only two condtion are need it in C# else if not work unless you add another else.
                    if (usernumber > number)
                {
                    Console.WriteLine("Lower.");
                    Console.WriteLine("What is your magic number?");
                } 
                userinput = Console.ReadLine();
                while (!int.TryParse(userinput, out usernumber))
                {
                    Console.WriteLine("Wrong entry. Please use a number.");
                    Console.WriteLine("What is your magic number?");
                    userinput = Console.ReadLine();
                }
            }
            Console.WriteLine($"You have guessed it! it took you: {count} times to guess it.");
            Console.WriteLine();
            Console.WriteLine("Do you like to play againg? YES/NO");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain != "YES")
            {
                break;
            }
            Console.Clear();
        }
    }
}