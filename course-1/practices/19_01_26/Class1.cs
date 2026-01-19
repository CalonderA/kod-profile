//Задание 2
//1. Создайте абстрактный класс Animal:
//конструктор Animal(string name) — сохраняет Name и пишет "Создано животное: {Name}";
//метод Eat() — "{Name} ест.";
//абстрактный метод MakeSound().


//2. Создайте классы наследники:
//Для класса Dog реализуйте метод MakeSound(): "{Name}: Гав-гав!";
//Для класса Cat реализуйте метод MakeSound(): "{Name}: Мяу!".


//3.Создайте массив Animal[] с Dog("Рекс"), Cat("Мурка"), пройдитесь циклом: вызывая для каждого метод Eat() затем MakeSound().


public abstract class Animal
{
    public string Name { get; }

    protected Animal(string name)
    {
        Name = name;
        Console.WriteLine($"Создано животное по имени {Name}");
    }

    public void  Eat()
    {
        Console.WriteLine($"{Name} жрет");
    }

    public abstract void MakeSound();
}

public class Dog : Animal
{
   

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}: Гав-гав!");
    }
}

public class Cat : Animal
{
  

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}: Мяу!");
    }
}

class Program
{
    static void main(string[] args)
    {
        Animal[] animals = new Animal[] {
            new Dog("Рекс"),
            new Cat("Мурка"),
            new Dog("Бобик"),
            new Cat("Барсик")
        };

        foreach (Animal animal in animals)
        {
            animal.Eat();
            animal.MakeSound();
            animal.WriteLine();
        }
}