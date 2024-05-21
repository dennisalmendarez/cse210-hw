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

    public ReflectingActivity(string name, string description, int duration) : base (name, description, duration){
    }

    public void Run(){
        DisplayStartingMessage();
        DisplayPrompt();
        ShowSpiner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShowSpiner(5);
        }

        DisplayEndingMessage();
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