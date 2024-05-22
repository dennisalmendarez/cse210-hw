using System;

public class Activity {
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(){
        _name = "";
        _description = "";
        _duration = 0;
    }
    
    public void DisplayStartingMessage(){
    Console.WriteLine($"Starting {_name}");
    Console.WriteLine(_description);

    int input;
    bool validInput = false;

    do {
        Console.WriteLine("How long do you want your session to last in seconds?");
        string userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out input)) {
            Console.WriteLine("Invalid input. Please enter a number.");
        } else {
            validInput = true;
        }
    } while (!validInput);
        
        _duration = input;

        ShowSpiner(3);
    }

    public void DisplayEndingMessage(){
        Console.WriteLine($"Ending {_name}");
        ShowSpiner(3);
    }

    public void ShowSpiner(int seconds){

        string a = "\\";

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinnerChars = {"|", "/", "-", $"{a}","|"};
        int counter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[counter % spinnerChars.Length]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            counter++;
        }
    }
    
    public void ShowCountDown(int seconds){
        
        for (int i= seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}