public class Library
{
    public string Name { get; set; }

    public List<Book> Books { get; set; }
}

var library = new Library
{
    Name = "Городская библиотека",
    Books = new List<Book>
    {
        new Book { Title = "Война и мир", Author = "Толстой", Year = 1869 },
        new Book { Title = "Преступление и наказание", Author = "Достоевский", Year = 1866 }
    }
};
var options = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(library, options);
File.WriteAllText("library.json", json);

string jsonFromFile = File.ReadAllText("library.json");
var libraryFromFile = JsonSerializer.Deserialize<Library>(jsonFromFile);

Console.WriteLine($"Библиотека: {libraryFromFile.Name}");
foreach (var b in libraryFromFile.Books)
{
    Console.WriteLine($"Книга: \"{b.Title}\", автор: {b.Author}, год: {b.Year}");
}