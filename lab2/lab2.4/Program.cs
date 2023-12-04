
class Liczba
{
    private int[] cyfry;

    public Liczba(string wartość)
    {
        UstawLiczbe(wartość);
    }

    public void UstawLiczbe(string wartość)
    {
        cyfry = new int[wartość.Length];

        for (int i = 0; i < wartość.Length; i++)
        {
            cyfry[i] = int.Parse(wartość[i].ToString());
        }
    }

    public void WypiszLiczbe()
    {
        for (int i = 0; i < cyfry.Length; i++)
        {
            Console.Write(cyfry[i]);
        }
        Console.WriteLine();
    }

    public void PomnóżPrzez(int mnożnik)
    {
        BigInteger wynik = ToBigInteger() * mnożnik;
        UstawLiczbe(wynik.ToString());
    }

    private BigInteger ToBigInteger()
    {
        string liczbaString = string.Join("", cyfry);
        return BigInteger.Parse(liczbaString);
    }

    public BigInteger Silnia()
    {
        BigInteger wynik = 1;
        BigInteger aktualnaLiczba = ToBigInteger();

        for (BigInteger i = 2; i <= aktualnaLiczba; i++)
        {
            wynik *= i;
        }

        return wynik;
    }
}

class Program
{
    static void Main()
    {
        Liczba liczba = new Liczba("123");
        liczba.WypiszLiczbe();

        liczba.PomnóżPrzez(5);
        liczba.WypiszLiczbe();

        Console.WriteLine($"Silnia liczby: {liczba.Silnia()}");

        Console.ReadLine();
    }
}
