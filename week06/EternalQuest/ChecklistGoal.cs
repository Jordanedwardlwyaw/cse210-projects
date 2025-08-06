namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; private set; }
        public int CurrentCount { get; set; }
        public int BonusPoints { get; private set; }

        public ChecklistGoal() : base() { }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
        }

        public override int RecordEvent()
        {
            if (_completed)
                return 0;

            CurrentCount++;
            int totalPoints = Points;

            if (CurrentCount >= TargetCount)
            {
                _completed = true;
                totalPoints += BonusPoints;
                System.Console.WriteLine($"Congrats! You earned a bonus of {BonusPoints} points!");
            }

            return totalPoints;
        }

        public override string GetStatus()
        {
            if (_completed)
                return "[X]";
            else
                return $"[ ] Completed {CurrentCount}/{TargetCount}";
        }

        public override string ToString()
        {
            return $"{GetStatus()} {Name} ({Description})";
        }
    }
}
