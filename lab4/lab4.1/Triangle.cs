class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine($"Rysuję trójkąt na pozycji X = {X}, Y = {Y} o szerokości {Width} i wysokości {Height}.");
    }
}
