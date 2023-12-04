using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Shape> kształty = new List<Shape>();

        Rectangle prostokąt = new Rectangle { X = 10, Y = 20, Width = 30, Height = 40 };
        Triangle trójkąt = new Triangle { X = 50, Y = 60, Width = 70, Height = 80 };
        Circle koło = new Circle { X = 90, Y = 100, Width = 110, Height = 110 };

        kształty.Add(prostokąt);
        kształty.Add(trójkąt);
        kształty.Add(koło);

        foreach (var kształt in kształty)
        {
            kształt.Draw();
        }
    }
}
