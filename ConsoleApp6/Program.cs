using System;
public class BankAccount
{
    // Поля класса
    public string AccountNumber { get; private set; }
    public string Owner { get; set; }
    public decimal Balance { get; private set; }
    // Конструктор для инициализации счета
    public BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = initialBalance;
    }
    // Метод для пополнения счета
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"На счет {AccountNumber} добавлено {amount}. Текущий баланс: {Balance}");
        }
        else
        {
            Console.WriteLine("Сумма пополнения должна быть больше 0.");
        }
    }
    // Метод для снятия средств со счета
    public void Withdraw(decimal amount)
    {
        if (amount > 0)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Со счета {AccountNumber} снято {amount}. Текущий баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете для выполнения операции.");
            }
        }
        else
        {
            Console.WriteLine("Сумма снятия должна быть больше 0.");
        }
    }
    // Метод для получения информации о счете
    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Номер счета: {AccountNumber}, Владелец: {Owner}, Баланс: {Balance}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Создаем объекты класса BankAccount
        BankAccount account1 = new BankAccount("123456789", "Иван Иванов", 5000m);
        BankAccount account2 = new BankAccount("987654321", "Мария Петрова", 10000m);
        // Выводим информацию о счетах
        account1.DisplayAccountInfo();
        account2.DisplayAccountInfo();
        // Пополнение и снятие средств
        account1.Deposit(1500m);
        account1.Withdraw(2000m);
        account1.Withdraw(6000m); // Недостаточно средств
        account2.Deposit(3000m);
        account2.Withdraw(5000m);
        // Повторный вывод информации о счетах
        account1.DisplayAccountInfo();
        account2.DisplayAccountInfo();
    }
}
