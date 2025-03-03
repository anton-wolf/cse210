using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to CSE210 25T2!");
        }

        static void DisplayNameFromInput()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
        }

        static void DisplayNumberFromParam(int number)
        {
            Console.WriteLine($"Your favourite number is {number}");
        }

        static int GetSquareOfInputNumber(int number)
        {
            return number * number;
        }

        DisplayWelcomeMessage();

        DisplayNameFromInput();

        Console.Write("Enter your favourite number: ");
        int number = int.Parse(Console.ReadLine());

        DisplayNumberFromParam(number);

        
        Console.WriteLine($"Square of {number} is {GetSquareOfInputNumber(number)}");
    }
}