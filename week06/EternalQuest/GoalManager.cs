using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> goals;
        public int TotalScore { get; private set; }

        public GoalManager()
        {
            goals = new List<Goal>();
            TotalScore = 0;
        }

        public void AddGoal(Goal goal)
        {
            goals.Add(goal);
        }

        public void ListGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals to show.");
                return;
            }

            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            Goal goal = goals[goalIndex];
            int pointsEarned = goal.RecordEvent();

            if (pointsEarned > 0)
            {
                TotalScore += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points! Total score: {TotalScore}");
            }
            else
            {
                Console.WriteLine("Goal already completed or no points earned.");
            }
        }

        public void Save(string filename)
        {
            var saveData = new SaveData
            {
                Score = TotalScore,
                Goals = goals
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new GoalJsonConverter() }
            };

            string json = JsonSerializer.Serialize(saveData, options);
            File.WriteAllText(filename, json);
            Console.WriteLine($"Goals saved to {filename}");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} does not exist.");
                return;
            }

            string json = File.ReadAllText(filename);

            var options = new JsonSerializerOptions
            {
                Converters = { new GoalJsonConverter() }
            };

            try
            {
                SaveData loaded = JsonSerializer.Deserialize<SaveData>(json, options);
                TotalScore = loaded.Score;
                goals = loaded.Goals ?? new List<Goal>();
                Console.WriteLine($"Goals loaded from {filename}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load goals: " + e.Message);
            }
        }

        private class SaveData
        {
            public int Score { get; set; }
            public List<Goal> Goals { get; set; }
        }
    }
}
