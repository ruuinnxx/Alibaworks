using System;
using System.Collections.Generic;

namespace Library
{
    // Класс Книга
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Copies { get; private set; }

        public Book(string title, string author, string isbn, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Copies = copies;
        }

        public bool BorrowBook()
        {
            if (Copies > 0)
            {
                Copies--;
                return true;
            }
            return false;
        }

        public void ReturnBook()
        {
            Copies++;
        }

        public override string ToString()
        {
            return $"{Title} — {Author}, ISBN: {ISBN}, Экземпляров: {Copies}";
        }
    }

    // Класс Читатель
    public class Reader
    {
        public string Name { get; set; }
        public int ReaderId { get; set; }

        public Reader(string name, int id)
        {
            Name = name;
            ReaderId = id;
        }

        public override string ToString()
        {
            return $"Читатель: {Name}, ID: {ReaderId}";
        }
    }

    // Класс Библиотека
    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<Reader> readers = new List<Reader>();

        // Добавление книги
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Книга добавлена: {book.Title}");
        }

        // Удаление книги
        public void RemoveBook(string isbn)
        {
            books.RemoveAll(b => b.ISBN == isbn);
            Console.WriteLine($"Книга с ISBN {isbn} удалена.");
        }

        // Регистрация читателя
        public void RegisterReader(Reader reader)
        {
            readers.Add(reader);
            Console.WriteLine($"Зарегистрирован {reader.Name}");
        }

        // Удаление читателя
        public void RemoveReader(int readerId)
        {
            readers.RemoveAll(r => r.ReaderId == readerId);
            Console.WriteLine($"Читатель с ID {readerId} удален.");
        }

        // Выдача книги
        public void BorrowBook(string isbn, int readerId)
        {
            Book? book = books.Find(b => b.ISBN == isbn);
            Reader? reader = readers.Find(r => r.ReaderId == readerId);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }
            if (reader == null)
            {
                Console.WriteLine("Читатель не найден.");
                return;
            }

            if (book.BorrowBook())
                Console.WriteLine($"{reader.Name} взял книгу: {book.Title}");
            else
                Console.WriteLine("Нет доступных экземпляров.");
        }

        // Возврат книги
        public void ReturnBook(string isbn, int readerId)
        {
            Book? book = books.Find(b => b.ISBN == isbn);
            Reader? reader = readers.Find(r => r.ReaderId == readerId);

            if (book != null && reader != null)
            {
                book.ReturnBook();
                Console.WriteLine($"{reader.Name} вернул книгу: {book.Title}");
            }
            else
            {
                Console.WriteLine("Ошибка возврата: книга или читатель не найдены.");
            }
        }

        // Показать список книг
        public void ShowBooks()
        {
            Console.WriteLine("\nКаталог книг:");
            foreach (var book in books)
                Console.WriteLine(book);
        }

        // Показать список читателей
        public void ShowReaders()
        {
            Console.WriteLine("\nСписок читателей:");
            foreach (var reader in readers)
                Console.WriteLine(reader);
        }
    }

    class Program
    {
        static void Main()
        {
            Library library = new Library();

            // Создаем книги
            Book book1 = new Book("Преступление и наказание", "Ф.М. Достоевский", "111", 2);
            Book book2 = new Book("Мастер и Маргарита", "М.А. Булгаков", "222", 1);

            // Добавляем книги
            library.AddBook(book1);
            library.AddBook(book2);

            // Регистрируем читателей
            Reader reader1 = new Reader("Иван Иванов", 1);
            Reader reader2 = new Reader("Мария Петрова", 2);

            library.RegisterReader(reader1);
            library.RegisterReader(reader2);

            // Проверка работы
            library.ShowBooks();
            library.ShowReaders();

            library.BorrowBook("111", 1); // Иван берет книгу
            library.BorrowBook("111", 2); // Мария берет ту же книгу
            library.BorrowBook("111", 2); // Попытка взять снова (нет экземпляров)

            library.ReturnBook("111", 1); // Иван возвращает книгу
            library.BorrowBook("111", 2); // Мария берет книгу после возврата

            library.ShowBooks();
        }
    }
}
