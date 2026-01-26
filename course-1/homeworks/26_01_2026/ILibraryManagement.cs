using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
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
        private List<Reservation> _reservations = new List<Reservation>();

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
                string reservationInfo = "";
                var reservation = _reservations.FirstOrDefault(r => r.Book == book && !r.IsExpired());
                if (reservation != null)
                {
                    reservationInfo = $" [Зарезервирована: {reservation.Reader.Name}]";
                }
                Console.WriteLine($"  - {book.Title} ({book.Author}){reservationInfo}");
            }
        }

        public void IssueBook(Book book, Reader reader)
        {
            // Проверяем, зарезервирована ли книга другим читателем
            var activeReservation = _reservations.FirstOrDefault(r => r.Book == book && !r.IsExpired());

            if (activeReservation != null)
            {
                if (activeReservation.Reader == reader)
                {
                    // Читатель забирает свою зарезервированную книгу
                    _reservations.Remove(activeReservation);
                    Console.WriteLine($"Снята резервация для книги \"{book.Title}\"");
                }
                else
                {
                    Console.WriteLine($"Книга \"{book.Title}\" зарезервирована другим читателем ({activeReservation.Reader.Name}). Выдача невозможна.");
                    return;
                }
            }

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

            // Удаляем все резервации для этой книги (они становятся неактуальными)
            var bookReservations = _reservations.Where(r => r.Book == book).ToList();
            foreach (var reservation in bookReservations)
            {
                _reservations.Remove(reservation);
            }

            Console.WriteLine($"Книга \"{book.Title}\" возвращена в библиотеку.");
        }

        // Метод для резервирования книги
        public bool ReserveBook(Book book, Reader reader, int reserveDays = 3)
        {
            if (!_books.Contains(book))
            {
                Console.WriteLine($"Книга \"{book.Title}\" отсутствует в библиотеке.");
                return false;
            }

            // Проверяем, не зарезервирована ли уже книга
            var existingReservation = _reservations.FirstOrDefault(r => r.Book == book && !r.IsExpired());
            if (existingReservation != null)
            {
                Console.WriteLine($"Книга \"{book.Title}\" уже зарезервирована читателем {existingReservation.Reader.Name}.");
                return false;
            }

            DateTime reservationDate = DateTime.Now;
            DateTime expiryDate = reservationDate.AddDays(reserveDays);

            Reservation newReservation = new Reservation(book, reader, reservationDate, expiryDate);
            _reservations.Add(newReservation);

            Console.WriteLine($"Книга \"{book.Title}\" зарезервирована читателем {reader.Name} до {expiryDate:dd.MM.yyyy}");
            return true;
        }

        // Метод для отмены резервирования
        public bool CancelReservation(Book book, Reader reader)
        {
            var reservation = _reservations.FirstOrDefault(r => r.Book == book && r.Reader == reader);

            if (reservation != null)
            {
                _reservations.Remove(reservation);
                Console.WriteLine($"Резервирование книги \"{book.Title}\" отменено для читателя {reader.Name}.");
                return true;
            }

            Console.WriteLine($"Активное резервирование книги \"{book.Title}\" для читателя {reader.Name} не найдено.");
            return false;
        }

        // Метод для просмотра всех резервирований
        public void ListReservations()
        {
            Console.WriteLine("Список активных резервирований:");
            foreach (var reservation in _reservations.Where(r => !r.IsExpired()))
            {
                reservation.ShowInfo();
            }

            Console.WriteLine("\nПросроченные резервирования:");
            foreach (var reservation in _reservations.Where(r => r.IsExpired()))
            {
                reservation.ShowInfo();
            }
        }

        // Метод для очистки просроченных резервирований
        public void ClearExpiredReservations()
        {
            int removedCount = _reservations.RemoveAll(r => r.IsExpired());
            Console.WriteLine($"Удалено {removedCount} просроченных резервирований.");
        }
    }
}