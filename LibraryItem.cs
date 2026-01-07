using System;

namespace WindowsFormsApp1
{
    // DZIEDZICZENIE - klasa abstrakcyjna
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public int Year { get; set; }

        // HERMETYZACJA - pole prywatne
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value > 0 ? value : 1;
        }

        // METODA ABSTRAKCYJNA - POLIMORFIZM
        public abstract string GetDescription();

        // METODA WIRTUALNA
        public virtual string GetBasicInfo()
        {
            return $"{Title} ({Year})";
        }
    }
}
