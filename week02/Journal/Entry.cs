using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; } // Added: Mood or Tag for entry

    public int WordCount => Response.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; // Added: Word count

    public Entry() { }

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\nWord Count: {WordCount}\n";
    }
}
