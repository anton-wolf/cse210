namespace EternalQuest;

public class ChecklistGoal(
    string name,
    string description,
    string points,
    string target,
    string bonus,
    int completed = 0)
    : Goal(name, description, points)
{
    private int _amountCompleted = completed;
    private int _target = Convert.ToInt32(target);
    private int _bonus = Convert.ToInt32(bonus);

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal::{_shortName}::{_description}::{_points}::{_target}::{_bonus}::{_amountCompleted}";
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[]";
        return $"{checkbox} {_shortName} ({_description}) -- Currently I've completed: {_amountCompleted}/{_target}";
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }

        return false;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted += 1;
        }

        if (!IsComplete())
        {
            Console.WriteLine($"Hooray! you've earned {_points} points!!");
        }
        else
        {
            Console.WriteLine($"Hooray! you've completed your task and earned {_bonus} points!!");
        }
    }

    public override int GetPoints()
    {
        if (IsComplete())
        {
            return _bonus;
        }

        return Convert.ToInt32(_points);
    }

    public override void SetIsComplete(bool state)
    {
        if (state)
        {
            _target = _amountCompleted;
        }
    }
}