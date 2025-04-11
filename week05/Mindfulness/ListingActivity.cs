namespace Mindfulness;

/*
 * I didn't see any relevance for
 * GetListFromUser(), so I've excluded it
 * through my design, I don't see anything that
 * needs to be dedicated to it as a method.
 */
public class ListingActivity : Activity
{
    private int _count = 0;
    private List<string> _prompts = new List<string>();

    public ListingActivity(string name, string description) : base(name, description)
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run()
    {
        Console.WriteLine();

        ShowSpinner();

        GetRandomPrompt();

        Console.Write("You may begin in: ");

        ShowCountDown(5);

        DateTime endTime = GetEndTime();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string input = Console.ReadLine();

            _count++;
        }

        Console.WriteLine();

        string items = _count > 1 ? "items" : "item";

        Console.WriteLine($"You've listed {_count} {items}.");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        Console.WriteLine("List as many responses you can to the following prompt:");

        Console.WriteLine();

        Console.WriteLine($"---- {_prompts[index]} ----");
    }
}