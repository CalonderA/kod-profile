//Задание 3

//1. Создайте абстрактный класс Transport со следующими методами:
//public void Move(), который вызывает Start(), MoveCore(), Stop();
//protected void Start()/ Stop(), которые выводят "Старт/Стоп";
//protected abstract void MoveCore().


//2.Создайте классы наследники:
//Для класса Car реализуйте метод MoveCore(): "Машина едет по дороге";
//Для класса Boat реализуйте метод MoveCore(): "Лодка плывёт по воде".
//3.Проверьте работу следующим способом в Program.cs:

//Transport[] t = { new Car(), new Boat() };
//foreach (var x in t) x.Move();

public abstract class Transport
{
    public void Move() // общий сценарий
    {
        Start();
        MoveCore(); 
        Stop();
    }

    protected void Start() => Console.WriteLine("Транспорт начинает движение");
    protected abstract void MoveCore();
    protected void Stop() => Console.WriteLine("Транспорт останавливается");
}
public class Car : Transport
{
    protected override void MoveCore() => Console.WriteLine("Машина едет по дороге");
}
public class Boat : Transport
{
    protected override void MoveCore() => Console.WriteLine("Лодка плывёт по воде");
}

class Program
{
    static void Main(string[] args)
    {
        Transport[] t = { new Car(), new Boat() };
        foreach (var x in t)
        {
            x.Move();
            Console.WriteLine(); 
        }
    }
}