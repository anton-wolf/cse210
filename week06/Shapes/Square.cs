namespace Shapes;

public class Square : Shape
{
    private double _side;

    public void SetSide(double side)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return Math.Pow(_side, 2);
    }
}