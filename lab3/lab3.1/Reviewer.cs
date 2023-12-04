using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3._1
{
    class Reviewer : Reader
    {
        public Reviewer(Person person) : base(person)
        {
        }

        private int GenerateRandomRating()
        {
            Random random = new Random();
            return random.Next(1, 6); // Zakres ocen: 1-5
        }
        public void Wypisz()
        {
            Console.WriteLine($"Recenzje przez {FirstName} {LastName}:");
            foreach (Book book in ReadBooks)
            {
                Console.WriteLine($"- {book.Title}, Ocena: {GenerateRandomRating()}");
            }
        }

        
    }
}
