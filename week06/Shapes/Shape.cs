namespace Shapes;

public abstract class Shape
{
    private string _colour;

    public string GetColour()
    {
        return _colour;
    }

    public void SetColour(string colour)
    {
        _colour = colour;
    }

    /*public abstract void SetDimensions();*/

    public abstract double GetArea();
}