namespace ScriptureMemorizer;

public class Reference
{
    private string _from;
    private string _book;
    private int _chapter;
    private string _verse;

    public Reference(string from, string book, int chapter, string verse)
    {
        _from = from;
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string GetDisplayText()
    {
        
        return _from == _book ? $"{_book}\n{_chapter.ToString()}:{_verse}" : 
            $"{_from} | {_book}\n{_chapter.ToString()}:{_verse}";
    }
    
}