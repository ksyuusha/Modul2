using System;
public class Author
{
    // Поля для хранения имени и года рождения автора
    public string Name { get; set; }
    public int BirthYear { get; set; }
    // Конструктор для инициализации объекта Author
    public Author(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }
    // Метод для вывода информации об авторе
    public void DisplayInfo()
    {
        Console.WriteLine($"Автор: {Name}, Год рождения: {BirthYear}");
    }
}
public class Book
{
    // Поля для хранения информации о книге
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    // Связь с объектом Author (композиция)
    public Author Author { get; set; }
    // Конструктор для инициализации объекта Book, включая объект Author
    public Book(string title, int releaseYear, Author author)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Author = author;
    }
    // Метод для вывода информации о книге
    public void DisplayInfo()
    {
        Console.WriteLine($"Книга: {Title}, Год выпуска: {ReleaseYear}");
        Author.DisplayInfo();  // Вызываем метод для вывода информации об авторе
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создаем объекты авторов
        Author author1 = new Author("Лев Толстой", 1828);
        Author author2 = new Author("Джордж Оруэлл", 1903);
        // Создаем объекты книг с привязкой к авторам
        Book book1 = new Book("Война и мир", 1869, author1);
        Book book2 = new Book("1984", 1949, author2);
        // Вывод информации о книгах и их авторах
        Console.WriteLine("Информация о книгах:");
        book1.DisplayInfo();
        Console.WriteLine();
        book2.DisplayInfo();
    }
}
