using System;
using System.Collections.Generic;
using System.Text;

namespace _26_01_2026
{
    public interface ILibraryManagement
    {
        void AddBook(Book book);
        bool RemoveBook(Book book);
        List<Book> SearchByAuthor(string author);
        void ListBooks();
    }
    public class Library : ILibraryManagement
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"Книга \"{book.Title}\" добавлена в библиотеку.");
        }

        public bool RemoveBook(Book book)
        {
            bool removed = _books.Remove(book);
            if (removed)
                Console.WriteLine($"Книга \"{book.Title}\" удалена из библиотеки.");
            return removed;
        }

        public List<Book> SearchByAuthor(string author)
        {
            return _books.Where(b => b.Author == author).ToList();
        }

        public void ListBooks()
        {
            Console.WriteLine("Список книг в библиотеке:");
            foreach (var book in _books)
            {
                book.ShowInfo();
            }
        }

        public void IssueBook(Book book, Reader reader)
        {
            if (_books.Contains(book))
            {
                reader.BorrowBook(book);
                _books.Remove(book);
            }
            else
            {
                Console.WriteLine($"Книга \"{book.Title}\" сейчас недоступна.");
            }
        }

        public void ReturnBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"Книга \"{book.Title}\" возвращена в библиотеку.");
        }
    }
}
