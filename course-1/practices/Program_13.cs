// Задание 1. Класс Person
// Создайте класс Person, который хранит имя и возраст.
// Поля должны быть приватными.
// Доступ к ним осуществляется через свойства.
// Возраст не может быть отрицательным.
// Имя нельзя задать пустым.


// Пример:
// var p = new Person();
// p.Name = "Алиса";
// p.Age = 25;
// p.Age = -5; // сообщение об ошибке

public class Person
{
    private int age; // скрытое поле
    private string name;

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0)
                age = value;
            else
                Console.WriteLine("Возраст не может быть отрицательным!");
        }
    }
    
     public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

public class Program
{
    public static void Main()
    {
      var p = new Person();
p.Name = "Алиса";
p.Age = 25;
p.Age = -5; // сообщение об ошибке

    }
}

// Задание 2. Класс BankAccount
// Создайте класс BankAccount:
// приватное поле balance;
// методы:
// Deposit(decimal amount) — пополнить счёт;
// Withdraw(decimal amount) — снять деньги (если хватает средств);
// ShowBalance() — показать текущий баланс.
// Проверьте, чтобы нельзя было снять больше, чем есть на счёте

public class BankAccount
{
    private decimal balance; // скрытое поле

    public void Deposit(decimal amount)
    {
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= balance)
            balance -= amount;
        else
            Console.WriteLine("Недостаточно средств!");
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Баланс: {balance}");
    }
}
public class Program
{
    public static void Main()
    {
        var account = new BankAccount();
        account.Deposit(1000);
        account.Withdraw(500);
        account.Withdraw(600);
        account.ShowBalance();

    }
}

// Задание 3. Класс Thermometer
// Создайте класс Thermometer:
// приватное поле temperatureCelsius;
// свойство TemperatureCelsius (не ниже -273);
// добавьте свойство TemperatureFahrenheit, которое вычисляется по формуле (C * 9 / 5) + 32.
// Пример:
// var t = new Thermometer();
// t.TemperatureCelsius = 25;
// Console.WriteLine(t.TemperatureFahrenheit); // 77

public class Thermometer
{
    private double temperatureCelsius; // скрытое поле

    public double TemperatureCelsius
    {
        get {return temperatureCelsius; }
        set
        {
            if(value >= -273) temperatureCelsius = value;
        
        }

    }

    public double TemperatureFahrenheit
    {
        get
        {
            return (temperatureCelsius * 9 /5)+32;
        }
    }
}
public class Program
{
    public static void Main()
    {
        var t = new Thermometer();
t.TemperatureCelsius = 26;
Console.WriteLine(t.TemperatureFahrenheit); // 77

    }
}

// Задание 4. Класс Animal
// 1. Создайте базовый класс Animal с полем protected energy = 100 и методом Eat() (+10 энергии).
// 2. Создайте класс Dog, который наследуется от Animal и имеет метод Run() (–20 энергии).
// 3. Проверьте, как меняется энергия при вызовах методов.

public class Animal
{
    protected int energy = 100;
    
    public void Eat()
    {
        energy += 10;
    }

    public class Dog : Animal
    {
        public void Run()
        {
            if(energy >= 20)
            {
                energy -= 20;
            }
        }
    }
    public void ShowEnerge()
    {
        Console.WriteLine($"Энергия собаки: {energy}");
    }

    public class Program
{
    public static void Main()
    {
       Dog myDog = new Dog();
       myDog.Eat();
       myDog.Run();
       myDog.Run();
       myDog.Run();
       myDog.ShowEnerge();

    }
}
}