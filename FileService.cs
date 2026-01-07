using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp1
{
    public class FileService
    {
        private string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        // ZAPISZ KSIĄŻKI DO PLIKU
        public void SaveBooks(List<Book> books)
        {
            try
            {
                List<string> lines = new List<string>();
                lines.Add("=== DANE BIBLIOTEKI ===");
                lines.Add($"Data zapisu: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                lines.Add($"Liczba książek: {books.Count}");
                lines.Add("");
                lines.Add("LISTA KSIĄŻEK:");
                lines.Add("");

                // PĘTLA FOREACH
                int counter = 1;
                foreach (var book in books)
                {
                    lines.Add($"[KSIĄŻKA #{counter}]");
                    lines.Add($"Tytuł: {book.Title}");
                    lines.Add($"Autor: {book.Author}");
                    lines.Add($"Rok: {book.Year}");
                    lines.Add($"ID: {book.Id}");
                    lines.Add($"Dostępna: {(book.IsAvailable ? "TAK" : "NIE")}");
                    lines.Add($"---");
                    counter++;
                }

                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception ex)
            {
                throw new Exception($"Błąd zapisu: {ex.Message}");
            }
        }

        // WCZYTAJ KSIĄŻKI Z PLIKU (symulacja)
        public List<string> LoadBooksInfo()
        {
            if (!File.Exists(_filePath))
            {
                return new List<string> { "Plik nie istnieje", "Dodaj książki i zapisz je" };
            }

            return new List<string>(File.ReadAllLines(_filePath));
        }
    }
}
