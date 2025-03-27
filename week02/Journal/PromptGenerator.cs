namespace Journal;

public class PromptGenerator
{
    public List<string> _prompts;

    public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one lesson I learned today?",
            "What made me smile today?",
            "How did I step out of my comfort zone today?",
            "What is something I accomplished today, no matter how small?",
            "What is something I am grateful for today?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}