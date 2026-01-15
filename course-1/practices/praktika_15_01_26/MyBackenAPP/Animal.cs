using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n\n5:");
        var d = new Dog("Шарик");
        var c = new Cat("Мурка");
        var e = new Elephant("Дамбо");
        d.Bark();
        c.Meow();
        e.Trumpet();

        Console.WriteLine("\n\n6:");
        Animal[] zoo = 
        {
            new Dog("Шарик"),
            new Cat("Мурка"),
            new Elephant("Дамбо"),
            new Animal("Неопознанный")
        };

        foreach (var animal in zoo)
        {
            animal.MakeSound();
        }

        Console.WriteLine("\n=== Уровень 2 ===");

        Console.WriteLine("\n\n7:");
        var zooPark = new Zoo(5);
        zooPark.Add(new Dog("Рекс"));
        zooPark.Add(new Cat("Снежок"));
        zooPark.Add(new Elephant("Бану"));

        Console.WriteLine("\n=== Звуки ===");
        zooPark.MakeAllSounds();

        Console.WriteLine("\n=== Кормим ===");
        zooPark.FeedAll();
    }
}