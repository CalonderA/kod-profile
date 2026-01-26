using System;
using LibrarySystem;

namespace _26_01_2026
{
    class Program
{
    static void Main()
    {
        Console.WriteLine("=== ТЕСТИРОВАНИЕ СИСТЕМЫ БИБЛИОТЕКИ ===\n");
        
        Library library = new Library();

        // Создаем книги
        Textbook t1 = new Textbook("Математика 101", "Иванов", 2020, 300, "Математика");
        Textbook t2 = new Textbook("Физика для начинающих", "Петров", 2021, 250, "Физика");
        FictionBook f1 = new FictionBook("Война и мир", "Толстой", 1869, 1200, "Роман");
        FictionBook f2 = new FictionBook("Мастер и Маргарита", "Булгаков", 1967, 480, "Фэнтези");

        // Добавляем книги в библиотеку
        Console.WriteLine("1. Добавление книг в библиотеку:");
        library.AddBook(t1);
        library.AddBook(t2);
        library.AddBook(f1);
        library.AddBook(f2);
        
        Console.WriteLine("\n2. Список книг в библиотеке:");
        library.ListBooks();

        // Создаем читателей
        Reader reader1 = new Reader("Алексей", 1);
        Reader reader2 = new Reader("Мария", 2);

        // Тестируем резервирование
        Console.WriteLine("\n3. Тестирование системы резервирования:");
        library.ReserveBook(t1, reader1, 2);  // Алексей резервирует учебник
        library.ReserveBook(f1, reader2, 1);  // Мария резервирует художественную книгу
        
        // Попытка зарезервировать уже зарезервированную книгу
        library.ReserveBook(t1, reader2);     // Мария пытается зарезервировать ту же книгу

        Console.WriteLine("\n4. Список резервирований:");
        library.ListReservations();

        // Попытка выдачи зарезервированной книги другому читателю
        Console.WriteLine("\n5. Попытка выдачи зарезервированной книги другому читателю:");
        library.IssueBook(t1, reader2);  // Мария пытается взять книгу, зарезервированную Алексеем

        // Выдача книги читателю, который ее зарезервировал
        Console.WriteLine("\n6. Выдача книги читателю, который ее зарезервировал:");
        library.IssueBook(t1, reader1);  // Алексей забирает свою зарезервированную книгу
        
        reader1.ShowBorrowedBooks();

        Console.WriteLine("\n7. Список книг после выдачи:");
        library.ListBooks();

        // Отмена резервирования
        Console.WriteLine("\n8. Отмена резервирования:");
        library.CancelReservation(f1, reader2);
        
        // Теперь книга доступна для выдачи
        library.IssueBook(f1, reader1);
        reader1.ShowBorrowedBooks();

        // Возврат книги
        Console.WriteLine("\n9. Возврат книги в библиотеку:");
        library.ReturnBook(t1);
        library.ListBooks();

        // Тестирование абстрактного класса
        Console.WriteLine("\n10. Тестирование абстрактного класса:");
        Publication pub1 = new BookPublication(t1);
        Publication pub2 = new BookPublication(f2);
        pub1.GetInfo();
        pub2.GetInfo();

        // Очистка просроченных резервирований (симулируем просрочку)
        Console.WriteLine("\n11. Очистка просроченных резервирований:");
        library.ClearExpiredReservations();

        Console.WriteLine("\n=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
    }
}
}
