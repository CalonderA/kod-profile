// 1. Создайте базовый класс Animal с виртуальным методом:
public class Animal{
public virtual void Speak()
{
    Console.WriteLine("Животное издаёт звук.");
}
}

// 2. Создайте классы-наследники:
// Dog -- выводит "Собака говорит: Гав-гав!";
// Cat -- "Кошка говорит: Мяу!";
// Cow -- "Корова говорит: Муу!".


// Пример использования:
// Animal dog = new Dog();
// Animal cat = new Cat();
// Animal cow = new Cow();

// dog.Speak();
// cat.Speak();
// cow.Speak();


// Результат:
// Собака говорит: Гав-гав!
// Кошка говорит: Мяу!
// Корова говорит: Муу!


public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Животное издаёт звук.");
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

public class Cow : Animal
{
    public override void Speak()  
    {
        Console.WriteLine("Корова говорит: Муу!");
    }
}

public class Program
{
    public static void Main()
    {
        Animal dog = new Dog();
        Animal cat = new Cat();
        Animal cow = new Cow();

        dog.Speak();
        cat.Speak();
        cow.Speak();
    }
}



// Задание 2. «Транспорт»
// 1. Создайте базовый класс Transport:
// public class Transport
// {
//     public string Model { get; set; }

//     public virtual void Move()
//     {
//         Console.WriteLine($"{Model}: транспорт движется.");
//     }
// }

// 2. Создайте три наследника:
// Car — переопределите Move(): "Машина едет по дороге";
// Boat — "Лодка плывёт по воде";
// Plane — "Самолёт летит в небе".
// 3. Добавьте вызов base.Move() в одном из них (например, в Car), чтобы показать расширение поведения.
// Пример:
// Transport[] vehicles =
// {
//     new Car { Model = "Audi" },
//     new Boat { Model = "Yamaha" },
//     new Plane { Model = "Boeing" }
// };

// foreach (var v in vehicles)
// {
//     v.Move();
// }


// Результат:
// Audi: транспорт движется.
// Машина едет по дороге
// Yamaha: транспорт движется.
// Лодка плывёт по воде
// Boeing: транспорт движется.
// Самолёт летит в небе

// 1. Базовый класс (отдельно)
public class Transport
{
    public string Model { get; set; } 
    
    public virtual void Move()
    {
        Console.WriteLine($"{Model}: транспорт движется.");
    }
}


public class Car : Transport  
{
    public override void Move()
    {
        base.Move();              
        Console.WriteLine("Машина едет по дороге"); 
    }
}


public class Boat : Transport   
{
    public override void Move()
    {
        base.Move();              
        Console.WriteLine("Лодка плывёт по воде");
    }
}


public class Plane : Transport   
{
    public override void Move()
    {
        base.Move();             
        Console.WriteLine("Самолёт летит в небе");
    }
}

public class Program
{
    public static void Main()
    {
        
        Transport[] vehicles =
        {
            new Car { Model = "Audi" },
            new Boat { Model = "Yamaha" },
            new Plane { Model = "Boeing" }
        };

        
        foreach (var v in vehicles)
        {
            v.Move();
            Console.WriteLine(); 
        }
    }
}



// Задание 3


public abstract class Shape
{
    public abstract double GetArea();  
}


public class Circle : Shape
{
    public double Radius { get; set; }
    
    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}


public class Square : Shape
{
    public double Side { get; set; }
    
    public override double GetArea()
    {
        return Side * Side;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public override double GetArea()
    {
        return Width * Height;
    }
}


public class Program
{
    public static void Main()
    {
        
        Shape[] shapes =
        {
            new Circle { Radius = 5 },
            new Square { Side = 4 },
            new Rectangle { Width = 3, Height = 6 }
        };
        
       
        foreach (Shape shape in shapes)
        {
            double area = shape.GetArea();
            Console.WriteLine($"Площадь: {area:F2}");
        }
    }
}


//Задание 4

using System;

public class Instrument
{
    public virtual void Play()
    {
        Console.WriteLine("Инструмент издаёт звук");
    }
}

public class Guitar : Instrument
{
    public override void Play()
    {
        Console.WriteLine("Гитара играет аккорды");
    }
}

public class Piano : Instrument
{
    public override void Play()
    {
        Console.WriteLine("Пианино играет мелодию");
    }
}

public class Drum : Instrument
{
    public override void Play()
    {
        Console.WriteLine("Барабан бьёт ритм");
    }
}

public class Program
{
    public static void Main()
    {
        Instrument[] instruments =
        {
            new Guitar(),
            new Piano(),
            new Drum()
        };

        foreach (var i in instruments)
        {
            i.Play();
        }
    }
}


// Задание 5

using System;

public abstract class Character
{
    public string Name { get; set; }
    public abstract void Attack();
}

public class Warrior : Character
{
    public override void Attack()
    {
        Console.WriteLine("Воин атакует мечом!");
    }
}

public class Mage : Character
{
    public override void Attack()
    {
        Console.WriteLine("Маг выпускает огненный шар!");
    }
}

public class Archer : Character
{
    public override void Attack()
    {
        Console.WriteLine("Лучник стреляет из лука!");
    }
}

public class Program
{
    public static void Main()
    {
        Character[] team =
        {
            new Warrior { Name = "Алекс" },
            new Mage { Name = "Лия" },
            new Archer { Name = "Робин" }
        };

        foreach (var c in team)
        {
            Console.Write($"{c.Name}: ");
            c.Attack();
        }
    }
}
