using ConsoleApp1;

internal class Reader : Person
{
    // Lista książek przeczytanych przez czytelnika
    public List<Book> ReadBooks { get; set; }

    public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {
        ReadBooks = new List<Book>();
    }

    // Metoda do wypisywania tytułów przeczytanych książek
    public void ViewBooks()
    {
        Console.WriteLine($"{FirstName} {LastName}'s read books:");
        foreach (var book in ReadBooks)
        {
            Console.WriteLine($"{book.Title} by {book.author.FirstName} {book.author.LastName}");
        }
    }
}