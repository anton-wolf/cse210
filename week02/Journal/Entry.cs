namespace Journal;

public class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }


    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine($"{_date}\n{_promptText}\n{_entryText}");
    }
}