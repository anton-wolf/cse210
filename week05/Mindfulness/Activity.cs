namespace Mindfulness;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        /*
         * I've opted to collect duration input here, because setting up a setter
         * seemed to expose details of this class.
         */
        Console.Write("How long, in seconds, would you like for your session? ");

        _duration = Convert.ToInt32(Console.ReadLine());
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(false);
    }

    public void ShowSpinner(bool isStarting = true)
    {
        List<string> spinnerStrings = new List<string>
        {
            "|", "/", "-", "\\", "|", "/", "-", "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(10);
        //DateTime endTime = startTime.AddSeconds(9);
        int indexOfSpinnerStrings = 0;

        if (isStarting)
            Console.WriteLine("Get Ready...");

        while (DateTime.Now <= endTime)
        {
            Console.Write(spinnerStrings[indexOfSpinnerStrings]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            indexOfSpinnerStrings++;

            if (indexOfSpinnerStrings % spinnerStrings.Count == 0)
                indexOfSpinnerStrings = 0;
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b");

            // break at the last second
            if (i == 1)
            {
                Console.Write(" \b");
                break;
            }
        }

        Console.WriteLine();
    }

    public DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }
}