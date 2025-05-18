using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string autosavePath = "autosave_journal.json"; // Added: Default autosave path

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
        AutoSave(); // Autosave every time a new entry is added
    }

    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (var entry in entries)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(entry);
            Console.WriteLine("=================================");
        }
        Console.ResetColor();
    }

    public void SaveToFile(string filename)
    {
        var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var json = File.ReadAllText(filename);
        entries = JsonSerializer.Deserialize<List<Entry>>(json);
        Console.WriteLine("Journal loaded successfully.");
    }

    private void AutoSave()
    {
        File.WriteAllText(autosavePath, JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true }));
    }

    public void DisplayByMood(string mood)
    {
        var filtered = entries.Where(e => e.Mood.Equals(mood, StringComparison.OrdinalIgnoreCase)).ToList();
        if (filtered.Count == 0)
        {
            Console.WriteLine($"No entries found with mood: {mood}");
            return;
        }

        foreach (var entry in filtered)
        {
            Console.WriteLine(entry);
        }
    }

    public void Search(string keyword)
    {
        var result = entries.Where(e => e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        if (result.Count == 0)
        {
            Console.WriteLine("No matching entries found.");
            return;
        }

        foreach (var entry in result)
        {
            Console.WriteLine(entry);
        }
    }

    public void CalendarView()
    {
        var dates = entries.Select(e => e.Date).Distinct();
        Console.WriteLine("You have entries on the following dates:");
        foreach (var date in dates)
        {
            Console.WriteLine($"- {date}");
        }
    }

    public bool HasEntryToday()
    {
        string today = DateTime.Now.ToShortDateString();
        return entries.Any(e => e.Date == today);
    }
}
