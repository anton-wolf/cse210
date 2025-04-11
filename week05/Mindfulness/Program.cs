namespace Mindfulness;

/*
 * Exceeds Requirements
 * Ensures no random prompts/questions are selected until they have
 * all been used at least once in that session.
 *
 * Accounts for edge case where Breathing Activity can end with someone
 * indefinitely breathing in... takes a couple of seconds more though 😖.
 */
using System;

class Program
{
    static void Main(string[] args)
    {
        // declare input to use with the while loop
        string input = "";

        // exit while loop if iput matches any value in this list
        List<string> isInList = new List<string>
        {
            "1", "2", "3", "4"
        };

        while (!isInList.Contains(input))
        {
            // display the menu
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    BreathingActivity breathingAct = new BreathingActivity(
                        "Breathing Activity",
                        "This activity will help you relax by walking you through " +
                        "in and out slowly. Clear your mind and focus on your breathing"
                    );

                    breathingAct.DisplayStartingMessage();

                    Console.Clear();

                    breathingAct.Run();

                    input = "";

                    break;

                case "2":
                    ReflectingActivity reflectingAct = new ReflectingActivity(
                        "Reflecting Activity",
                        "This activity will help you reflect on times in your life " +
                        "when you have shown strength and resilience. This will help you " +
                        "recognize the power you have and how you can use it in other " +
                        "aspects of your life."
                    );

                    reflectingAct.DisplayStartingMessage();

                    Console.Clear();

                    reflectingAct.Run();

                    input = "";
                    break;

                case "3":
                    ListingActivity listingAct = new ListingActivity(
                        "Listing Activity",
                        "This activity will help you on the good things " +
                        "in your life by having you list as many things " +
                        "as you can in a certain area."
                    );

                    listingAct.DisplayStartingMessage();

                    Console.Clear();

                    listingAct.Run();

                    input = "";
                    break;

                default: Console.WriteLine("See you soon!"); break;
            }
        }
    }
}