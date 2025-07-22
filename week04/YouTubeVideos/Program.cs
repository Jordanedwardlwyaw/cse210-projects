using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create sample videos
        Video video1 = new Video("Exploring Uganda", "Jordan Edward", 420);
        video1.AddComment(new Comment("Alice", "Great video! Love the culture."));
        video1.AddComment(new Comment("Brian", "Nice editing!"));
        video1.AddComment(new Comment("Clara", "I want to visit Uganda now."));

        Video video2 = new Video("Tech Tips 2025", "TechDaily", 600);
        video2.AddComment(new Comment("Daniel", "Very helpful tips, thanks!"));
        video2.AddComment(new Comment("Emma", "Waiting for the next one."));
        video2.AddComment(new Comment("Frank", "Subscribed!"));

        Video video3 = new Video("Cooking Matoke", "Mama Africa", 300);
        video3.AddComment(new Comment("Grace", "Looks delicious!"));
        video3.AddComment(new Comment("Henry", "My grandma used to cook this."));
        video3.AddComment(new Comment("Ivy", "Trying this tonight!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information
        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}
