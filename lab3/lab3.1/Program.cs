using ConsoleApp1;

Person[] people = new Person[] {
    new Person("Jan","Nowak",12),
    new Person("Janina","Nowak",23),
    new Person("Marek","Kowalski",42),
    new Person("Anna","Nowakowska",4)
};


Person[] authors = new Person[] {
    new Person("Adam","Malysz"),
    new Person("Mikolaj","Kopernik"),
    new Person("Juliusz","Slowacki"),
    new Person("Adam","Mickiewicz")
};

Book[] books = new Book[] {
    new Book("100 DELMATYNCZYKOW",authors[0], new DateTime(1999,05,06)),
    new Book("MAIN KAMPF",authors[1], new DateTime(2023,04,23)),
    new Book("W PUSTYNI I W PUSZCZY",authors[2], new DateTime(2021,01,30)),
    new Book("BIBLIA",authors[3], new DateTime(2000,07,07)),
};

Reader[] readers = new Reader[]
{
    new Reader(people[0]),
    new Reader(people[1]),
    new Reader(people[2]),
    new Reader(people[3])
};

readers[0].ReadBooks = new Book[] { books[0], books[1] };
readers[1].ReadBooks = new Book[] { books[1], books[3] };
readers[2].ReadBooks = new Book[] { books[2], books[3] };
readers[3].ReadBooks = new Book[] { books[0], books[2], books[3] };

Console.WriteLine("======= Osoby ==========");
foreach (Person item in people)
{
    item.View();
}

Console.WriteLine("\n\n======= Books ==========");
foreach (Book item in books)
{
    item.View();
}

Console.WriteLine("\n\n======= Czytelnicy i ich przeczytane książki ==========");
foreach (Reader reader in readers)
{
    reader.View();
}
