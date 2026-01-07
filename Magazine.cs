namespace WindowsFormsApp1
{
    // DZIEDZICZENIE - Magazine też dziedziczy po LibraryItem
    public class Magazine : LibraryItem
    {
        public string IssueNumber { get; set; }
        public string Publisher { get; set; }

        // POLIMORFIZM - inna implementacja tej samej metody
        public override string GetDescription()
        {
            return $"Czasopismo: {Title}, Numer: {IssueNumber}, Wydawca: {Publisher}";
        }

        public override string ToString()
        {
            return $"{Title} | Numer: {IssueNumber} | {Year}";
        }
    }
}
