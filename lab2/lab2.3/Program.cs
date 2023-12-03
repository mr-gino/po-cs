class MojaData
{
    private DateTime data;

    public MojaData()
    {
        data = DateTime.Now;
    }

    public DateTime PobierzBieżącąDatę()
    {
        return data;
    }

    public void PrzestawNaTydzieńWPrzód()
    {
        data = data.AddDays(7);
    }

    public void PrzestawNaTydzieńWTył()
    {
        data = data.AddDays(-7);
    }
}

class Program
{
    static void Main()
    {
        MojaData mojaData = new MojaData();

        Console.WriteLine("Bieżąca data: " + mojaData.PobierzBieżącąDatę());

        mojaData.PrzestawNaTydzieńWPrzód();
        Console.WriteLine("Data po przestawieniu o tydzień w przód: " + mojaData.PobierzBieżącąDatę());

        mojaData.PrzestawNaTydzieńWTył();
        Console.WriteLine("Data po przestawieniu o tydzień w tył: " + mojaData.PobierzBieżącąDatę());

        Console.ReadLine();
    }
}