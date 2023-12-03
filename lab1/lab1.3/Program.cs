double[] numbers = new double[10];

Console.WriteLine("Wprowadź 10 liczb rzeczywistych:");

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"Liczba {i + 1}: ");
    numbers[i] = Convert.ToDouble(Console.ReadLine());
}

Console.WriteLine("\nWyświetlanie tablicy od pierwszego do ostatniego indeksu:");

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write(numbers[i] + " ");
}

Console.WriteLine("\n\nWyświetlanie tablicy od ostatniego do pierwszego indeksu:");

for (int i = numbers.Length - 1; i >= 0; i--)
{
    Console.Write(numbers[i] + " ");
}

Console.WriteLine("\n\nWyświetlanie elementów o nieparzystych indeksach:");

for (int i = 1; i < numbers.Length; i += 2)
{
    Console.Write(numbers[i] + " ");
}

Console.WriteLine("\n\nWyświetlanie elementów o parzystych indeksach:");

for (int i = 0; i < numbers.Length; i += 2)
{
    Console.Write(numbers[i] + " ");
}

Console.ReadLine();