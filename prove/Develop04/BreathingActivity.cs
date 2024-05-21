using System;
using System.Security.Cryptography.X509Certificates;

public class BreathingActivity : Activity{

    public BreathingActivity(string name, string description, int duration) : base(name, description, duration){
        _name = name;
        _description = description;
    }

    public void Run() {
        Console.WriteLine("_________________________________________________"); //spacing
        Console.WriteLine(); //spacing
        DisplayStartingMessage();
        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(_duration);
        Console.WriteLine(); //spacing
        
        do {//Repeat this for the duration (loop)
            Console.Write("Breathe in ... "); //Have the user breathe in for 5 seconds
            ShowCountDown(3);
            ShowSpiner(3);
            Console.WriteLine();
            Console.Write("Breathe out ...  "); //Have the user breathe out for 5 seconds
            ShowCountDown(3);
            ShowSpiner(3);
            Console.WriteLine();//spacing
            Console.WriteLine();//spacing
        }
        while (DateTime.Now < stopTime);
        Console.WriteLine();//spacing
        
        DisplayEndingMessage();
    }
}