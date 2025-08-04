public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"You earned {Points} points!");
        GoalManager.AddPoints(Points);
    }

    public override bool IsComplete() => false;

    public override string GetDetails() => $"[ ] {Name} ({Description})";

    public override string GetStringRepresentation() => $"EternalGoal|{Name}|{Description}|{Points}";
}
