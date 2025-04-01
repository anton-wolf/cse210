namespace YouTubeVideos;

public class Comment
{
    public string _commentor;
    public string _text;

    public Comment(string commentor, string text)
    {
        _commentor = commentor;
        _text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"- {_commentor}: {_text}");
    }
}