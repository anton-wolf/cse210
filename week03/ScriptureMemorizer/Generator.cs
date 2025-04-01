using System.Dynamic;
using System.Text.Json;

namespace ScriptureMemorizer;

public class Generator
{
    private string _from;
    private string _book;
    private int _chapter;
    private List<JsonElement> _verses = new List<JsonElement>();
    private string _verseText;
    private string _verseNumber;

    public Generator()
    {
        string filePath = "scriptures.json"; // Your JSON file path

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);

            /*
             * I could have used List<Dictionary<string, object>> to access the properties of the JSON data,
             * but I opted for List<ExpandoObject> to allow for dot notation access.
             * With ExpandoObject, I can still access properties dynamically and work with the data
             * as if it were a structured object. However, this approach sacrifices the strong typing
             * provided by a class model.
             *
             *
             * While using ExpandoObject offers flexibility, it doesn't enforce a rigid structure.
             * This means that there's a potential risk of runtime errors if the expected properties
             * are missing or misnamed. Nevertheless, given the assignment constraints, this solution
             * seemed like the best compromise.
             *
             *
             * I'm still learning, and based on my research, the optimal solution would likely involve
             * creating dedicated classes that represent the data model. This would ensure that we
             * have a clear structure for the JSON properties, making it easier to work with the data
             * in a more type-safe manner and reducing the chance of errors.
             * In an ideal situation, I would use classes like `ScriptureModel` or `VerseModel` to define the
             * data model at the type level, ensuring that each property is known and validated ahead of time.
             *
             *  public class VerseModel
                {
                    private int _numberr;
                    private string _verseText;
                }

                public class ScriptureModel
                {
                    private string _from;
                    private string _book;
                    private int _chapter;
                    private List<string> _verses;
                }
             */

            //var scriptures = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString);
            //var scriptures = JsonSerializer.Deserialize<List<ScriptureModel>>(jsonString);
            var scriptures = JsonSerializer.Deserialize<List<ExpandoObject>>(jsonString);

            // randomly select a scripture 
            Random random = new Random();

            int index = random.Next(scriptures.Count);

            // loosely access scripture object properties
            dynamic randomScripture = scriptures[index];

            foreach (var verse in randomScripture.verses.EnumerateArray())
                _verses.Add(verse);


            foreach (var verse in _verses)
            {
                string verseText = verse.GetProperty("verse").GetString();
                string verseNumber = verse.GetProperty("number").GetInt32().ToString();
                
                _verseText += verseText;

                if (_verses.Count > 1)
                {
                    int startingVerseNumber = _verses.First().GetProperty("number").GetInt32();
                    int endingVerseNumber = startingVerseNumber + _verses.Count - 1;
                    
                    _verseNumber = $"{startingVerseNumber.ToString()}-{endingVerseNumber.ToString()}";
                }
                else
                    _verseNumber = verseNumber;
                
            }

            _from = randomScripture.from.ToString();
            _book = randomScripture.book.ToString();
            _chapter = randomScripture.chapter.GetInt32();
        }
        else
            Console.WriteLine("File not found.");
    }

    public object GetScriptureData()
    {
        return new
        {
            from = _from,
            book = _book,
            chapter = _chapter,
            verseNumber = _verseNumber,
            verseText = _verseText
        };
    }
}