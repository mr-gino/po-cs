class Nauczyciel : Uczen
{
    public string TytulNaukowy { get; private set; }
    public List<Uczen> PodwladniUczniowie { get; private set; }

    public Nauczyciel()
    {
        PodwladniUczniowie = new List<Uczen>();
    }

    public void AddStudent(Uczen student)
    {
        PodwladniUczniowie.Add(student);
    }

    public void RemoveStudent(Uczen student)
    {
        PodwladniUczniowie.Remove(student);
    }

    public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
    {
        Console.WriteLine($"Uczniowie, którzy mogą iść sami do domu w dniu {dateToCheck.ToShortDateString()}:");
        foreach (var student in PodwladniUczniowie)
            if (student.CanGoAloneToHome())
                Console.WriteLine(student.GetFullName());
    }
}
