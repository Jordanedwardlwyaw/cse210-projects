public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
    {
        Name = name;
        Description = description;
        Points = points;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        GoalManager.AddPoints(Points);
        Console.WriteLine($"You earned {Points} points!");

        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Bonus! You earned {_bonus} points!");
            GoalManager.AddPoints(_bonus);
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetails()
    {
        string mark = IsComplete() ? "X" : " ";
        return $"[{mark}] {Name} ({Description}) -- Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}
