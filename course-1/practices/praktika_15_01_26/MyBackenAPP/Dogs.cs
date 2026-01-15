public class Dog : Animal
{
    public Dog() : base("Собака") { }
    public Dog(string name) : base(name) { }

    public void Bark()
    {
        Console.WriteLine($"{Name} пытается лаять...");
        MakeSound();
    }

    public override void MakeSound()
    {
        base.MakeSound();
        Console.WriteLine($"{Name}: Гав-гав!");
    }
}