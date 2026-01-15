public class Cat : Animal
{
    public Cat() : base("Кошка") { }
    public Cat(string name) : base(name) { }

    public void Meow()
    {
        Console.WriteLine($"{Name} пытается мяукать...");
        MakeSound();
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name}: Мяу!");
    }
}