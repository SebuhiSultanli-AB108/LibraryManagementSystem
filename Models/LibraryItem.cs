using System.Text;

namespace LibraryManagementSystem.Models;

abstract class LibraryItem
{
    public string Title { get; set; }
    public DateTime? PublicationYear { get; set; }

    protected LibraryItem(string title)
    {
        Title = title;
    }

    public abstract void DisplayInfo();
}

class Book : LibraryItem
{
    public bool IsBestSeller { get; set; }
    public BookGenre Genre { get; set; }
    static int Shelf;
    static int Aisle;
    LibraryLocation Location;

    public Book(string title, int shelf, int aisle) : base(title)
    {
        Shelf = shelf;
        Aisle = aisle;
        Location = new LibraryLocation(Shelf, Aisle);
        LibraryCatalog.AddBook(this);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Location -> Asile: {Location.aisle} Shelf: {Location.shelf}");
        if (IsBestSeller) Console.WriteLine("This book is a best seller!");
        else Console.WriteLine("This book is not a best seller!");
        Console.Write("Publication Date: ");
        if (PublicationYear != null) Console.WriteLine(PublicationYear);
        else Console.WriteLine("Unknown");
    }
}
class Magazine : LibraryItem
{
    public bool IsNew { get; set; }

    public Magazine(string title) : base(title) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        if (IsNew) Console.WriteLine("This magazine is new!");
        else Console.WriteLine("This magazine is old!");
        Console.Write("Publication Date: ");
        if (PublicationYear != null) Console.WriteLine(PublicationYear);
        else Console.WriteLine("Unknown");
    }
}
class DVD : LibraryItem
{

    private float _imdbPoint;
    public float ImdbPoint
    {
        get => _imdbPoint;
        set
        {
            if (value > 10 || value < 0)
            {
                Console.WriteLine("IMDB Point cant be less than 0 or more than 10 !!!");
                _imdbPoint = 0;
                return;
            }
            _imdbPoint = value;
        }
    }

    public DVD(string title) : base(title) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"IMDB: {ImdbPoint}/10");
        Console.Write("Publication Date: ");
        if (PublicationYear != null) Console.WriteLine(PublicationYear);
        else Console.WriteLine("Unknown");
    }
}

static class LibraryHelper
{
    static public int CalculateAge(this LibraryItem libraryItem)
    {
        if (libraryItem != null)
            return DateTime.Now.Year - libraryItem.PublicationYear.Value.Year;
        else Console.WriteLine("LibraryItem is null");
        return 0;
    }
    static public void ToTitleCase(this LibraryItem libraryItem)
    {
        StringBuilder fixedTitle = new StringBuilder();
        fixedTitle.Append(libraryItem.Title);
        if (fixedTitle[0] <= 122 && fixedTitle[0] >= 97 && fixedTitle[0] != ' ') fixedTitle[0] = (char)(fixedTitle[0] - 32);

        for (int i = 1; i < fixedTitle.Length; i++)
        {
            if (fixedTitle[i] <= 90 && fixedTitle[i] >= 65 && fixedTitle[i] != ' ') fixedTitle[i] = (char)(fixedTitle[i] + 32);
        }
        libraryItem.Title = fixedTitle.ToString();
    }
}

static class LibraryCatalog
{
    public static Book[] Books = new Book[0];

    public static void AddBook(this Book book)
    {
        Book[] newArr = new Book[Books.Length + 1];
        for (int i = 0; i < Books.Length; i++)
        {
            newArr[i] = Books[i];
        }
        newArr[newArr.Length - 1] = book;
        Books = newArr;
    }
}



enum BookGenre : int
{
    Fiction = 0,
    NonFiction = 1,
    Science = 2,
    Art = 3
}

public struct LibraryLocation
{
    public int shelf;
    public int aisle;

    public LibraryLocation(int shelf, int aisle)
    {
        this.shelf = shelf;
        this.aisle = aisle;
    }
}