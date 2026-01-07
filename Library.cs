using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp1
{
    public class Library
    {
        // KOLEKCJA GENERYCZNA
        private List<Book> books = new List<Book>();

        // DODAJ KSIĄŻKĘ
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Dodano książkę: {book.Title}");
        }

        // ZNAJDŹ KSIĄŻKĘ PO TYTULE
        public Book FindBook(string title)
        {
            // INSTRUKCJA WARUNKOWA
            if (string.IsNullOrEmpty(title))
            {
                return null;
            }

            string searchTitle = title.ToLower();

            // PĘTLA FOREACH
            foreach (var book in books)
            {
                if (book.Title.ToLower().Contains(searchTitle))
                    return book;
            }

            return null;
        }

        // POKAŻ WSZYSTKIE KSIĄŻKI
        public void ShowAllBooks()
        {
            Console.WriteLine("=== WSZYSTKIE KSIĄŻKI ===");

            // PĘTLA FOREACH
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        // POKAŻ DOSTĘPNE KSIĄŻKI
        public List<Book> GetAvailableBooks()
        {
            List<Book> availableBooks = new List<Book>();

            // PĘTLA FOREACH z instrukcją warunkową
            foreach (var book in books)
            {
                if (book.IsAvailable)
                    availableBooks.Add(book);
            }

            return availableBooks;
        }

        // STATYSTYKI
        public void ShowStatistics()
        {
            int total = books.Count;
            int available = 0;

            // PĘTLA FOR
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].IsAvailable)
                    available++;
            }

            Console.WriteLine("\n=== STATYSTYKI ===");
            Console.WriteLine($"Łącznie książek: {total}");
            Console.WriteLine($"Dostępnych: {available}");
            Console.WriteLine($"Wypożyczonych: {total - available}");
        }

        // METODA Z LINQ (dodatkowo)
        public List<Book> GetAllBooks()
        {
            return books;  // Zwraca wszystkie książki
        }

        // Albo jeśli chcesz stringi do wyświetlania:
        public List<string> GetAllBooksAsStrings()
        {
            List<string> bookStrings = new List<string>();

            // PĘTLA FOREACH
            int counter = 1;
            foreach (var book in books)
            {
                string status = book.IsAvailable ? "✅ Dostępna" : "❌ Wypożyczona";
                string bookInfo = $"{counter}. {book.Title}";
                string details = $"   Autor: {book.Author} | Rok: {book.Year} | Status: {status}";

                bookStrings.Add(bookInfo);
                bookStrings.Add(details);
                bookStrings.Add("");  // Pusta linia

                counter++;
            }

            return bookStrings;
        }
    }
}
