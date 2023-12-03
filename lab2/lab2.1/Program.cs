using System;

class Licz
{
    private int value;

    public Licz(int initialValue)
    {
        value = initialValue;
    }

    public void Dodaj(int number)
    {
        value += number;
    }

    public void Odejmij(int number)
    {
        value -= number;
    }

    public void WypiszStan()
    {
        Console.WriteLine($"Wartość: {value}");
    }
}

class Program
{
    static void Main()
    {
        Licz licz1 = new Licz(10);
        Licz licz2 = new Licz(5);

        licz1.Dodaj(7);
        licz2.Odejmij(3);

        licz1.WypiszStan();
        licz2.WypiszStan();
    }
}