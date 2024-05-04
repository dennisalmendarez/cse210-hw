using System;
using System.Collections.Generic;
using System.IO;

public class PromptGenerator {
    private static Random _random = new Random();
    public static List<string> _prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the most memorable event of the day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public static string GetRandomPrompt(){
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}