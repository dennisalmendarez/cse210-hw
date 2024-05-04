using System;
using System.Collections.Generic;
using System.IO;

public class Entry {
    public string _response;
    public string _prompt;
    public string _date;
    public Entry(string prompt) {
        _prompt = prompt;
        _date = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void Display() {
        Console.WriteLine("Date: " + _date);
        Console.WriteLine("Prompt: " + _prompt);
        Console.WriteLine("Response: " + _response);
        Console.WriteLine("");
    }
}