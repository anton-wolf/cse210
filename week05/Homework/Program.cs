namespace Homework;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assign1 = new MathAssignment("Katlego Kgwetiane",
            "Fractions",
            "7.3",
            "8-19");

        WritingAssignment assign2 = new WritingAssignment("Kairo Kgwetiane",
            "European History",
            "The Causes of World War II");

        Console.WriteLine(assign1.GetHomeWorkList());

        Console.WriteLine();

        Console.WriteLine(assign2.GetWritingInformation());
    }
}