double[] numbers = new double[10];

Console.WriteLine("Wprowadź 10 liczb:");

for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"Liczba {i + 1}: ");
    numbers[i] = Convert.ToDouble(Console.ReadLine());
}
Console.WriteLine("\n");

double sum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    sum += numbers[i];
}
Console.WriteLine($"Suma elementów: {sum}");

double product = 1;
for (int i = 0; i < numbers.Length; i++)
{
    product *= numbers[i];
}
Console.WriteLine($"Iloczyn elementów: {product}");

double average = sum / numbers.Length;
Console.WriteLine($"Średnia elementów: {average}");

double min = numbers[0];
for (int i = 1; i < numbers.Length; i++)
{
    if (numbers[i] < min)
    {
        min = numbers[i];
    }
}
Console.WriteLine($"Wartość minimalna: {min}");

double max = numbers[0];
for (int i = 1; i < numbers.Length; i++)
{
    if (numbers[i] > max)
    {
        max = numbers[i];
    }
}
Console.WriteLine($"Wartość maksymalna: {max}");