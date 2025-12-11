// 1. Создайте метод SayHello(), который выводит на экран строку "Привет, мир!".
// 2. Вызовите его 3 раза.
void SayHello()
{
    Console.WriteLine("Привет, мир!");
    Console.WriteLine("Привет, мир!");
    Console.WriteLine("Привет, мир!");
}
SayHello();

// 1. Создайте метод Greet(string name), который выводит "Привет, <имя>!".
// 2. Вызовите его для разных имён (например, «Саша», «Ярослав», «Анна»).

void Greet(string name)
{
    Console.WriteLine($"Привет, {name}!");
}
Greet("Саша");


// Задание 3: Информация о пользователе
// 1. Создайте метод PrintPerson(string name, int age, string city), который выводит информацию о человеке:
// Имя: Егор Возраст: 15  Город: Москва

// 2. Вызовите его для двух разных людей.


void PrintPerson(string name, int age, string city)
{
    Console.WriteLine($"Имя: {name} Возраст: {age} Город: {city}");
}
PrintPerson("Егор",15,"Москва");


// Создайте метод PrintPerson(string name, int age = 18, string hobby = "Не указано").
// Если передать все параметры, то выводить все данные.
// Если передать только имя, то остальные значения берутся по умолчанию.


void PrintPerson(string name, int age = 18, string hobby = "Не указано")
{
    Console.WriteLine($"Имя: {name} Возраст: {age} Город: {hobby}");
}
PrintPerson("Егор",18,"машинки");


// Задание 6. Метод-калькулятор
// Создайте методы:
// Add(int a, int b) — возвращает сумму,
// Subtract(int a, int b) — разность,
// Multiply(int a, int b) — произведение,
// Divide(int a, int b) — частное (проверьте деление на 0).
// Сделайте программу, которая:
// Запрашивает у пользователя два числа и операцию (+, -, *, /).
// Вызывает соответствующий метод.
// Выводит результат.



 using System;

class Program
{

    static void Add(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"{a} + {b} = {result}");
    }

    static void Subtract(int a, int b)
    {
        int result = a - b;
        Console.WriteLine($"{a} - {b} = {result}");
    }
    
    static void Multiply(int a, int b)
    {
        int result = a * b;
        Console.WriteLine($"{a} * {b} = {result}");
    }
    
    static void Divide(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль!");
        }
        else
        {
            int result = a / b;
            Console.WriteLine($"{a} / {b} = {result}");
        }
    }
    
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Введите второе число: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Введите операцию (+, -, *, /): ");
        char operation = Convert.ToChar(Console.ReadLine());
        
        if (operation == '+')
        {
            Add(num1, num2);
        }
        else if (operation == '-')
        {
            Subtract(num1, num2);
        }
        else if (operation == '*')
        {
            Multiply(num1, num2);
        }
        else if (operation == '/')
        {
            Divide(num1, num2);
        }
        else
        {
            Console.WriteLine("Неизвестная операция!");
        }
        
    }
}

/////

static int Multiply(int a, int b) // принимает два целых числа
{
    return a * b;
}

static int Multiply(int a, int b, int c) // принимает два дробных числа
{
    return a * b * c;
}

static double Multiply(double a, double b) // принимает три целых числа
{
    return a * b;
}
Console.WriteLine(Multiply(2, 3));
Console.WriteLine(Multiply(2, 3, 4));
Console.WriteLine(Multiply(2.5, 4.0));