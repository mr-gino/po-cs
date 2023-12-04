using ConsoleApp1;

Person[] people = new Person[] {
    new Person("Jan","Nowak",12),
    new Person("Janina","Nowak",23),
    new Person("Marek","Kowalski",42),
    new Person("Anna","Nowakowska",4)
};


Person[] authors = new Person[] {
    new Person("Autor 1","Autor 1"),
    new Person("Autor 2","Nowak"),
    new Person("Autor 3","Kowalski"),
    new Person("Autor 4","Nowakowska")
};

Book[] books = new Book[] {
    new Book("Tytul 1",authors[0], new DateTime(1999,05,06)),
    new Book("Tytul 2",authors[1], new DateTime(2023,04,23)),
    new Book("Tytul 3",authors[2], new DateTime(2021,01,30)),
    new Book("Tytul 4",authors[3], new DateTime(2000,07,07)),
};

Reader[] readers = new Reader[]
{
    new Reader("Czytelnik 1", "Czytelnik 1"),
    new Reader("Czytelnik 2", "Czytelnik 2"),
    new Reader("Czytelnik 3", "Czytelnik 3"),
    new Reader("Czytelnik 4", "Czytelnik 4")
};

// Przypisanie książek do tablic/list przeczytanych książek czytelników
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
