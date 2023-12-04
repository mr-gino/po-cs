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
