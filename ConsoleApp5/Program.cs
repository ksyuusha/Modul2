using System;
// Класс TemperatureSensor, генерирующий событие TemperatureChanged
public class TemperatureSensor
{
    // Делегат для события
    public delegate void TemperatureChangedHandler(object sender, TemperatureChangedEventArgs e);
    // Событие TemperatureChanged
    public event TemperatureChangedHandler TemperatureChanged;
    private double _currentTemperature;
    // Свойство для установки и получения текущей температуры
    public double CurrentTemperature
    {
        get { return _currentTemperature; }
        set
        {
            if (_currentTemperature != value)
            {
                _currentTemperature = value;
                OnTemperatureChanged(new TemperatureChangedEventArgs(_currentTemperature));
            }
        }
    }
    // Метод для вызова события TemperatureChanged
    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this, e);  // Если есть подписчики, генерируем событие
    }
}
// Класс для передачи данных о событии
public class TemperatureChangedEventArgs : EventArgs
{
    public double NewTemperature { get; private set; }
    public TemperatureChangedEventArgs(double newTemperature)
    {
        NewTemperature = newTemperature;
    }
}
// Класс Thermostat, подписывающийся на событие TemperatureChanged
public class Thermostat
{
    private double _threshold;
    public Thermostat(double threshold)
    {
        _threshold = threshold;
    }
    // Метод, который реагирует на изменение температуры
    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        if (e.NewTemperature < _threshold)
        {
            Console.WriteLine($"Температура {e.NewTemperature}°C ниже порога {_threshold}°C. Включаем отопление.");
        }
        else
        {
            Console.WriteLine($"Температура {e.NewTemperature}°C выше порога {_threshold}°C. Выключаем отопление.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создаем объект термодатчика
        TemperatureSensor sensor = new TemperatureSensor();
        // Создаем объект термостата с порогом в 22°C
        Thermostat thermostat = new Thermostat(22);
        // Подписываем термостат на событие изменения температуры
        sensor.TemperatureChanged += thermostat.OnTemperatureChanged;
        // Изменяем температуру
        sensor.CurrentTemperature = 20;  // Температура ниже порога — включение отопления
        sensor.CurrentTemperature = 23;  // Температура выше порога — выключение отопления
    }
}