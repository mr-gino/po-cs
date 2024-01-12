class Osoba
{
    public string Imię { get; protected set; }
    public string Nazwisko { get; protected set; }
    public string Pesel { get; protected set; }

    public void SetFirstName(string firstName)
    {
        Imię = firstName;
    }

    public void SetLastName(string lastName)
    {
        Nazwisko = lastName;
    }

    public void SetPesel(string pesel)
    {
        Pesel = pesel;
    }

    public int GetAge()
    {
        int year = int.Parse(Pesel.Substring(0, 2));
        int month = int.Parse(Pesel.Substring(2, 2));
        int day = int.Parse(Pesel.Substring(4, 2));

        int currentYear = DateTime.Now.Year % 100;

        int age = currentYear - year;

        if (month > DateTime.Now.Month || (month == DateTime.Now.Month && day > DateTime.Now.Day))
        {
            age--;
        }

        return age;
    }

    public char GetGender()
    {
        return Pesel[9] % 2 == 0 ? 'K' : 'M';
    }

    public virtual string GetEducationInfo()
    {
        return "Podstawowe informacje o edukacji.";
    }

    public string GetFullName()
    {
        return $"{Imię} {Nazwisko}";
    }

    public virtual bool CanGoAloneToHome()
    {
        return true;
    }
}
