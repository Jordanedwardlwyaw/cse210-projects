namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal() : base() { }

        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            return Points; // Eternal goals never complete but always award points
        }

        public override string GetStatus()
        {
            return "[∞]"; // Infinity symbol for eternal goals
        }
    }
}
