using System;

namespace Journal;

public class Journal
{
    // array to store entries
    public List<object> _entries = new List<object>();

    public void AddEntry(string newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine(new string('-', 30));
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename, append: false))
        {
            foreach (string entry in _entries)
            {
                writer.WriteLine(entry.Trim());
                writer.WriteLine(new string('-', 30));
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        Console.WriteLine();
        _entries.Clear();

        string currentEntry = "";

        foreach (string line in lines)
        {
            if (line == new string('-', 30)) // End of an entry
            {
                if (!string.IsNullOrWhiteSpace(currentEntry))
                {
                    _entries.Add(currentEntry.Trim());
                    currentEntry = "";
                }
            }
            else
            {
                currentEntry += (currentEntry.Length > 0 ? "\n" : "") + line;
            }
        }

        if (!string.IsNullOrWhiteSpace(currentEntry))
        {
            _entries.Add(currentEntry.Trim().Replace(new string('-', 30), ""));
        }

        DisplayAll();
    }
}