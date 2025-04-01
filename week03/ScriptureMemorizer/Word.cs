using System.Text.RegularExpressions;

namespace ScriptureMemorizer;

public class Word
{
    private string _text;
    private string _wordPart;
    private string _punctuation;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        
        Match match = Regex.Match(text, @"^(\w+)(\W*)$");
        
        if (match.Success)
        {
            _wordPart = match.Groups[1].Value; 
            _punctuation = match.Groups[2].Value;
        }
        else
        {
            _wordPart = text; 
            _punctuation = "";
        }
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _wordPart.Length) + _punctuation : _text;
    }
}