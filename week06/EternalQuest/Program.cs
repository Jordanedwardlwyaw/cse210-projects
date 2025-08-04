using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new();
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("0. Quit");

            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: manager.CreateGoal(); break;
                case 2: manager.DisplayGoals(); Console.ReadKey(); break;
                case 3: manager.SaveGoals("goals.txt"); break;
                case 4: manager.LoadGoals("goals.txt"); break;
                case 5: manager.RecordEvent(); Console.ReadKey(); break;
                case 6: manager.ShowScore(); Console.ReadKey(); break;
            }

        } while (choice != 0);
    }
}
