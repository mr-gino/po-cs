using System;
using System.Collections.Generic;
using System.Linq;

Uczen uczen1 = new Uczen();
uczen1.SetFirstName("Jan");
uczen1.SetLastName("Kowalski");
uczen1.SetPesel("01234567890");
uczen1.SetSchool("Szkoła Podstawowa nr 1");
uczen1.SetCanGoHomeAlone(true);

Uczen uczen2 = new Uczen();
uczen2.SetFirstName("Anna");
uczen2.SetLastName("Wieczorek");
uczen2.SetPesel("11234567890");
uczen2.SetSchool("Szkoła Podstawowa nr 2");
uczen2.SetCanGoHomeAlone(true);

Nauczyciel nauczyciel = new Nauczyciel();
nauczyciel.SetFirstName("Jacek");
nauczyciel.SetLastName("Nowak");
nauczyciel.SetPesel("22234567890");
nauczyciel.SetSchool("Szkoła Podstawowa nr 3");

nauczyciel.AddStudent(uczen1);
nauczyciel.AddStudent(uczen2);

nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Now);