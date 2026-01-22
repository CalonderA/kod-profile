//Задание 1
//1. Создайте интерфейс IPlayable, который описывает поведение всех музыкальных инструментов — то есть возможность играть.
//public interface IPlayable
//{
//    void Play();
//}

//2.Создайте три класса, реализующие интерфейс IPlayable:
//Guitar — метод Play() выводит "Гитара играет аккорды";
//Piano — метод Play() выводит "Пианино играет мелодию";
//Drum — метод Play() выводит "Барабан отбивает ритм".
//3. Создайте массив инструментов и вызовите метод Play() у каждого:
//IPlayable[] instruments =
//{
//    new Guitar(),
//    new Piano(),
//    new Drum()
//};

//foreach (var i in instruments)
//    i.Play();

public interface IPlayable
{
    void Play();
}
public class Guitar : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Гитара играет аккорды");
    }
}
public class Piano : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Пианино играет мелодию");
    }
}

public class Drum : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Барабан отбивает ритм");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
       
        IPlayable[] instruments =
        {
            new Guitar(),
            new Piano(),
            new Drum()
        };

        foreach (var i in instruments)
            i.Play();
    }
}