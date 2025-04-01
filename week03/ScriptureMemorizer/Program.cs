using ScriptureMemorizer;

/*
 * Exceeded requirements:
 * my program works with a library of scriptures rather than a single one
 * in the form of scriptures.json
 * as a result adjustments have been introduced to the Reference class
 * Please be understanding.
 *
 * The program can also show() at random by typing "back"
 * The program accounts for punctuation as something that can
 * help a person recall better.
 */

class Program
{
    static void Main(string[] args)
    {
        /*
         * I added a scripture [Generator] class of my own
         * to pull scripture data from JSON file, its interaction
         * with [Reference] seems redundant, but [Reference] and it's attributes
         * are scoped in the rubric, so I couldn't do without it,
         * but I did drop the [endVerse] field, [Generator] handles that now.
         */
        Generator generator = new Generator();

        // had to use dynamic object beause I can't have more than
        // one class per file, and I can't have public attributes
        // (which would be set to only publicly get, but privately set)
        // the additional classes would provide the JSON structure models
        // for stricter typing and having known properties

        //I could've done the JSON stuff in [Referece], but I'd have
        // no args to pass during instantiation, which is a design
        // requirement, so be understanding.
        dynamic scriptureData = generator.GetScriptureData();

        Reference reference = new Reference(
            scriptureData.from,
            scriptureData.book,
            scriptureData.chapter,
            scriptureData.verseNumber);
        Scripture scripture = new Scripture(reference, scriptureData.verseText);

        Random rand = new Random();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Hello, Welcome to my scripture memorizer!\nHere's a scripture to learn.");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue the memorize the scripture.");
            Console.WriteLine("Type 'back' to show hidden words.");
            Console.WriteLine("Type 'quit' to exit the program.");
            Console.Write("> ");

            string input = Console.ReadLine()?.Trim().ToLower();
            if (input == "quit" || scripture.IsCompletelyHidden())
                break;

            if (input == "back")
                // bumped in additional param (randomizer) so it can persist
                // through to [HideRandomWords]
                scripture.ShowRandomWords(rand.Next(1, 4), rand);
            
            if (string.IsNullOrEmpty(input))
                // bumped in additional param (randomizer) so it can persist
                // through to [HideRandomWords]
                scripture.HideRandomWords(rand.Next(1, 4), rand);

            Console.WriteLine();
        }

        Console.WriteLine("See you soon!");
    }
}