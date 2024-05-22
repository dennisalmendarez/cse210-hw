using System;
using System.Text;

public class ListingActivity : Activity{

    private static Random _random = new Random();

    protected int _count;
    public static List<string> _prompts = new List<string>{"Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"};

    public ListingActivity() : base(){
        _name = "Listing Activity.";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    }   
    public void Run(){
        DisplayStartingMessage();

        GetRandomPrompt();

        List<string> userResponses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                userResponses.Add(response);
                _count++;
            }
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items:");
        foreach (var response in userResponses)
        {
            Console.WriteLine($"- {response}");
        }

        Console.WriteLine();
        Console.WriteLine("Well Done!");
        Console.WriteLine();
        Console.WriteLine($"You have complete another {_duration} seconds of the Listing Activity");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt(){
        var random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
    }

    public List<string> GetListFromUser(List<string> _promts){
     
     string promts = Console.ReadLine();

     _prompts.Add(promts);
     
     return _prompts;
    }
}