using System;

public class Activity {
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration){
        _name = name;
        _description = description;
        _duration = duration;
    }
    
    public void DisplayStartingMessage(){
        Console.WriteLine($"Starting {_name}");
        Console.WriteLine(_description);
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