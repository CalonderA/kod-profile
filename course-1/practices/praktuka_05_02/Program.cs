using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Collections.Concurrent;
using System.Text.Json.Serialization;

var books = new List<Book>
{
   new Book {Title = "Война и мир", Author = "Толстой", Year = 1869},
    new Book { Title = "Преступление и наказание", Author = "Достоевский", Year = 1866 }

};


string Json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("books.json", Json);




string jsonFromFile = File.ReadAllText("books.json");
var booksFromFile = JsonSerializer.Deserialize<List<Book>>(jsonFromFile);

foreach (var book in booksFromFile)
{
    Console.WriteLine("$Название: {book.Title}, Автор: {book.Author}, Год: {book.Year}");

}

var optrions = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(books, optrions);
File.WriteAllText("books.json" , json);

public class Book
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("publication_year")]
    public int Year { get; set; }

  



}


