using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<string> _verses;
    private Random _rand;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _verses = text.Split(new[] { ". ", "? ", "! " }, StringSplitOptions.None).ToList();
        _words = new List<Word>();
        _rand = new Random();

        foreach (string verse in _verses)
        {
            string[] verseWords = verse.Split(' ');
            foreach (var word in verseWords)
                _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < Math.Min(count, visibleWords.Count); i++)
        {
            int index = _rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";
        int wordIndex = 0;

        foreach (string verse in _verses)
        {
            string[] verseWords = verse.Split(' ');
            List<string> displayWords = new List<string>();

            for (int i = 0; i < verseWords.Length; i++)
            {
                displayWords.Add(_words[wordIndex].GetDisplayText());
                wordIndex++;
            }

            result += string.Join(" ", displayWords) + "\n";
        }

        return result;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
