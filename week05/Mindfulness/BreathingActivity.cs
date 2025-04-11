namespace Mindfulness;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    public void Run()
    {
        Console.WriteLine();

        ShowSpinner();

        DateTime endTime = GetEndTime();

        List<int> range = new List<int>();

        range.AddRange(Enumerable.Range(1, _duration));

        foreach (int i in range)
        {
            if (i % 2 != 0)
                Console.Write("Breathe in...");

            else
                Console.Write("Now breathe out...");

            ShowCountDown(4);

            // account for edge case where activity ends with "Breathe in"
            if (DateTime.Now >= endTime && i % 2 == 0)
                break;
        }
        
        DisplayEndingMessage();
    }
}