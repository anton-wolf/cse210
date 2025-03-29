using System;
using Journal;

class Program
{
    static void Main(string[] args)
    {
        // create while loop to keep program running until explicit exit
        // set options
        bool isRunning = true;

        // persistant class instances
        Entry entry = new Entry();
        Journal.Journal journal = new Journal.Journal();

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine();
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Exit");
            Console.WriteLine();


            // get choice
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // instantiate classes
                    PromptGenerator promptGenerator = new PromptGenerator();

                    // generate data for attributes
                    DateTime timeNow = DateTime.Now;
                    string dateText = timeNow.ToShortDateString();
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string newEntry = Console.ReadLine();

                    // populate attributes
                    entry._date = dateText;
                    entry._promptText = prompt;
                    entry._entryText = newEntry; 
                    

                    // populate entries
                    string data = $"{entry._date}\n{entry._promptText}\n{entry._entryText}";
                    journal.AddEntry(data);
                    entry.Display();
                    break;
                case "2":
                    // instantiate classes
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.WriteLine("Provide file name:");
                    Console.Write("> ");
                    string fileNameSave = Console.ReadLine();
                    journal.SaveToFile($"{fileNameSave}.txt");
                    break;
                case "4":
                    Console.WriteLine("Provide file name:");
                    Console.Write("> ");
                    string fileNameOpen = Console.ReadLine();
                    journal.LoadFromFile($"{fileNameOpen}.txt");
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("See you later!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}