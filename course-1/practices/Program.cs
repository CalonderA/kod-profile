Calonder, [15.12.2025 19:40]
// Задание 1. Животные
// Создайте базовый класс Animal, в котором есть:
// свойство Name;
// метод Eat(), который выводит:
//  "Животное ест.".
// Создайте два дочерних класса:
// Dog — добавь метод Bark(), который выводит "Собака лает.";
// Cat — добавь метод Meow(), который выводит "Кошка мяукает.".
// Пример вызова:
// var dog = new Dog();
// dog.Name = "Шарик";
// dog.Eat();
// dog.Bark();

// var cat = new Cat();
// cat.Name = "Мурка";
// cat.Eat();
// cat.Meow();

// Ожидаемый результат:
// Шарик ест.
// Собака лает.
// Мурка ест.
// Кошка мяукает.

public class Animal
{
    public string Name { get; set; }
    public void Eat()
    {
        Console.WriteLine($"{Name} ест");
    }
}
public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{Name} лает");
    }

}

public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine($"{Name} мяукает");
    }

}
public class Program
{
    public static void Main()
    {
        var dog = new Dog();
        dog.Name = "Шарик";
        dog.Eat();   // метод родителя
        dog.Bark();  // метод потомка
        var cat = new Cat();
        cat.Name = "Мурка";
        cat.Eat();
        cat.Meow();

    }
}

// Задание 2. Говорящие животные

// В базовом классе Animal добавьте виртуальный метод:
// public virtual void Speak()
// {
//     Console.WriteLine("Животное издаёт звук");
// }

// В классах Dog и Cat переопределите этот метод (override):
// Dog выводит: "Собака говорит: Гав-гав!";
// Cat выводит: "Кошка говорит: Мяу!"
// Пример:
// var dog = new Dog();
// var cat = new Cat();

// dog.Speak();
// cat.Speak();

public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Животное издаёт звук");
    }
}
public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Собака говорит: Гав-гав!");
    }
}
public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Кошка говорит: Мяу!");
    }
}
public class Program
{
    public static void Main()
    {
        var dog = new Dog();
        var cat = new Cat();

        dog.Speak();
        cat.Speak();

    }
}

// Задание 2. Говорящие животные

// В базовом классе Animal добавьте виртуальный метод:
// public virtual void Speak()
// {
//     Console.WriteLine("Животное издаёт звук");
// }

// В классах Dog и Cat переопределите этот метод (override):
// Dog выводит: "Собака говорит: Гав-гав!";
// Cat выводит: "Кошка говорит: Мяу!"
// Пример:
// var dog = new Dog();
// var cat = new Cat();

// dog.Speak();
// cat.Speak();

public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Животное издаёт звук");
    }
}
public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Собака говорит: Гав-гав!");
    }
}
public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Кошка говорит: Мяу!");
    }
}
public class Program
{
    public static void Main()
    {
        var dog = new Dog();
        var cat = new Cat();

        dog.Speak();
        cat.Speak();

    }
}


// Задание 4. Конструктор с base
// В классе Animal добавьте конструктор:
// public Animal(string name)
// {
//     Name = name;
//     Console.WriteLine($"Создано животное: {Name}");
// }


// В классе Cat добавьте конструктор:
// public Cat(string name) : base(name)
// {
//     Console.WriteLine($"Создана кошка по имени {Name}");
// }


// Пример:
// var cat = new Cat("Мурка");


// Ожидаемый результат:
// Создано животное: Мурка
// Создана кошка по имени Мурка


public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
        Console.WriteLine($"Создано животное по имени {name}");
    }
}

public class Cat :Animal
{
    public Cat(string name) : base(name)
    {
        Console.WriteLine($"Создана кошка по имени {Name}");
    }

}
public class Program
{
    public static void Main()
    {
        var cat = new Cat("Мурка");
    }
}


// Задание 5. Многоуровневое наследование
// Создайте три класса:
// Transport — метод Drive() → "Транспорт движется";
// Car (наследуется от Transport) → переопредели метод Drive() → "Машина едет по дороге";
// ElectricCar (наследуется от Car) → переопредели метод Drive() → "Электромобиль тихо едет на батарее".


// Пример:
// var transport = new Transport();
// var car = new Car();
// var tesla = new ElectricCar();

// transport.Drive();
// car.Drive();
// tesla.Drive();


// Ожидаемый результат:
// Транспорт движется
// Машина едет по дороге
// Электромобиль тихо едет на батарее

public class Transport
{
    public virtual void Drive()
    {
        Console.WriteLine("Транспорт движется");
    }
}
public class Car : Transport
{
    public override void Drive()
    {
        Console.WriteLine("Машина едет по дороге");
    }
}
public class ElectricCar : Transport
{
    public override void Drive()
    {
        Console.WriteLine("Электромобиль тихо едет на батарее");
    }
}
public class Program
{
    public static void Main()
    {
        var transport = new Transport();
        var car = new Car();
        var tesla = new ElectricCar();

        transport.Drive();
        car.Drive();
        tesla.Drive();


    }
}