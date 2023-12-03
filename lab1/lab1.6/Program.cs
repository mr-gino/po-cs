while (true)
{
    Console.Write("Podaj liczbę całkowitą (aby zakończyć, wprowadź liczbę mniejszą od zera): ");
    int liczba = Convert.ToInt32(Console.ReadLine());

    if (liczba < 0)
    {
        Console.WriteLine("Koniec programu.");
        break;
    }

}