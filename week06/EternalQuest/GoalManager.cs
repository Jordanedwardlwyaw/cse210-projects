using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private static int _score = 0;
    private static int _level = 1;
    private List<Goal> _goals = new();

    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = type switch
        {
            1 => new SimpleGoal(name, desc, points),
            2 => new EternalGoal(name, desc, points),
            3 => CreateChecklistGoal(name, desc, points),
            _ => null
        };

        if (goal != null) _goals.Add(goal);
    }

    private ChecklistGoal CreateChecklistGoal(string name, string desc, int points)
    {
        Console.Write("Target Count: ");
        int target = int.Parse(Console.ReadLine());

        Console.Write("Bonus Points: ");
        int bonus = int.Parse(Console.ReadLine());

        return new ChecklistGoal(name, desc, points, target, bonus);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void RecordEvent()
    {
        DisplayGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
        }
    }

    public void SaveGoals(string file)
    {
        using StreamWriter output = new(file);
        output.WriteLine($"{_score}|{_level}");

        foreach (Goal goal in _goals)
        {
            output.WriteLine(goal.GetStringRepresentation());
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(file);
        string[] scoreData = lines[0].Split('|');
        _score = int.Parse(scoreData[0]);
        _level = int.Parse(scoreData[1]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int pts = int.Parse(parts[3]);

            Goal goal = type switch
            {
                "SimpleGoal" => new SimpleGoal(name, desc, pts) { },
                "EternalGoal" => new EternalGoal(name, desc, pts),
                "ChecklistGoal" => new ChecklistGoal(name, desc, pts, int.Parse(parts[5]), int.Parse(parts[4])) { },
                _ => null
            };

            if (type == "SimpleGoal" && parts.Length > 4 && bool.Parse(parts[4]))
                ((SimpleGoal)goal).RecordEvent();
            else if (type == "ChecklistGoal")
                for (int j = 0; j < int.Parse(parts[6]); j++) ((ChecklistGoal)goal).RecordEvent();

            if (goal != null) _goals.Add(goal);
        }

        Console.WriteLine("Goals loaded!");
    }

    public void ShowScore()
    {
        Console.WriteLine($"Score: {_score}  |  Level: {_level}");
    }

    public static void AddPoints(int pts)
    {
        _score += pts;
        int newLevel = _score / 500 + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"🎉 Level up! You are now level {_level}! 🎉");
        }
    }
}
