using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your grade? ");
        string grade = Console.ReadLine();
        int gradeInt = Convert.ToInt32(grade);
        Console.WriteLine($"Your grade is {gradeInt}");
        string message = "";
        if (gradeInt >= 90)
        {
            message = "excellent work! You got an A!";
        }
        else if (gradeInt >= 80)
        {
            message = "Great! you got an B!";
        }
        else if (gradeInt >= 70)
        {
            message = "Good job you got an C!";
        }
        else if (gradeInt >= 60)
        {
            message = "You got a D!";
        }
        else
        {
            message = "Not good you got an F!";
        }

        Console.WriteLine(message);
    }
}