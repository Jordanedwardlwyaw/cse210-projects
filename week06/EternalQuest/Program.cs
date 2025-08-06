using System;

namespace EternalQuest
{
    class Program
    {
        static GoalManager goalManager = new GoalManager();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEternal Quest Program");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Show Score");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option (1-7): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        goalManager.ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        Console.WriteLine($"Total Score: {goalManager.TotalScore}");
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the Eternal Quest Program!");
        }

        static void CreateGoal()
        {
            Console.WriteLine("\nSelect goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();

            int points = ReadInt("Enter points for completing/recording the goal: ");

            switch (choice)
            {
                case "1":
                    goalManager.AddGoal(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    goalManager.AddGoal(new EternalGoal(name, description, points));
                    break;
                case "3":
                    int targetCount = ReadInt("Enter how many times to complete the goal: ");
                    int bonusPoints = ReadInt("Enter bonus points upon completion: ");
                    goalManager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            Console.WriteLine("Goal created successfully!");
        }

        static void SaveGoals()
        {
            Console.Write("Enter filename to save goals (e.g., goals.json): ");
            string filename = Console.ReadLine();

            try
            {
                goalManager.Save(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving goals: " + e.Message);
            }
        }

        static void LoadGoals()
        {
            Console.Write("Enter filename to load goals (e.g., goals.json): ");
            string filename = Console.ReadLine();

            try
            {
                goalManager.Load(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading goals: " + e.Message);
            }
        }

        static void RecordEvent()
        {
            goalManager.ListGoals();

            int goalNum = ReadInt("Enter the goal number you completed/recorded: ") - 1;
            goalManager.RecordEvent(goalNum);
        }

        static int ReadInt(string prompt)
        {
            int value;
            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("Invalid number, please enter a non-negative integer.");
            } while (true);
        }
    }
}

/*
Creative additions beyond core requirements:

- Polymorphic JSON serialization to save/load all goal types including progress.
- Notification with bonus points when checklist goals complete.
- Eternal goals show an infinity symbol in the status.
- Input validation for user input.
- Console menu with clear feedback and user-friendly interface.
- Well-structured code organized by class, supporting easy extension.
*/
