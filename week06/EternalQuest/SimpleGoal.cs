namespace EternalQuest;

public class SimpleGoal(string name, string description, string points) : Goal(name, description, points)
{
    private bool _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal::{_shortName}::{_description}::{_points}::{_isComplete}";
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public override bool IsComplete()
    {
        if (_isComplete)
        {
            return true;
        }

        return false;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _isComplete = true;
            Console.WriteLine($"Hooray! you've completed your task and earned {_points} points!!");
        }
    }

    public override void SetIsComplete(bool state)
    {
        _isComplete = state;
    }
}