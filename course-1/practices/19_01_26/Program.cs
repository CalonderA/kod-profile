using System;

public abstract class Shape
{
    public abstract string Name { get; }
    public abstract double GetArea();

    public void Print()
    {
        Console.WriteLine($"{Name}: площадь = {GetArea():F2}");
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override string Name => "Круг";

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override string Name => "Прямоугольник";

    public override double GetArea()
    {
        return Width * Height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[]
        {
            new Circle(5.0),
            new Rectangle(4.0, 6.0),
            new Circle(3.5),
            new Rectangle(2.5, 4.5)
        };

        foreach (Shape shape in shapes)
        {
            shape.Print();
        }
    }
}