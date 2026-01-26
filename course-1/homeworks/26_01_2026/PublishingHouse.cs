namespace LibrarySystem
{
    public class PublishingHouse
    {
        public string Name { get; set; }

        public PublishingHouse(string name)
        {
            Name = name;
        }

        public void ShowInfo()
        {
            System.Console.WriteLine($"Издательство: {Name}");
        }
    }
}