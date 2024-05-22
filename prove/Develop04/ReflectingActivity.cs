using System;

public class ReflectingActivity : Activity{

    private static Random _random = new Random();

    public static List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base (){
        _name = "Reflecting Activity.";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run(){
        DisplayStartingMessage();
        DisplayPrompt();
        ShowSpiner(5);

        Console.WriteLine("When you have Something in mind press enter to continue.");
        var userInput1 = Console.ReadLine();
        
        while (userInput1 == ""){

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                DisplayQuestion();
                ShowSpiner(5);
            }
            DisplayEndingMessage();
            Console.WriteLine();
            Console.WriteLine();
            break;
        }
    }

    public string GetRandomPromt(){
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion(){
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt(){
        Console.WriteLine(GetRandomPromt());
    }

    public void DisplayQuestion(){
        Console.WriteLine(GetRandomQuestion());
    }


}