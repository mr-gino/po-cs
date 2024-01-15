using System.Formats.Asn1;
using System.Globalization;
using System.Data.SqlClient;
using System;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NewDB; Integrated Security = True";

string createTableQuery = @"
            CREATE TABLE People
            (
                Id INT PRIMARY KEY IDENTITY(1,1),
                FirstName NVARCHAR(50),
                LastName NVARCHAR(50),
                Street NVARCHAR(100),
                City NVARCHAR(50),
                PostalCode NVARCHAR(10),
                Pesel NVARCHAR(11),
                Email NVARCHAR(100)
            )";

string[] names = { "John", "Alice", "Bob" };
string[] lastNames = { "Doe", "Smith", "Johnson" };
string[] streets = { "Kwiatowa", "Zielona", "Niebieska" };
string[] cities = { "Jaslo", "Sanok", "Nisko" };
string[] postalCodes = { "38-200", "22-092", "01-123" };
string[] pesels = { "12345678901", "12312312312", "11111111111" };
string[] emails = { "Doe@john.eu", "Smith@alice.eu", "Johnson@bob.pl" };

Console.WriteLine($"Polecenie SQL: {createTableQuery}");
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    // Tworzenie tabeli (jeśli nie istnieje)
    using (SqlCommand createTableCommand = new SqlCommand(createTableQuery,connection))
    {
        
        try
        {
            createTableCommand.ExecuteNonQuery();
            Console.WriteLine("Tabela People utworzona.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd przy tworzeniu tabeli: {ex.Message}");
        }
    }
}


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
            ReadAndDisplayData(connectionString);
            break;
        case 2:
            AddPerson(connectionString);
            break;
        case 3:
            ModifyPerson(connectionString);
            break;
        case 4:
            RemovePerson(connectionString);
            break;
        case 5:
            m = false;
            Console.WriteLine("\n|| WYBRANO WYJŚCIE Z PROGRAMU ||");
            break;
        default:
            break;
    }
}

static void ReadAndDisplayData(string connectionString)
{
    string selectDataQuery = "SELECT * FROM People";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection))
        {
            using (SqlDataReader reader = selectDataCommand.ExecuteReader())
            {
                Console.WriteLine("\nLista osób w bazie danych:");
                while (reader.Read())
                {
                    string firstName = reader["FirstName"].ToString();
                    string lastName = reader["LastName"].ToString();
                    string street = reader["Street"].ToString();
                    string city = reader["City"].ToString();
                    string postalCode = reader["PostalCode"].ToString();
                    string pesel = reader["Pesel"].ToString();
                    string email = reader["Email"].ToString();
                    Console.WriteLine($"Imię: {firstName}, Nazwisko: {lastName}, Adres: {street}, {city}, {postalCode}, PESEL: {pesel}, Email: {email}");
                }
            }
        }
    }
}

static void AddPerson(string connectionString)
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO People (FirstName, LastName, Street, City, PostalCode, Pesel, Email) VALUES (@FirstName, @LastName, @Street, @City, @PostalCode, @Pesel, @Email)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", newFirstName);
                    command.Parameters.AddWithValue("@LastName", newLastName);
                    command.Parameters.AddWithValue("@Street", newStreet);
                    command.Parameters.AddWithValue("@City", newCity);
                    command.Parameters.AddWithValue("@PostalCode", newPostalCode);
                    command.Parameters.AddWithValue("@Pesel", newPeselInput);
                    command.Parameters.AddWithValue("@Email", newEmail);

                    command.ExecuteNonQuery();
                }
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

static void ModifyPerson(string connectionString)
{
    Console.WriteLine("\nWYBRANO MODYFIKUJ OSOBĘ");

    Console.Write("Wprowadź numer PESEL osoby do modyfikacji: ");
    string peselToModify = Console.ReadLine();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string selectQuery = "SELECT * FROM People WHERE Pesel = @Pesel";
        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
        {
            selectCommand.Parameters.AddWithValue("@Pesel", peselToModify);

            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    do
                    {
                        Console.WriteLine($"\nZnaleziono osobę: {reader["FirstName"]} {reader["LastName"]}");
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

                            string updateQuery = "UPDATE People SET FirstName = @FirstName, LastName = @LastName, Street = @Street, City = @City, PostalCode = @PostalCode, Email = @Email WHERE Pesel = @Pesel";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@FirstName", newFirstName);
                                updateCommand.Parameters.AddWithValue("@LastName", newLastName);
                                updateCommand.Parameters.AddWithValue("@Street", newStreet);
                                updateCommand.Parameters.AddWithValue("@City", newCity);
                                updateCommand.Parameters.AddWithValue("@PostalCode", newPostalCode);
                                updateCommand.Parameters.AddWithValue("@Pesel", peselToModify);
                                updateCommand.Parameters.AddWithValue("@Email", newEmail);

                                updateCommand.ExecuteNonQuery();
                            }

                            Console.WriteLine("-> OSOBA POMYŚLNIE ZAAKTUALIZOWANA");
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\nBŁĄD: {ex.Message}");
                            Console.WriteLine("\n!!! WPROWADŹ DANE PONOWNIE !!!");
                        }
                    }while(true);
                }
                else
                {
                    Console.WriteLine($"-> Osoba o numerze PESEL {peselToModify} nie została znaleziona.");
                }
            }
        }
    }
}

static void RemovePerson(string connectionString)
{
    Console.WriteLine("\n|| WYBRANO USUŃ OSOBĘ ||");

    Console.Write("\nWprowadź numer PESEL osoby do usunięcia: ");
    string peselToRemove = Console.ReadLine();

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();

        string deleteQuery = "DELETE FROM People WHERE Pesel = @Pesel";
        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
        {
            deleteCommand.Parameters.AddWithValue("@Pesel", peselToRemove);

            int rowsAffected = deleteCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine($"-> OSOBA ZOSTAŁA USUNIĘTA");
            }
            else
            {
                Console.WriteLine($"-> OSOBA NIE ZOSTAŁA USUNIĘTA (nie znaleziono numeru PESEL)");
            }
        }
    }
}