namespace Shapes;

class Program
{
    static void Main(string[] args)
    {
        Square sShape = new Square();
        sShape.SetSide(50);
        Rectangle rShape = new Rectangle();
        rShape.SetDimensions(100, 50);
        Circle cShape = new Circle();
        cShape.SetRadius(25);

        List<Shape> shapes = new List<Shape>();

        shapes.Add(sShape);
        shapes.Add(rShape);
        shapes.Add(cShape);

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.GetArea());
        }
    }
}