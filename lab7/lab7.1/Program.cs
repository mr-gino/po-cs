using CsvHelper;
using System.Globalization;

String filePath = "data.csv";

bool m = true;
while (m)
{
    Console.WriteLine("\n|| MENU GŁÓWNE ||");
    Console.WriteLine("1 - Wyświetl dane");
    Console.WriteLine("2 - Dodaj osobę");
    Console.WriteLine("3 - Modyfikuj osobę");
    Console.WriteLine("4 - Usuń osobę");
    Console.WriteLine("5 - Wyjście z programu");
    int n = Convert.ToInt32(Console.ReadLine());
    switch (n)
    {
        case 1:
            Console.WriteLine("\n|| WYBRANO WYŚWIETL DANE ||");
            ReadAndDisplayData(filePath);
            break;
        case 2:
            AddPerson(filePath);
            break;
        case 3:
            ModifyPerson(filePath);
            break;
        case 4:
            RemovePerson(filePath);
            break;
        case 5:
            m = false;
            Console.WriteLine("\n|| WYBRANO WYJŚCIE Z PROGRAMU ||");
            break;
        default:
            break;
    }
}

static void ReadAndDisplayData(string filePath)
{
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var records = csv.GetRecords<Person>().ToList();

        Console.WriteLine("\nDane odczytane z pliku CSV:");
        foreach (var person in records)
        {
            Console.WriteLine($"Imię: {person.FirstName}, Nazwisko: {person.LastName}, Adres: {person.Address.Street}, {person.Address.City}, {person.Address.PostalCode}, PESEL: {person.Pesel}, Email: {person.Email}");
        }
    }
}

static void AddPerson(string filePath)
{
    Console.WriteLine("\nWYBRANO DODANIE NOWEJ OSOBY");

    do
    {
        try
        {
            Console.Write("Imię: ");
            string newFirstName = Console.ReadLine();
            if (string.IsNullOrEmpty(newFirstName))
                throw new Exception("Imię nie może być puste.");

            Console.Write("Nazwisko: ");
            string newLastName = Console.ReadLine();
            if (string.IsNullOrEmpty(newLastName))
                throw new Exception("Nazwisko nie może być puste.");

            Console.Write("Adres (ulica): ");
            string newStreet = Console.ReadLine();
            if (string.IsNullOrEmpty(newStreet))
                throw new Exception("Ulica nie może być pusta.");

            Console.Write("Adres (miasto): ");
            string newCity = Console.ReadLine();
            if (string.IsNullOrEmpty(newCity))
                throw new Exception("Miasto nie może być puste.");

            Console.Write("Adres (kod pocztowy): ");
            string newPostalCode = Console.ReadLine();
            if (string.IsNullOrEmpty(newPostalCode))
                throw new Exception("Kod pocztowy nie może być pusty.");

            Console.Write("PESEL (11 cyfr): ");
            string newPeselInput = Console.ReadLine();
            if (newPeselInput.Length != 11)
                throw new Exception("PESEL musi składać się z 11 cyfr.");

            Console.Write("Email: ");
            string newEmail = Console.ReadLine();
            if (string.IsNullOrEmpty(newEmail) || !newEmail.Contains("@"))
                throw new Exception("Nieprawidłowy adres email.");

            var newPerson = new Person
            {
                FirstName = newFirstName,
                LastName = newLastName,
                Address = new Address { Street = newStreet, City = newCity, PostalCode = newPostalCode },
                Pesel = newPeselInput,
                Email = newEmail
            };

            using (var writer = new StreamWriter(filePath, true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(newPerson);
                csv.NextRecord();
            }

            Console.WriteLine("OSOBA DODANA DO BAZY");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"BŁĄD: {ex.Message}");
            Console.WriteLine("WPROWADŹ DANE PONOWNIE");
        }
    } while (true);
}

static void ModifyPerson(string filePath)
{
    Console.WriteLine("\nWYBRANO MODYFIKUJ OSOBĘ");

    Console.Write("Wprowadź numer PESEL osoby do modyfikacji: ");
    string peselToModify = Console.ReadLine();

    var records = ReadAllRecords(filePath);
    var personToModify = records.FirstOrDefault(p => p.Pesel == peselToModify);
    if (personToModify != null)
    {
        do {
        
            Console.WriteLine($"\nZnaleziono osobę: {personToModify.FirstName} {personToModify.LastName}");
            try
            {
                Console.Write("Imię: ");
                string newFirstName = Console.ReadLine();
                if (string.IsNullOrEmpty(newFirstName))
                    throw new Exception("Imię nie może być puste.");

                Console.Write("Nazwisko: ");
                string newLastName = Console.ReadLine();
                if (string.IsNullOrEmpty(newLastName))
                    throw new Exception("Nazwisko nie może być puste.");

                Console.Write("Adres (ulica): ");
                string newStreet = Console.ReadLine();
                if (string.IsNullOrEmpty(newStreet))
                    throw new Exception("Ulica nie może być pusta.");

                Console.Write("Adres (miasto): ");
                string newCity = Console.ReadLine();
                if (string.IsNullOrEmpty(newCity))
                    throw new Exception("Miasto nie może być puste.");

                Console.Write("Adres (kod pocztowy): ");
                string newPostalCode = Console.ReadLine();
                if (string.IsNullOrEmpty(newPostalCode))
                    throw new Exception("Kod pocztowy nie może być pusty.");

                Console.Write("PESEL (11 cyfr): ");
                string newPeselInput = Console.ReadLine();
                if (newPeselInput.Length != 11)
                    throw new Exception("PESEL musi składać się z 11 cyfr.");

                Console.Write("Email: ");
                string newEmail = Console.ReadLine();
                if (string.IsNullOrEmpty(newEmail) || !newEmail.Contains("@"))
                    throw new Exception("Nieprawidłowy adres email.");

                personToModify.FirstName = newFirstName;
                personToModify.LastName = newLastName;
                personToModify.Address = new Address { Street = newStreet, City = newCity, PostalCode = newPostalCode };
                personToModify.Pesel = newPeselInput;
                personToModify.Email = newEmail;

                WriteAllRecords(filePath, records);
                Console.WriteLine("-> OSOBA POMYŚLNIE ZAAKTUALIZOWANA");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nBŁĄD: {ex.Message}");
                Console.WriteLine("\n!!! WPROWADŹ DANE PONOWNIE !!!");
            }
        } while (true) ;
    }
    else
    {
        Console.WriteLine($"-> Osoba o numerze PESEL {peselToModify} nie została znaleziona.");
    }
}

static List<Person> ReadAllRecords(string filePath)
{
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        return csv.GetRecords<Person>().ToList();
    }
}

static void WriteAllRecords(string filePath, List<Person> records)
{
    using (var writer = new StreamWriter(filePath, false))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(records);
    }
}

static void RemovePerson(string filePath)
{
    Console.WriteLine("\n|| WYBRANO USUŃ OSOBĘ ||");

    Console.Write("\nWprowadź numer PESEL osoby do usunięcia: ");
    string peselToRemove = Console.ReadLine();

    var records = ReadAllRecords(filePath);
    var personToRemove = records.FirstOrDefault(p => p.Pesel == peselToRemove);

    if (personToRemove != null)
    {
        records.Remove(personToRemove);
        WriteAllRecords(filePath, records);

        Console.WriteLine($"-> OSOBA ZOSTAŁA USUNIĘTA");
    }
    else
    {
        Console.WriteLine($"-> OSOBA NIE ZOSTAŁA USUNIĘTA (nie znaleziono numeru PESEL)");
    }
}