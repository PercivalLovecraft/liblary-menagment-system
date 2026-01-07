using System;

namespace WindowsFormsApp1
{
    // DZIEDZICZENIE - Book dziedziczy po LibraryItem
    public class Book : LibraryItem
    {
        public string Author { get; set; }
        public bool IsAvailable { get; private set; } = true;

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
            Id = new Random().Next(1000, 9999);
        }

        // POLIMORFIZM - przesłonięcie metody abstrakcyjnej
        public override string GetDescription()
        {
            return $"Książka: {Title} - {Author}";
        }

        // Dodatkowa metoda
        public void Borrow()
        {
            IsAvailable = false;
        }

        public void Return()
        {
            IsAvailable = true;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "✅ Dostępna" : "❌ Wypożyczona";
            return $"{Title} | {Author} | {Year} | {status}";
        }
        // DODAJ NOWE WŁAŚCIWOŚCI:
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string ISBN { get; set; }

        // ROZSZERZ KONSTRUKTOR:
        public Book(string title, string author, int year, string genre = "", int pages = 0)
        {
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
            PageCount = pages;
            Id = new Random().Next(1000, 9999);
            IsAvailable = true;
        }

        // DODATKOWA METODA:
        public string GetFullInfo()
        {
            return $"{Title} by {Author} ({Year}) - {Genre} - {PageCount} pages";
        }
    }
}
