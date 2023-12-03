class Sumator
{
    private int[] Liczby;

    public Sumator(int[] liczby)
    {
        Liczby = liczby;
    }

    public int Suma()
    {
        int suma = 0;
        foreach (var liczba in Liczby)
        {
            suma += liczba;
        }
        return suma;
    }

    public int SumaPodziel2()
    {
        int suma = 0;
        foreach (var liczba in Liczby)
        {
            if (liczba % 2 == 0)
                suma += liczba;
        }
        return suma;
    }

    public int IleElementów()
    {
        return Liczby.Length;
    }

    public void WypiszElementy()
    {
        foreach (var liczba in Liczby)
        {
            Console.Write($"{liczba} ");
        }
        Console.WriteLine();
    }

    public void WypiszElementyWZakresie(int lowIndex, int highIndex)
    {
        lowIndex = Math.Max(lowIndex, 0);
        highIndex = Math.Min(highIndex, Liczby.Length - 1);

        for (int i = lowIndex; i <= highIndex; i++)
        {
            Console.Write($"{Liczby[i]} ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        int[] tablicaLiczb = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Sumator sumator = new Sumator(tablicaLiczb);

        Console.WriteLine("Suma wszystkich elementów: " + sumator.Suma());
        Console.WriteLine("Suma elementów podzielnych przez 2: " + sumator.SumaPodziel2());
        Console.WriteLine("Liczba elementów w tablicy: " + sumator.IleElementów());

        Console.WriteLine("Wszystkie elementy tablicy:");
        sumator.WypiszElementy();

        Console.WriteLine("Elementy w zakresie od 2 do 7:");
        sumator.WypiszElementyWZakresie(2, 7);
    }
}
