using System;
using System.Collections.Generic;
public class StringArray
{
    private string[] array;
    public int Length { get; private set; }
    // Конструктор, создающий массив фиксированной длины
    public StringArray(int length)
    {
        array = new string[length];
        Length = length;
    }
    // Индексатор для доступа к элементам массива по индексу
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < Length)
                return array[index];
            else
                throw new IndexOutOfRangeException("Индекс за пределами массива.");
        }
        set
        {
            if (index >= 0 && index < Length)
                array[index] = value;
            else
                throw new IndexOutOfRangeException("Индекс за пределами массива.");
        }
    }
    // Метод для поэлементного сцепления двух массивов
    public static StringArray Concat(StringArray arr1, StringArray arr2)
    {
        int minLength = Math.Min(arr1.Length, arr2.Length);
        StringArray result = new StringArray(minLength);
        for (int i = 0; i < minLength; i++)
        {
            result[i] = arr1[i] + arr2[i]; // Сцепление строк по элементам
        }
        return result;
    }
    // Метод для слияния двух массивов с исключением повторяющихся элементов
    public static StringArray Merge(StringArray arr1, StringArray arr2)
    {
        List<string> uniqueStrings = new List<string>(arr1.array);
        foreach (string s in arr2.array)
        {
            if (!uniqueStrings.Contains(s))
            {
                uniqueStrings.Add(s);
            }
        }
        StringArray result = new StringArray(uniqueStrings.Count);
        for (int i = 0; i < uniqueStrings.Count; i++)
        {
            result[i] = uniqueStrings[i];
        }
        return result;
    }
    // Метод для вывода всего массива
    public void DisplayArray()
    {
        Console.WriteLine("Массив:");
        foreach (string s in array)
        {
            Console.WriteLine(s);
        }
    }
    // Метод для вывода отдельного элемента по индексу
    public void DisplayElement(int index)
    {
        try
        {
            Console.WriteLine($"Элемент с индексом {index}: {this[index]}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создание двух массивов строк
        StringArray arr1 = new StringArray(3);
        StringArray arr2 = new StringArray(3);
        // Инициализация массивов
        arr1[0] = "Привет";
        arr1[1] = "Мир";
        arr1[2] = "Программирование";
        arr2[0] = "Hello";
        arr2[1] = "World";
        arr2[2] = "Программирование";
        // Вывод исходных массивов
        Console.WriteLine("Первый массив:");
        arr1.DisplayArray();
        Console.WriteLine("Второй массив:");
        arr2.DisplayArray();
        // Поэлементное сцепление двух массивов
        StringArray concatenatedArray = StringArray.Concat(arr1, arr2);
        Console.WriteLine("Массив после поэлементного сцепления:");
        concatenatedArray.DisplayArray();
        // Слияние массивов с исключением повторяющихся элементов
        StringArray mergedArray = StringArray.Merge(arr1, arr2);
        Console.WriteLine("Массив после слияния с исключением повторяющихся элементов:");
        mergedArray.DisplayArray();
        // Вывод элемента по индексу
        Console.WriteLine("Вывод элемента по индексу:");
        arr1.DisplayElement(1);  // Вывод элемента с индексом 1
        // Попытка вывести элемент с некорректным индексом (для проверки исключения)
        Console.WriteLine("Попытка вывода элемента с некорректным индексом:");
        arr1.DisplayElement(5);  // Некорректный индекс
    }
}
