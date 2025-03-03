using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = 99;
        string message = "";
        Console.Write("What is the magic number? ");
        int guessedNumber = int.Parse(Console.ReadLine());
        while (guessedNumber != magicNumber)
        {
            if (guessedNumber < magicNumber)
            {
                message = "higher";
            }
            else
            {
                message = "lower";
            }

            Console.WriteLine($"Guess {message}!");

            Console.Write("What is the magic number? ");
            guessedNumber = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("You guessed the magic number!");
    }
}