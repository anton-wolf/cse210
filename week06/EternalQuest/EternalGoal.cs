namespace EternalQuest;

public class EternalGoal(string name, string description, string points) : Goal(name, description, points)
{
    public override string GetStringRepresentation()
    {
        return $"EternalGoal::{_shortName}::{_description}::{_points}";
    }
    
    public override string GetDetailsString()
    {
        return $"[] {_shortName} ({_description})";
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Hooray! you've completed your task and earned {_points} points!!");
    }

    public override void SetIsComplete(bool state)
    {
    }
}