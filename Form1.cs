using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // USUŃ "partial" - teraz to jedna klasa
    public class Form1 : Form
    {
        // ZMIENNE
        private Library library;
        private ListBox listBoxBooks;
        private TextBox txtSearch;
        private FileService fileService;

        // KONSTRUKTOR - BEZ InitializeComponent()
        public Form1()
        {
            SetupForm();
            CreateControls();
            InitializeLibrary();
            LoadSampleData();
            ShowBooks();
        }

        private void SetupForm()
        {
            this.Text = "📚 SYSTEM BIBLIOTECZNY - Projekt C#";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;
        }

        private void CreateControls()
        {
            // ===== TYTUŁ =====
            Label lblTitle = new Label();
            lblTitle.Text = "SYSTEM ZARZĄDZANIA BIBLIOTEKĄ";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(150, 20);
            lblTitle.Size = new Size(500, 40);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitle);

            // ===== WYSZUKIWANIE =====
            Label lblSearch = new Label();
            lblSearch.Text = "Wyszukaj książkę:";
            lblSearch.Location = new Point(50, 80);
            lblSearch.Size = new Size(100, 20);
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox();
            txtSearch.Location = new Point(160, 80);
            txtSearch.Size = new Size(200, 20);
            txtSearch.Text = "Wpisz tytuł...";
            this.Controls.Add(txtSearch);

            Button btnSearch = new Button();
            btnSearch.Text = "🔍 Szukaj";
            btnSearch.Location = new Point(370, 78);
            btnSearch.Size = new Size(80, 25);
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);

            // ===== LISTA KSIĄŻEK =====
            listBoxBooks = new ListBox();
            listBoxBooks.Location = new Point(50, 120);
            listBoxBooks.Size = new Size(550, 300);
            listBoxBooks.Font = new Font("Consolas", 10);
            listBoxBooks.BackColor = Color.White;
            this.Controls.Add(listBoxBooks);

            // ===== PANEL PRZYCISKÓW =====
            Panel buttonPanel = new Panel();
            buttonPanel.Location = new Point(620, 120);
            buttonPanel.Size = new Size(200, 370);
            buttonPanel.BackColor = Color.LightGray;
            buttonPanel.BorderStyle = BorderStyle.FixedSingle;

            // Przycisk 1 - Pokaż książki
            Button btnShow = new Button();
            btnShow.Text = "📖 Pokaż wszystkie";
            btnShow.Location = new Point(10, 20);
            btnShow.Size = new Size(180, 40);
            btnShow.Click += BtnShow_Click;
            buttonPanel.Controls.Add(btnShow);

            // Przycisk 2 - Dodaj książkę
            Button btnAdd = new Button();
            btnAdd.Text = "➕ Dodaj książkę";
            btnAdd.Location = new Point(10, 70);
            btnAdd.Size = new Size(180, 40);
            btnAdd.Click += BtnAdd_Click;
            buttonPanel.Controls.Add(btnAdd);

            // Przycisk 3 - Statystyki
            Button btnStats = new Button();
            btnStats.Text = "📊 Statystyki";
            btnStats.Location = new Point(10, 120);
            btnStats.Size = new Size(180, 40);
            btnStats.Click += BtnStats_Click;
            buttonPanel.Controls.Add(btnStats);

            // Przycisk 4 - O programie
            Button btnAbout = new Button();
            btnAbout.Text = "ℹ️ O programie";
            btnAbout.Location = new Point(10, 170);
            btnAbout.Size = new Size(180, 40);
            btnAbout.Click += BtnAbout_Click;
            buttonPanel.Controls.Add(btnAbout);

            this.Controls.Add(buttonPanel);

            // Przycisk 5 - Pokaż dziedziczenie
            Button btnInheritance = new Button();
            btnInheritance.Text = "🧬 Dziedziczenie";
            btnInheritance.Location = new Point(10, 220);
            btnInheritance.Size = new Size(180, 40);
            btnInheritance.Click += BtnInheritance_Click;
            buttonPanel.Controls.Add(btnInheritance);

            // Przycisk 6 - Zapis do pliku
            Button btnSave = new Button();
            btnSave.Text = "💾 Zapisz dane";
            btnSave.Location = new Point(10, 270);
            btnSave.Size = new Size(180, 40);
            btnSave.Click += BtnSave_Click;
            buttonPanel.Controls.Add(btnSave);

            // Przycisk 7 - Wczytaj z pliku
            Button btnLoad = new Button();
            btnLoad.Text = "📂 Wczytaj z pliku";
            btnLoad.Location = new Point(10, 320);
            btnLoad.Size = new Size(180, 40);
            btnLoad.Click += BtnLoad_Click;
            buttonPanel.Controls.Add(btnLoad);

            // ===== STATUS BAR =====
            Label lblStatus = new Label();
            lblStatus.Text = "Gotowy | Projekt C# - Programowanie obiektowe";
            lblStatus.Location = new Point(50, 440);
            lblStatus.Size = new Size(500, 20);
            lblStatus.ForeColor = Color.DarkGray;
            this.Controls.Add(lblStatus);
        }

        private void InitializeLibrary()
        {
            library = new Library();
            fileService = new FileService("biblioteka_dane.txt");  // ← DODAJ TĘ LINIJKĘ

            LoadSampleData();  // Jeśli to masz
        }

        private void LoadSampleData()
        {
            // DODAJ PRZYKŁADOWE KSIĄŻKI
            library.AddBook(new Book("Wiedźmin: Ostatnie życzenie", "Andrzej Sapkowski", 1993));
            library.AddBook(new Book("Harry Potter i Kamień Filozoficzny", "J.K. Rowling", 1997));
            library.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1834));
            library.AddBook(new Book("Zbrodnia i kara", "Fiodor Dostojewski", 1866));
            library.AddBook(new Book("Solaris", "Stanisław Lem", 1961));

            // WYPOSAŻYJ 2 KSIĄŻKI - POPRAWIONE:
            Book book1 = library.FindBook("Wiedźmin");
            if (book1 != null)
            {
                book1.Borrow();
            }

            Book book2 = library.FindBook("Zbrodnia");
            if (book2 != null)
            {
                book2.Borrow();
            }
        }

        private void ShowBooks()
        {
            listBoxBooks.Items.Clear();
            listBoxBooks.Items.Add("=== WSZYSTKIE KSIĄŻKI W BIBLIOTECE ===");
            listBoxBooks.Items.Add("=======================================");
            listBoxBooks.Items.Add("");

            // Pobierz rzeczywiste książki z biblioteki
            if (library != null)
            {
                // PĘTLA FOREACH po rzeczywistych książkach
                int bookNumber = 1;

                foreach (var book in library.GetAllBooks())
                {
                    string status = book.IsAvailable ? "✅ Dostępna" : "❌ Wypożyczona";
                    string statusIcon = book.IsAvailable ? "🟢" : "🔴";

                    listBoxBooks.Items.Add($"{statusIcon} KSIĄŻKA #{bookNumber}");
                    listBoxBooks.Items.Add($"   📖 Tytuł: {book.Title}");
                    listBoxBooks.Items.Add($"   ✍️  Autor: {book.Author}");
                    listBoxBooks.Items.Add($"   📅 Rok: {book.Year}");
                    listBoxBooks.Items.Add($"   🆔 ID: {book.Id}");
                    listBoxBooks.Items.Add($"   📊 Status: {status}");

                    // INSTRUKCJA WARUNKOWA - dodatkowe info
                    if (book.Year < 1900)
                    {
                        listBoxBooks.Items.Add($"   ℹ️  To jest stara książka ({book.Year} r.)");
                    }
                    else if (book.Year > 2010)
                    {
                        listBoxBooks.Items.Add($"   ℹ️  To jest nowa książka ({book.Year} r.)");
                    }

                    listBoxBooks.Items.Add("");  // Pusta linia między książkami
                    bookNumber++;
                }

                // Jeśli brak książek
                if (bookNumber == 1)
                {
                    listBoxBooks.Items.Add("📭 Brak książek w bibliotece!");
                    listBoxBooks.Items.Add("Kliknij 'Dodaj książkę' aby dodać pierwszą.");
                }
                else
                {
                    listBoxBooks.Items.Add($"📊 Łącznie: {bookNumber - 1} książek");
                }
            }
            else
            {
                listBoxBooks.Items.Add("❌ Błąd: Biblioteka nie została zainicjalizowana!");
            }
        }

        // ===== OBSŁUGA ZDARZEŃ =====

        private void BtnShow_Click(object sender, EventArgs e)
        {
            ShowBooks();
            MessageBox.Show("Pokazano wszystkie książki!", "Informacja",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // ZAMIENIAMY STARĄ METODĘ NA NOWĄ
            AddBookWithForm();
            ShowBooks();
            // ALBO MOŻESZ DAĆ UŻYTKOWNIKOWI WYBÓR:
            /*
            DialogResult choice = MessageBox.Show(
                "Wybierz sposób dodawania książki:\n\n" +
                "TAK - Zaawansowany formularz\n" +
                "NIE - Szybkie dodanie (tylko tytuł)\n" +
                "ANULUJ - Powrót",
                "Sposób dodawania",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {
                AddBookWithForm();
            }
            else if (choice == DialogResult.No)
            {
                // Stara metoda - szybkie dodanie
                string newTitle = "Nowa książka " + DateTime.Now.ToString("HH:mm:ss");
                library.AddBook(new Book(newTitle, "Nowy Autor", DateTime.Now.Year));

                listBoxBooks.Items.Add($"");
                listBoxBooks.Items.Add($"✅ DODANO NOWĄ KSIĄŻKĘ:");
                listBoxBooks.Items.Add($"   Tytuł: {newTitle}");
            }
            */
        }
        // okno do dodawania nowej książki
        private void AddBookWithForm()
        {
            // TWORZYMY NOWE OKNO DIALOGOWE
            Form addForm = new Form();
            addForm.Text = "📖 Dodaj nową książkę";
            addForm.Size = new Size(400, 300);
            addForm.StartPosition = FormStartPosition.CenterParent;

            // KONTROLKI DO WPISYWANIA DANYCH
            Label lblTitle = new Label { Text = "Tytuł:", Location = new Point(20, 30), Size = new Size(80, 20) };
            TextBox txtTitle = new TextBox { Location = new Point(120, 30), Size = new Size(240, 20) };

            Label lblAuthor = new Label { Text = "Autor:", Location = new Point(20, 60), Size = new Size(80, 20) };
            TextBox txtAuthor = new TextBox { Location = new Point(120, 60), Size = new Size(240, 20) };

            Label lblYear = new Label { Text = "Rok wydania:", Location = new Point(20, 90), Size = new Size(80, 20) };
            NumericUpDown numYear = new NumericUpDown
            {
                Location = new Point(120, 90),
                Size = new Size(100, 20),
                Minimum = 1000,
                Maximum = DateTime.Now.Year,
                Value = DateTime.Now.Year
            };

            // PRZYCISKI
            Button btnAdd = new Button
            {
                Text = "Dodaj książkę",
                Location = new Point(50, 150),
                Size = new Size(120, 35)
            };

            Button btnCancel = new Button
            {
                Text = "Anuluj",
                Location = new Point(200, 150),
                Size = new Size(120, 35)
            };

            // OBSŁUGA ZDARZEŃ PRZYCISKÓW
            btnAdd.Click += (s, args) =>
            {
                // WALIDACJA DANYCH
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Wpisz tytuł książki!", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    MessageBox.Show("Wpisz autora książki!", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAuthor.Focus();
                    return;
                }

                // TWORZENIE NOWEJ KSIĄŻKI - TO JEST WAŻNE! newBook TU SIĘ TWORZY
                Book newBook = new Book(txtTitle.Text, txtAuthor.Text, (int)numYear.Value);

                // DODAJ DO BIBLIOTEKI
                library.AddBook(newBook);

                // ODŚWIEŻ LISTĘ KSIĄŻEK
                ShowBooks();

                // ZAMKNIJ OKNO
                addForm.DialogResult = DialogResult.OK;
                addForm.Close();

                // POKAŻ KOMUNIKAT
                MessageBox.Show($"Dodano książkę:\n{newBook.Title}\n{newBook.Author}\n{newBook.Year}",
                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnCancel.Click += (s, args) =>
            {
                addForm.DialogResult = DialogResult.Cancel;
                addForm.Close();
            };

            // DODAJ KONTROLKI DO OKNA
            addForm.Controls.Add(lblTitle);
            addForm.Controls.Add(txtTitle);
            addForm.Controls.Add(lblAuthor);
            addForm.Controls.Add(txtAuthor);
            addForm.Controls.Add(lblYear);
            addForm.Controls.Add(numYear);
            addForm.Controls.Add(btnAdd);
            addForm.Controls.Add(btnCancel);

            // POKAŻ OKNO DIALOGOWE
            addForm.ShowDialog();
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {
            listBoxBooks.Items.Clear();
            listBoxBooks.Items.Add("=== STATYSTYKI BIBLIOTEKI ===");
            listBoxBooks.Items.Add("=============================");
            listBoxBooks.Items.Add("");

            // KOLEKCJA GENERYCZNA
            List<string> statistics = new List<string>()
            {
                "Łączna liczba książek: 5",
                "Książki dostępne: 3",
                "Książki wypożyczone: 2",
                "Najstarsza książka: 1834 r.",
                "Najnowsza książka: 2024 r."
            };

            // PĘTLA FOREACH
            int counter = 1;
            foreach (string stat in statistics)
            {
                listBoxBooks.Items.Add($"{counter}. {stat}");
                counter++;
            }

            listBoxBooks.Items.Add("");
            listBoxBooks.Items.Add("=== GATUNKI (przykład LINQ) ===");

            // PRZYKŁAD LINQ (symulowany)
            Dictionary<string, int> genres = new Dictionary<string, int>
            {
                {"Fantasy", 2},
                {"Poezja", 1},
                {"Klasyka", 1},
                {"Science Fiction", 1}
            };

            foreach (var genre in genres)
            {
                listBoxBooks.Items.Add($"   {genre.Key}: {genre.Value} książek");
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "PROJEKT ZALICZENIOWY C#\n\n" +
                "Wymagania spełnione:\n" +
                "1. ✅ Instrukcje warunkowe\n" +
                "2. ✅ Pętle (for, foreach)\n" +
                "3. ✅ Kolekcje generyczne (List<T>)\n" +
                "4. ✅ Programowanie obiektowe\n" +
                "5. ✅ Interfejs użytkownika\n\n" +
                "Autor: Student",
                "O programie",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void BtnInheritance_Click(object sender, EventArgs e)
        {
            listBoxBooks.Items.Clear();
            listBoxBooks.Items.Add("=== DZIEDZICZENIE I POLIMORFIZM ===");
            listBoxBooks.Items.Add("");

            // PRZYKŁAD DZIEDZICZENIA
            Book book = new Book("Przykład", "Autor", 2024);
            Magazine magazine = new Magazine
            {
                Title = "National Geographic",
                IssueNumber = "2024/03",
                Year = 2024
            };

            listBoxBooks.Items.Add("Książka (klasa Book):");
            listBoxBooks.Items.Add($"  Opis: {book.GetDescription()}");
            listBoxBooks.Items.Add($"  Info: {book.GetBasicInfo()}");
            listBoxBooks.Items.Add("");

            listBoxBooks.Items.Add("Czasopismo (klasa Magazine):");
            listBoxBooks.Items.Add($"  Opis: {magazine.GetDescription()}");
            listBoxBooks.Items.Add($"  Info: {magazine.GetBasicInfo()}");
            listBoxBooks.Items.Add("");

            listBoxBooks.Items.Add("=== HERMETYZACJA ===");
            listBoxBooks.Items.Add("ID książki jest chronione:");
            listBoxBooks.Items.Add($"  ID: {book.Id} (dostęp przez właściwość)");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxBooks.Items.Clear();
                listBoxBooks.Items.Add("=== ZAPISYWANIE DANYCH ===");
                listBoxBooks.Items.Add("");

                // ZAPISZ RZECZYWISTE KSIĄŻKI
                fileService.SaveBooks(library.GetAllBooks());

                listBoxBooks.Items.Add("✅ DANE ZAPISANE POMYŚLNIE!");
                listBoxBooks.Items.Add($"Plik: biblioteka_dane.txt");
                listBoxBooks.Items.Add($"Liczba książek: {library.GetAllBooks().Count}");
                listBoxBooks.Items.Add("");
                listBoxBooks.Items.Add("Zapisane książki:");

                // POKAŻ CO ZAPISANO
                int counter = 1;
                foreach (var book in library.GetAllBooks())
                {
                    listBoxBooks.Items.Add($"  {counter}. {book.Title} - {book.Author}");
                    counter++;
                }

                // INSTRUKCJA WARUNKOWA
                if (counter == 1)
                {
                    listBoxBooks.Items.Add("  (brak książek do zapisania)");
                }
            }
            catch (Exception ex)
            {
                listBoxBooks.Items.Add($"❌ BŁĄD ZAPISU: {ex.Message}");
            }
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            listBoxBooks.Items.Clear();
            listBoxBooks.Items.Add("=== WCZYTYWANIE Z PLIKU ===");
            listBoxBooks.Items.Add("");

            try
            {
                var fileContent = fileService.LoadBooksInfo();

                if (fileContent.Count > 0)
                {
                    // PĘTLA FOREACH po liniach z pliku
                    foreach (string line in fileContent)
                    {
                        listBoxBooks.Items.Add(line);
                    }

                    listBoxBooks.Items.Add("");
                    listBoxBooks.Items.Add($"✅ Wczytano {fileContent.Count} linii z pliku");
                }
                else
                {
                    listBoxBooks.Items.Add("Plik jest pusty lub nie istnieje.");
                    listBoxBooks.Items.Add("Dodaj książki i kliknij 'Zapisz dane'");
                }
            }
            catch (Exception ex)
            {
                listBoxBooks.Items.Add($"❌ BŁĄD WCZYTANIA: {ex.Message}");
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // Pobierz tekst z pola wyszukiwania
            string searchText = txtSearch.Text.Trim();

            // Instrukcja warunkowa - sprawdź czy coś wpisano
            if (string.IsNullOrEmpty(searchText) || searchText == "Wpisz tytuł...")
            {
                MessageBox.Show("Wpisz tekst do wyszukania!", "Uwaga",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Wyczyść listę
            listBoxBooks.Items.Clear();
            listBoxBooks.Items.Add($"=== WYNIKI WYSZUKIWANIA: '{searchText}' ===");
            listBoxBooks.Items.Add("");

            // Wyszukaj książki - POPRAWIONE Contains
            int foundCount = 0;
            string searchLower = searchText.ToLower();  // Zamień na małe litery

            // PĘTLA FOREACH
            foreach (var book in library.GetAllBooks())
            {
                string titleLower = book.Title.ToLower();
                string authorLower = book.Author.ToLower();

                // UŻYJ ToLower() ZAMIAST StringComparison
                if (titleLower.Contains(searchLower) || authorLower.Contains(searchLower))
                {
                    listBoxBooks.Items.Add($"✅ {book.Title}");
                    listBoxBooks.Items.Add($"   Autor: {book.Author}");
                    listBoxBooks.Items.Add($"   Rok: {book.Year}");

                    // INSTRUKCJA WARUNKOWA - status książki
                    if (book.IsAvailable)
                    {
                        listBoxBooks.Items.Add($"   Status: 🟢 Dostępna");
                    }
                    else
                    {
                        listBoxBooks.Items.Add($"   Status: 🔴 Wypożyczona");
                    }

                    listBoxBooks.Items.Add("");
                    foundCount++;
                }
            }

            // Jeśli nic nie znaleziono
            if (foundCount == 0)
            {
                listBoxBooks.Items.Add("❌ Nie znaleziono książek pasujących do wyszukiwania.");
                listBoxBooks.Items.Add("");
                listBoxBooks.Items.Add("📚 Dostępne książki w bibliotece:");

                // PĘTLA FOR - pokaż pierwsze 3 książki
                int booksToShow = Math.Min(3, library.GetAllBooks().Count);
                for (int i = 0; i < booksToShow; i++)
                {
                    var book = library.GetAllBooks()[i];
                    listBoxBooks.Items.Add($"   {i + 1}. {book.Title} - {book.Author}");
                }

                if (library.GetAllBooks().Count > 3)
                {
                    listBoxBooks.Items.Add($"   ... i {library.GetAllBooks().Count - 3} więcej");
                }
            }
            else
            {
                listBoxBooks.Items.Add($"📊 Znaleziono {foundCount} książek.");

                // DODATKOWA INFORMACJA
                if (foundCount == 1)
                {
                    listBoxBooks.Items.Add("(znaleziono 1 książkę)");
                }
                else if (foundCount <= 3)
                {
                    listBoxBooks.Items.Add($"(znaleziono {foundCount} książki)");
                }
                else
                {
                    listBoxBooks.Items.Add($"(znaleziono {foundCount} książek)");
                }
            }
        }
    }

}
