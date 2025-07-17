using System;

// EXCEEDS REQUIREMENTS:
// - Added difficulty levels (easy/medium/hard) for number of words hidden per round.
// - Tracks how many rounds it took to complete.
// - Uses console colors for better readability.

class Program
{
    static void Main(string[] args)
    {
        // Choose difficulty
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Choose a difficulty level:");
        Console.WriteLine("1. Easy (1 word hidden per round)");
        Console.WriteLine("2. Medium (3 words hidden per round)");
        Console.WriteLine("3. Hard (5 words hidden per round)");
        Console.Write("Enter 1, 2, or 3: ");
        string choice = Console.ReadLine();
        int hideCount = choice == "1" ? 1 : choice == "3" ? 5 : 3;

        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        int round = 0;

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(scripture.GetDisplayText());
            Console.ResetColor();

            Console.WriteLine($"\n[Round {round + 1}] Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(hideCount);
            round++;
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(scripture.GetDisplayText());
        Console.ResetColor();
        Console.WriteLine($"\nAll words are hidden. It took you {round} rounds. Program ended.");
    }
}
