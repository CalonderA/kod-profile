using System;

namespace LibrarySystem
{
    public class Book
    {
        private string _title;
        private string _author;
        private int _year;
        private int _pages;

        public string Title
        {
            get => _title;
            set
            {
                if (!string.IsNullOrEmpty(value)) _title = value;
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                if (!string.IsNullOrEmpty(value)) _author = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value > 0) _year = value;
            }
        }

        public int Pages
        {
            get => _pages;
            set
            {
                if (value > 0) _pages = value;
            }
        }

        public Book(string title, string author, int year, int pages)
        {
            Title = title;
            Author = author;
            Year = year;
            Pages = pages;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Книга: {Title}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
        }
    }

    public class Textbook : Book
    {
        public string Subject { get; set; }

        public Textbook(string title, string author, int year, int pages, string subject)
            : base(title, author, year, pages)
        {
            Subject = subject;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Учебник: {Title}, Предмет: {Subject}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
        }
    }

    public class FictionBook : Book
    {
        public string Genre { get; set; }

        public FictionBook(string title, string author, int year, int pages, string genre)
            : base(title, author, year, pages)
        {
            Genre = genre;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Художественная книга: {Title}, Жанр: {Genre}, Автор: {Author}, Год: {Year}, Страниц: {Pages}");
        }
    }
}
