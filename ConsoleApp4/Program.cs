using System;
// Интерфейс IDrawable с методом Draw()
public interface IDrawable
{
    void Draw();
}
// Класс Circle, реализующий интерфейс IDrawable
public class Circle : IDrawable
{
    public double Radius { get; set; }
    public Circle(double radius)
    {
        Radius = radius;
    }
    // Реализация метода Draw для круга
    public void Draw()
    {
        Console.WriteLine($"Рисую круг с радиусом {Radius}");
    }
}
// Класс Rectangle, реализующий интерфейс IDrawable
public class Rectangle : IDrawable
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    // Реализация метода Draw для прямоугольника
    public void Draw()
    {
        Console.WriteLine($"Рисую прямоугольник с шириной {Width} и высотой {Height}");
    }
}
// Класс Triangle, реализующий интерфейс IDrawable
public class Triangle : IDrawable
{
    public double Base { get; set; }
    public double Height { get; set; }
    public Triangle(double baseLength, double height)
    {
        Base = baseLength;
        Height = height;
    }
    // Реализация метода Draw для треугольника
    public void Draw()
    {
        Console.WriteLine($"Рисую треугольник с основанием {Base} и высотой {Height}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создание массива объектов, реализующих интерфейс IDrawable
        IDrawable[] shapes = new IDrawable[]
        {
            new Circle(10),
            new Rectangle(8, 12),
            new Triangle(5, 8)
        };
        // Вызов метода Draw() для каждого объекта
        Console.WriteLine("Рисуем фигуры:");
        foreach (IDrawable shape in shapes)
        {
            shape.Draw();
        }
    }
}
