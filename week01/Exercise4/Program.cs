using System;

class Program
{
    static void Main(string[] args)
    {
        // init number value cannot be 0
        int number = -1;

        // create list to, which will be populated by the provided number
        List<int> numbers = new List<int>();

        while (number != 0)
        {
            // read input
            Console.Write("Enter a number: ");
            // convert to int
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);
        }

        int sum = 0;

        // get sum of list elements
        foreach (int list_number in numbers)
        {
            sum += list_number;
        }

        Console.WriteLine($"Sum: {sum}");

        // get list average
        var average = (float)sum / numbers.Count;
        Console.WriteLine($"Average: {average}");

        // largest number in the list
        Console.WriteLine($"Max: {numbers.Max()}");
    }
}