using ConsoleApp1;

class Reader : Person
{
    public Book[] ReadBooks { get; set; }

    public Reader(Person person) : base(person.FirstName, person.LastName, person.Age)
    {
    }

    public void ViewBooks()
    {
        Console.WriteLine($"PRZECZYTANE KSIĄŻKI PRZEZ {FirstName} {LastName}:");
        foreach (Book book in ReadBooks)
        {
            book.View();
        }
    }

    public override void View()
    {
        //base.View();
        ViewBooks();
        Console.WriteLine();
    }
}