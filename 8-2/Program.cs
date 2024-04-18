using System;

// Интерфейс для управления банкоматом
public interface IBankomat
{
    void LoadMoney(int money);
    bool Moneyout(int amount);
    void Ostatok();
}

// Абстрактный класс для банкомата
public abstract class Bankomat : IBankomat
{
    protected string atmId;
    protected int allmoney;
    protected int minmoneyout;
    protected int maxmoneyout;

    public Bankomat(string id, int min, int max)
    {
        atmId = id;
        minmoneyout = min;
        maxmoneyout = max;
        allmoney = 0;
    }

    // Метод для загрузки купюр в банкомат
    public void LoadMoney(int money)
    {
        allmoney += money;
    }

    // Метод для снятия определенной суммы денег
    public bool Moneyout(int amount)
    {
        if (amount < minmoneyout || amount > maxmoneyout)
        {
            Console.WriteLine("Недопустимая сумма для снятия.");
            return false;
        }

        if (amount > allmoney)
        {
            Console.WriteLine("В банкомате недостаточно средств.");
            return false;
        }

        allmoney -= amount;
        Console.WriteLine($"Сумма {amount} успешно снята.");
        return true;
    }

    // Метод для отображения оставшейся в банкомате суммы
    public void Ostatok()
    {
        Console.WriteLine($"Оставшаяся сумма в банкомате: {allmoney}");
    }

    // Деструктор
    ~Bankomat()
    {
        Console.WriteLine("Работа банкомата завершена.");
    }
}

// Класс, представляющий реальный банкомат
public class BankomatATM : Bankomat
{
    public BankomatATM(string id, int min, int max) : base(id, min, max)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите идентификационный номер банкомата:");
        string id = Console.ReadLine();

        BankomatATM atm = new BankomatATM(id, 10, 1000);
        Console.WriteLine("Введите сумму коротую хотите пополнить:");
        atm.LoadMoney(Convert.ToInt32(Console.ReadLine()));
        atm.Ostatok();
        Console.WriteLine("Введите сумму коротую хотите снять:");
        atm.Moneyout(Convert.ToInt32(Console.ReadLine()));
        atm.Ostatok();
        Console.WriteLine("Введите сумму коротую хотите снять:");
        atm.Moneyout(Convert.ToInt32(Console.ReadLine()));
        atm.Ostatok();
    }
}