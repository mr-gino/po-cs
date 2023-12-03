Console.Write("Podaj liczbę elementów: ");
int n = Convert.ToInt32(Console.ReadLine());

int[] numbers = new int[n];

Console.WriteLine("Wprowadź liczby:");

for (int i = 0; i < n; i++)
{
    Console.Write($"Liczba {i + 1}: ");
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}

BubbleSort(numbers);

Console.WriteLine("Posortowane liczby:");

for (int i = 0; i < n; i++)
{
    Console.Write(numbers[i] + " ");
}

static void BubbleSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}