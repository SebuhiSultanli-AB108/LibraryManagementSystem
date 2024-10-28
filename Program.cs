using LibraryManagementSystem.Models;

namespace LibraryManagementSystem;

internal class Program
{
    static void Main()
    {
        Book Whitcher = new Book("whitcher", 10, 5)
        {
            Genre = BookGenre.Fiction,
            IsBestSeller = true,
            PublicationYear = DateTime.Today.AddYears(-5),
        };
        Book Metro = new Book("Metro Trilogy", 10, 6)
        {
            Genre = BookGenre.Science,
            IsBestSeller = true,
            PublicationYear = DateTime.Today.AddYears(-4),
        };
        Book HayriPitir = new Book("haYri Pitir", 50, 50)
        {
            IsBestSeller = false,
            PublicationYear = DateTime.Today.AddYears(-50),
        };

        foreach (var item in LibraryCatalog.Books)
        {
            Console.WriteLine("==========================================");
            item.ToTitleCase();
            item.DisplayInfo();
            Console.WriteLine("Age: " + item.CalculateAge());
        }
        Console.WriteLine("==========================================");
    }
}