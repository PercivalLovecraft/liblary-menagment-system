namespace WindowsFormsApp1
{
    // INTERFEJS
    public interface IBorrowable
    {
        bool IsAvailable { get; }
        void BorrowItem();
        void ReturnItem();
        string CurrentBorrower { get; set; }
    }
}
