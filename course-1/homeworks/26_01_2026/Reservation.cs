using System;

namespace LibrarySystem
{
    public class Reservation
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Reservation(Book book, Reader reader, DateTime reservationDate, DateTime expiryDate)
        {
            Book = book;
            Reader = reader;
            ReservationDate = reservationDate;
            ExpiryDate = expiryDate;
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Резервирование: Книга \"{Book.Title}\" зарезервирована {Reader.Name}");
            Console.WriteLine($"  Дата резервирования: {ReservationDate:dd.MM.yyyy}");
            Console.WriteLine($"  Действует до: {ExpiryDate:dd.MM.yyyy}");
            Console.WriteLine($"  Статус: {(IsExpired() ? "Просрочено" : "Активно")}");
        }
    }
}
