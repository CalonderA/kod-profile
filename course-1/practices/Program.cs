int a, b, c;

a = int.Parse(Console.ReadLine());
b = int.Parse(Console.ReadLine());
c = int.Parse(Console.ReadLine());

if (a >= b && a >= c)
{
    Console.WriteLine("Наибольшее число: " + a);
}
else if (b >= a && b >= c)  
{
    Console.WriteLine("Наибольшее число: " + b);
}
else
{
    Console.WriteLine("Наибольшее число: " + c);
}


int grade =  int.Parse(Console.ReadLine());
if (grade < 2 )
{
    Console.WriteLine("Очень плохо");
}
else if (grade == 3)
{
    Console.WriteLine("Удовлетворительно");
}
else if (grade == 4 )
{
    Console.WriteLine("уже не плохо");
} 
else if ( grade == 5)
{
    Console.WriteLine("Отлично! Молодец");
}

int a = -1, b = -2;
if (a > 0 && b >  0)
{
    Console.WriteLine("Оба числа положительные");
}
else if (a < 0 && b <  0)
{
    Console.WriteLine("a не положительное");
} 
else
{
    Console.WriteLine("Хотя бы одно число положительное");
}


int num = 7;
if (num%2 == 0)
{
    Console.WriteLine("Четное");
}
else 
{
    Console.WriteLine("Нечетное");
}


int age = int.Parse(Console.ReadLine());
if (age < 18)
{
    Console.WriteLine("Вы несовершеннолетний");
}
else 
{
    Console.WriteLine("тебе есть 18");
}


int number = -1;
if ( number > 0)
{
    Console.WriteLine("Число положительное");
}
else if (number < 0)
{
    Console.WriteLine("Число отрицательное");
} else if (number == 0)
{
    Console.WriteLine("Число равно нулю");
}

Console.WriteLine(number);