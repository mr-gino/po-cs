double a = 1;
double b = 3;
double c = -4;

double delta = Math.Pow(b, 2) - 4 * a * c;

double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

Console.WriteLine($"Delta wynosi: {delta}, x1 = {x1}, x2 = {x2}");