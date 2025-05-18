using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string[] prompts = {
            "What are you most grateful for today, and why does it matter to you?",
            "What challenge have you faced recently, and how did you respond to it?",
            "What's something you want to let go of right now, and what's stopping you?",
            "How have you taken care of your mental or physical health this week?",
            "If you could design your perfect day, how would it unfold from morning to night?",
            "Who in your life inspires you the most, and what is it about them that moves you?",
            "What emotions have you been feeling most often lately, and what do you think is behind it?",
            "What's something you've been putting off, and what's one small step you could take toward it?",
            "What are three things you truly love about yourself today?",
            "Where do you want to be in six months, and what actions can you take now to move forward that vision?"
        };

        Console.WriteLine("Welcome to the Enhanced Journal Program!");

        // Reminder feature: check if an entry exists today
        if (!journal.HasEntryToday())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📌 Reminder: You haven’t written anything today!");
            Console.ResetColor();
        }

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Display entries by mood");
            Console.WriteLine("6. Search entries by keyword");
            Console.WriteLine("7. Calendar view of entries");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Random rand = new Random();
                    string prompt = prompts[rand.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Mood/Tag (e.g., Happy, Grateful): ");
                    string mood = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(date, prompt, response, mood);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added and autosaved!");
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    Console.Write("Enter mood/tag to filter by: ");
                    string moodFilter = Console.ReadLine();
                    journal.DisplayByMood(moodFilter);
                    break;
                case "6":
                    Console.Write("Enter keyword to search: ");
                    string keyword = Console.ReadLine();
                    journal.Search(keyword);
                    break;
                case "7":
                    journal.CalendarView();
                    break;
                case "8":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
