using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("Unboxing the Future: Smart Glasses!", "TechWorld", 540);
        video1.AddComment(new Comment("Anna", "This is so cool!"));
        video1.AddComment(new Comment("Jake", "I want a pair now."));
        video1.AddComment(new Comment("Liam", "Great review!"));

        var video2 = new Video("10 Easy Dinner Recipes", "ChefDaily", 780);
        video2.AddComment(new Comment("Sarah", "My kids loved #3!"));
        video2.AddComment(new Comment("Carlos", "More vegetarian options, please."));
        video2.AddComment(new Comment("Emma", "Cooking level: beginner friendly. Love it!"));

        var video3 = new Video("Workout with Me - 20 Min Cardio", "FitLife", 1200);
        video3.AddComment(new Comment("John", "I was sweating by minute 5!"));
        video3.AddComment(new Comment("Mila", "Perfect for my morning routine."));
        video3.AddComment(new Comment("Dave", "Could use a cooldown section."));

        var video4 = new Video("Relaxing Piano Music", "ZenVibes", 1800);
        video4.AddComment(new Comment("Chloe", "Studying with this on."));
        video4.AddComment(new Comment("Noah", "Peaceful vibes. Subscribed!"));
        video4.AddComment(new Comment("Ava", "Helps me sleep. Thank you!"));

        var videos = new List<Video> { video1, video2, video3, video4 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}