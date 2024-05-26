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

            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");

            Console.WriteLine();
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayPlayerInfo();
                    Console.WriteLine();
                    break;
                case "2":
                    ListGoalNames();
                    Console.WriteLine();
                    break;
                case "3":
                    ListGoalDetails();
                    Console.WriteLine();
                    break;
                case "4":
                    CreateGoal();
                    Console.WriteLine();
                    break;
                case "5":
                    RecordEvent();
                    Console.WriteLine();
                    break;
                case "6":
                    SaveGoals();
                    Console.WriteLine();
                    break;
                case "7":
                    Console.Write("Enter filename to load goals: ");
                    string filename = Console.ReadLine();
                    LoadGoals(filename);
                    Console.WriteLine();
                    break;
                case "8":
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

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
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
        Console.WriteLine("Enter the type of goal 1)Simple, 2)Eternal, 3)Checklist:");
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
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
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
        Console.WriteLine("Enter the number of the goal to record an event:");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            _goals[goalNumber].RecordEvent(ref _score);
            Console.WriteLine("Event recorded successfully.");
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

    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected string _points;

        public Goal(string name, string description, string points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public abstract void RecordEvent(ref int score);
        public abstract bool IsComplete();
        public virtual string GetDetailsString()
        {
            return $"{_shortName}: {_description}";
        }
        public abstract string GetStringRepresentation();

        protected int GetPoints()
        {
            return int.TryParse(_points, out int points) ? points : 0;
        }
    }

    public class SimpleGoal : Goal
    {
        protected bool _isComplete;

        public SimpleGoal(string name, string description, string points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override void RecordEvent(ref int score)
        {
            _isComplete = true;
            score += GetPoints();
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }

        public void SetCompletion(bool isComplete)
        {
            _isComplete = isComplete;
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, string points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent(ref int score)
        {
            score += GetPoints();
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_shortName},{_description},{_points}";
        }
    }

    public class ChecklistGoal : Goal
    {
        protected int _amountCompleted;
        protected int _target;
        protected string _bonus;

        public ChecklistGoal(string shortName, string description, string points, int target, string bonus)
            : base(shortName, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public override void RecordEvent(ref int score)
        {
            _amountCompleted++;
            score += GetPoints();
            if (_amountCompleted >= _target)
            {
                score += int.Parse(_bonus);
                _amountCompleted = 0; // reset for next cycle if needed
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName}: {_description} - Completed {_amountCompleted}/{_target} times";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
        }

        public void SetAmountCompleted(int amountCompleted)
        {
            _amountCompleted = amountCompleted;
        }
    }
}

// Entry point
public class Program
{
    public static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
