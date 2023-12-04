class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine($"Rysuję prostokąt na pozycji X = {X}, Y = {Y} o szerokości {Width} i wysokości {Height}.");
    }
}
