
public abstract class Worker
{
    public string Name { get; set; } 

    public abstract void Work();

    public void ShowInfo()
    {
        Console.WriteLine($"Работник: {Name}");
    }
}

public class Manager : Worker
{

    public Manager() { }

    public Manager(string name)
    {
        Name = name;
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} планирует задачи");
    }
}

public class Developer : Worker
{
    public Developer() { }

    public Developer(string name)
    {
        Name = name;
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} пишет код");
    }
}


Worker[] workers = {
    new Manager { Name = "Анна" },
    new Developer { Name = "Иван" }
};