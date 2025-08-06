using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EternalQuest
{
    public class GoalJsonConverter : JsonConverter<Goal>
    {
        public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var jsonObject = jsonDoc.RootElement;

            string type = jsonObject.GetProperty("Type").GetString();

            string name = jsonObject.GetProperty("Name").GetString();
            string description = jsonObject.GetProperty("Description").GetString();
            int points = jsonObject.GetProperty("Points").GetInt32();
            bool completed = jsonObject.GetProperty("_completed").GetBoolean();

            switch (type)
            {
                case "SimpleGoal":
                    var simpleGoal = new SimpleGoal(name, description, points);
                    SetCompleted(simpleGoal, completed);
                    return simpleGoal;

                case "EternalGoal":
                    var eternalGoal = new EternalGoal(name, description, points);
                    SetCompleted(eternalGoal, completed);
                    return eternalGoal;

                case "ChecklistGoal":
                    int targetCount = jsonObject.GetProperty("TargetCount").GetInt32();
                    int currentCount = jsonObject.GetProperty("CurrentCount").GetInt32();
                    int bonusPoints = jsonObject.GetProperty("BonusPoints").GetInt32();

                    var checklistGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                    checklistGoal.CurrentCount = currentCount;
                    SetCompleted(checklistGoal, completed);
                    return checklistGoal;

                default:
                    throw new Exception("Unknown goal type during deserialization");
            }
        }

        public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is SimpleGoal) writer.WriteString("Type", "SimpleGoal");
            else if (value is EternalGoal) writer.WriteString("Type", "EternalGoal");
            else if (value is ChecklistGoal) writer.WriteString("Type", "ChecklistGoal");
            else throw new Exception("Unknown goal type during serialization");

            writer.WriteString("Name", value.Name);
            writer.WriteString("Description", value.Description);
            writer.WriteNumber("Points", value.Points);
            writer.WriteBoolean("_completed", GetCompleted(value));

            if (value is ChecklistGoal checklist)
            {
                writer.WriteNumber("TargetCount", checklist.TargetCount);
                writer.WriteNumber("CurrentCount", checklist.CurrentCount);
                writer.WriteNumber("BonusPoints", checklist.BonusPoints);
            }

            writer.WriteEndObject();
        }

        private void SetCompleted(Goal goal, bool completed)
        {
            var field = typeof(Goal).GetField("_completed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(goal, completed);
            }
        }

        private bool GetCompleted(Goal goal)
        {
            var field = typeof(Goal).GetField("_completed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
            {
                return (bool)field.GetValue(goal);
            }
            return false;
        }
    }
}
