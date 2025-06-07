using System;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine($"\nGreat job! You've completed the {_name}.\n");
    }

    public int GetDurationFromUser()
    {
        Console.Write("Enter duration in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }
        return duration;
    }

    public void Spinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\nGo!\n");
    }

    public abstract void Run();
}