using System;
using System.Collections.Generic;

class GratitudeActivity : Activity
{
    public GratitudeActivity()
        : base("Gratitude Activity", "This activity helps you focus on gratitude by listing what you're thankful for and reflecting on it.") { }

    public override void Run()
    {
        DisplayStartMessage();
        int duration = GetDurationFromUser();
        List<string> items = new List<string>();

        Console.WriteLine("\nWrite things you're grateful for:");
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"\nYou listed {items.Count} things you're grateful for.");
        Console.WriteLine("Here's what you wrote:");
        foreach (string item in items)
        {
            Console.WriteLine($"- {item}");
        }

        DisplayEndMessage();
    }
}