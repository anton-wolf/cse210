namespace Mindfulness;
/*
 * sticking with GetRandomQuestions() seemed to be more of a disadvantage
 * when attempting to make each iteration unique per cycle
 * first of all, I have to have a new List type attribute,
 * which is processed both by GetRandomQuestions() and DisplayQuestions(),
 * this I think complicates the logic and doesn't provide a good separation
 * of concerns.
 * The other reason is I'd have two while loops doing separate things in
 * separate methods, while there's really nothing wrong with that setup,
 * I'd rather avoid the runtime complex of using two
 * while loops where I can realistically use one. In short, I've dropped
 * GetRandomQuestions() because I don't think it's truly necessary.
 */
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> { };
    private List<string> _questions = new List<string> { };

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        Console.WriteLine();

        ShowSpinner();

        DisplayPrompt();

        // wait until appropriate input is received
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue...");

        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
        }

        Console.WriteLine();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        // randomly pick prompt
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
    
    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");

        Console.WriteLine();

        Console.WriteLine($"---- {GetRandomPrompt()} ----");
    }

    public void DisplayQuestions()
    {
        Console.WriteLine("Now ponder each of the following questions as " +
                          "they relate to this experience.");

        Console.Write("You may begin in: ");

        ShowCountDown(5);

        Random random = new Random();

        Console.Clear();

        Console.WriteLine();

        DateTime endTime = GetEndTime();

        /*
         * the comparison list ensures we won't
         * repeat questions within a given cycle
         */
        List<int> compareRandomIndex = new List<int>();

        while (DateTime.Now < endTime)
        {
            int index = random.Next(_questions.Count);

            // only display question if not already displayed
            if (compareRandomIndex.Contains(index))
                continue;

            // add each randomly picked index to the comparison list
            compareRandomIndex.Add(index);

            Console.Write($"> {_questions[index]} ");

            ShowSpinner(false);

            // reset comparison index if full
            if (compareRandomIndex.Count == _questions.Count)
                compareRandomIndex.Clear();
        }
    }
}