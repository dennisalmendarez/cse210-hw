using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    protected int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine();

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");

            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    CreateGoal();
                    Console.WriteLine();
                    break;
                case "2":
                    ListGoalDetails();
                    Console.WriteLine();
                    break;
                case "3":
                    SaveGoals();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Write("Enter filename to load goals: ");
                    string filename = Console.ReadLine();
                    LoadGoals(filename);
                    Console.WriteLine();
                    break;
                case "5":
                    RecordEvent();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your Score is: {_score}");
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter the type of goal (Simple, Eternal, Checklist):");
        string type = Console.ReadLine();

        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the description of the goal:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the points for the goal:");
        string points = Console.ReadLine();

        Goal goal = null;

        switch (type.ToLower())
        {
            case "simple":
                goal = new SimpleGoal(name, description, points);
                break;
            case "eternal":
                goal = new EternalGoal(name, description, points);
                break;
            case "checklist":
                Console.WriteLine("Enter the target number of times to complete the goal:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the bonus points for completing the checklist goal:");
                string bonus = Console.ReadLine();
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {

        Console.WriteLine("Select the number of the goal to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.WriteLine("Enter the number of the goal to record an event:");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            _goals[goalNumber].RecordEvent(ref _score);
            Console.WriteLine("Event recorded successfully.");

            ListGoalDetails();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("Enter filename to save goals:");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());
            _goals.Clear();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(':');
                var goalType = parts[0];
                var goalData = parts[1].Split(',');

                Goal goal = null;

                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(goalData[0], goalData[1], goalData[2]);
                        ((SimpleGoal)goal).SetCompletion(bool.Parse(goalData[3]));
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(goalData[0], goalData[1], goalData[2]);
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(goalData[0], goalData[1], goalData[2], int.Parse(goalData[3]), goalData[4]);
                        ((ChecklistGoal)goal).SetAmountCompleted(int.Parse(goalData[5]));
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}