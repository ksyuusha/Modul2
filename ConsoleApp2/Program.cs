using System;
public abstract class Shape
{
    // Абстрактные методы для расчета площади и периметра
    public abstract double Area();
    public abstract double Perimeter();
}
// Класс Circle, производный от Shape
public class Circle : Shape
{
    private double radius;
    // Конструктор для установки радиуса круга
    public Circle(double radius)
    {
        this.radius = radius;
    }
    // Переопределение метода для расчета площади круга
    public override double Area()
    {
        return Math.PI * radius * radius;
    }
    // Переопределение метода для расчета периметра круга
    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}
// Класс Rectangle, производный от Shape
public class Rectangle : Shape
{
    private double width;
    private double height;
    // Конструктор для установки ширины и высоты прямоугольника
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }
    // Переопределение метода для расчета площади прямоугольника
    public override double Area()
    {
        return width * height;
    }
    // Переопределение метода для расчета периметра прямоугольника
    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создание объекта круга с радиусом 5
        Circle circle = new Circle(5);
        Console.WriteLine("Круг:");
        Console.WriteLine($"Площадь: {circle.Area():F2}");
        Console.WriteLine($"Периметр: {circle.Perimeter():F2}");
        // Создание объекта прямоугольника с шириной 4 и высотой 7
        Rectangle rectangle = new Rectangle(4, 7);
        Console.WriteLine("\nПрямоугольник:");
        Console.WriteLine($"Площадь: {rectangle.Area():F2}");
        Console.WriteLine($"Периметр: {rectangle.Perimeter():F2}");
    }
}
