class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine($"Rysuję koło na pozycji X = {X}, Y = {Y} o średnicy {(Width+Height)/2}.");
    }
}
