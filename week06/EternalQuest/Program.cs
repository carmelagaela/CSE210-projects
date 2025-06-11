class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.LoadGoals("goals.txt");

        string input;
        do
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Show Level");
            Console.WriteLine("6. Show Badges");
            Console.WriteLine("7. Save and Exit");
            Console.Write("Select an option: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Goal Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Points: ");
                    int pts = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choose Type: 1) Simple 2) Eternal 3) Checklist");
                    string type = Console.ReadLine();
                    if (type == "1")
                        manager.AddGoal(new SimpleGoal(name, desc, pts));
                    else if (type == "2")
                        manager.AddGoal(new EternalGoal(name, desc, pts));
                    else if (type == "3")
                    {
                        Console.Write("Target Count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus Points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, pts, target, 0, bonus));
                    }
                    break;
                case "2":
                    manager.ShowGoals();
                    break;
                case "3":
                    manager.ShowGoals();
                    Console.Write("Which goal did you complete? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;
                case "4":
                    Console.WriteLine($"Your score: {manager.GetScore()}");
                    break;
                case "5":
                    Console.WriteLine($"Current Level: {manager.GetLevel()}");
                    break;
                case "6":
                    manager.ShowBadges();
                    break;
                case "7":
                    manager.SaveGoals("goals.txt");
                    Console.WriteLine("Progress saved. Goodbye!");
                    break;
            }
        } while (input != "7");
    }
}