class Uczen : Osoba
{
    public string Szkoła { get; private set; }
    public bool MozeSamWracacDoDomu { get; private set; }

    public void SetSchool(string school)
    {
        Szkoła = school;
    }

    public void ChangeSchool(string newSchool)
    {
        Szkoła = newSchool;
    }

    public void SetCanGoHomeAlone(bool canGoAlone)
    {
        MozeSamWracacDoDomu = canGoAlone;
    }

    public override bool CanGoAloneToHome()
    {
        if (GetAge() < 12)
            return MozeSamWracacDoDomu;
        else
            return true;
    }

    public override string GetEducationInfo()
    {
        return $"Uczeń {GetFullName()} uczęszcza do szkoły {Szkoła}.";
    }
}
