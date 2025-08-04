public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"You earned {Points} points!");
        GoalManager.AddPoints(Points);
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetails() => $"[{"X",1}] {Name} ({Description})";

    public override string GetStringRepresentation() => $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
}
