using ConsoleApp1;

class Reader : Person
{
    public Book[] ReadBooks { get; set; }

    public Reader(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public void ViewBooks()
    {
        Console.WriteLine($"Przeczytane książki przez {FirstName} {LastName}:");
        foreach (Book book in ReadBooks)
        {
            Console.WriteLine($"- {book.Title}");
        }
    }

    public void View()
    {
        base.View2Atribut();
        ViewBooks();
        Console.WriteLine();
    }
}