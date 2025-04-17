namespace EternalQuest;

public class GoalsManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private (string name, string description, string points) PromptForGoalDetails()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        return (name, description, points);
    }

    private void CreateGoal()
    {
        string input = "";

        List<string> isInList = new List<string>
        {
            "1", "2", "3"
        };

        while (!isInList.Contains(input))
        {
            // display CreateGoal menu
            Console.WriteLine();
            Console.WriteLine("The types of goals are:");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            input = Console.ReadLine();
        }

        switch (input)
        {
            case "1":
                var (name, description, points) = PromptForGoalDetails();
                // instantiate simple goal class here
                SimpleGoal sGoal = new SimpleGoal(name, description, points);

                _goals.Add(sGoal);

                break;

            case "2":
                var (name2, description2, points2) = PromptForGoalDetails();

                EternalGoal eGoal = new EternalGoal(name2, description2, points2);

                _goals.Add(eGoal);
                break;

            case "3":
                var (name3, description3, points3) = PromptForGoalDetails();

                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string target = Console.ReadLine();

                Console.Write("What is the bonus for accomplishing the goal that many times? ");
                string bonus = Console.ReadLine();

                ChecklistGoal cGoal = new ChecklistGoal(name3, description3, points3, target, bonus);

                _goals.Add(cGoal);

                break;

            default: Console.WriteLine("Wrong Choice!"); break;
        }
    }

    private void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int target = Convert.ToInt32(Console.ReadLine()) - 1;

        var goal = _goals[target];

        goal.RecordEvent();

        _score += goal.GetPoints();
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine(_score > 0 ? $"You now have {_score} points." : "You have 0 points.");
    }

    private void ListGoalNames()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        int counter = 0;
        foreach (var goal in _goals)
        {
            counter++;
            Console.WriteLine($"{counter}. {goal.GetShortName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        int counter = 0;
        foreach (var goal in _goals)
        {
            counter++;
            Console.WriteLine($"{counter}. {goal.GetDetailsString()}.");
        }
    }

    public void Start()
    {
        // declare input to use with the while loop
        string input = "";

        // exit while loop if iput matches any value in this list
        List<string> isInList = new List<string>
        {
            "1", "2", "3", "4", "5", "6"
        };

        while (!isInList.Contains(input))
        {
            // display the menu

            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Goals");
            Console.WriteLine(" 6. Record Goals");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    input = "";
                    break;

                case "2":
                    ListGoalDetails();
                    input = "";
                    break;

                case "3":
                    SaveGoals();
                    input = "";
                    break;

                case "4":
                    LoadGoals();
                    input = "";
                    break;

                case "5":
                    RecordEvent();
                    input = "";

                    break;

                case "6":

                    break;

                default: Console.WriteLine("See you soon!"); break;
            }
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);
            _goals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("::");
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    goal.SetIsComplete(isComplete); // You’d need a SetComplete method
                    _goals.Add(goal);
                }

                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];

                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
                    string targetCount = parts[4];
                    string bonus = parts[5];
                    int currentCount = Convert.ToInt32(parts[6]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, targetCount, bonus, currentCount);
                    _goals.Add(goal);
                }
            }
        }
    }
}