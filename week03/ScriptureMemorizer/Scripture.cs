using System.Text.RegularExpressions;

namespace ScriptureMemorizer;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        // used LINQ syntax
        _reference = reference;
        _words = text.Split(" ")
            .Select(wordText => new Word(wordText))
            .ToList();
    }

    public string GetDisplayText()
    {
        string concatinatedText = "";

        foreach (var word in _words)
            concatinatedText += $"{word.GetDisplayText()} ";


        return $"{_reference.GetDisplayText()}\n{concatinatedText}";
    }

    public void HideRandomWords(int numberToHide, Random random)
    {
        List<int> visibleIndexes = _words
            .Select((word, index) => new { word, index })
            .Where(x => !x.word.IsHidden()) // words that aren't already hidden
            .Select(x => x.index)
            .ToList();

        if (visibleIndexes.Count == 0) return; // Nothing to hide

        HashSet<int> hiddenIndices = new HashSet<int>();
        int wordsToHide = Math.Min(numberToHide, visibleIndexes.Count);

        while (hiddenIndices.Count < wordsToHide)
        {
            int index = visibleIndexes[random.Next(visibleIndexes.Count)];
            hiddenIndices.Add(index);
        }

        foreach (int index in hiddenIndices)
            _words[index].Hide();
    }


    public void ShowRandomWords(int numberToShow, Random random)
    {
        List<int> invisibleIndexes = _words
            .Select((word, index) => new { word, index })
            .Where(x => x.word.IsHidden()) // words that are hidden
            .Select(x => x.index)
            .ToList();

        if (invisibleIndexes.Count == 0) return; // Nothing to show

        HashSet<int> shownIndices = new HashSet<int>();
        int wordsToShow = Math.Min(numberToShow, invisibleIndexes.Count);

        while (shownIndices.Count < wordsToShow)
        {
            int index = invisibleIndexes[random.Next(invisibleIndexes.Count)];
            shownIndices.Add(index);
        }

        foreach (int index in shownIndices)
            _words[index].Show();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden() || string.IsNullOrWhiteSpace(w.GetDisplayText()));
    }
}