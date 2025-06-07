using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") { }

    public override void Run()
    {
        DisplayStartMessage();
        int duration = GetDurationFromUser();

        Console.WriteLine("\nClear your mind and focus on your breathing...\n");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            Countdown(4);

            Console.Write("Now breathe out... ");
            Countdown(6);

            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}