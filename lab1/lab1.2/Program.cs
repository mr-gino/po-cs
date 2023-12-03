while (true)
{
    Console.WriteLine("- - - - - - - - -");
    Console.WriteLine("Wybierz operację:");
    Console.WriteLine("1. Suma");
    Console.WriteLine("2. Różnica");
    Console.WriteLine("3. Iloczyn");
    Console.WriteLine("4. Iloraz");
    Console.WriteLine("5. Potęga");
    Console.WriteLine("6. Pierwiastek");
    Console.WriteLine("7. Sinus");
    Console.WriteLine("8. Cosinus");
    Console.WriteLine("9. Tangens");
    Console.WriteLine("10. Cotangens");
    Console.WriteLine("0. Wyjście");
    Console.WriteLine("- - - - - - - - -");

    Console.Write("Twój wybór: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    double result = 0;

    switch (choice)
    {
        case 1:
            result = Sum();
            break;
        case 2:
            result = Subtract();
            break;
        case 3:
            result = Multiply();
            break;
        case 4:
            result = Divide();
            break;
        case 5:
            result = Power();
            break;
        case 6:
            result = SquareRoot();
            break;
        case 7:
            result = TrigonometricFunction("sin");
            break;
        case 8:
            result = TrigonometricFunction("cos");
            break;
        case 9:
            result = TrigonometricFunction("tan");
            break;
        case 10:
            result = TrigonometricFunction("cot");
            break;
        case 0:
            Console.WriteLine("Koniec programu");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            continue;
    }

    Console.WriteLine($"Wynik: {result}");
}


    static double Sum()
{
    Console.Write("Podaj pierwszą liczbę: ");
    double num1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Podaj drugą liczbę: ");
    double num2 = Convert.ToDouble(Console.ReadLine());
    return num1 + num2;
}

static double Subtract()
{
    Console.Write("Podaj odjemną: ");
    double num1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Podaj odjemnik: ");
    double num2 = Convert.ToDouble(Console.ReadLine());
    return num1 - num2;
}

static double Multiply()
{
    Console.Write("Podaj pierwszą liczbę: ");
    double num1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Podaj drugą liczbę: ");
    double num2 = Convert.ToDouble(Console.ReadLine());
    return num1 * num2;
}

static double Divide()
{
    Console.Write("Podaj dzielną: ");
    double num1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Podaj dzielnik: ");
    double num2 = Convert.ToDouble(Console.ReadLine());

    if (num2 != 0)
    {
        return num1 / num2;
    }
    else
    {
        Console.WriteLine("Nie dziel przez 0!");
        return 0;
    }
}

static double Power()
{
    Console.Write("Podaj liczbę: ");
    double num = Convert.ToDouble(Console.ReadLine());
    Console.Write("Podaj wykładnik potęgi: ");
    double exponent = Convert.ToDouble(Console.ReadLine());
    return Math.Pow(num, exponent);
}

static double SquareRoot()
{
    Console.Write("Podaj liczbę do pierwiastkowania: ");
    double num = Convert.ToDouble(Console.ReadLine());
    return Math.Sqrt(num);
}

static double TrigonometricFunction(string functionName)
{
    Console.Write("Podaj kąt w radianach: ");
    double angle = Convert.ToDouble(Console.ReadLine());

    switch (functionName.ToLower())
    {
        case "sin":
            return Math.Sin(angle);
        case "cos":
            return Math.Cos(angle);
        case "tan":
            return Math.Tan(angle);
        case "cot":
            return 1 / Math.Tan(angle);
        default:
            Console.WriteLine("Nieprawidłowa funkcja trygonometryczna.");
            return 0;
    }
}
