using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
 class Person
    {
        string firstName, lastName;
        int age;

        //właściwości pól
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //public Person(string firstName, string lastName, int age)
        //{
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.age = age;
        //}



        public void View() {
            Console.WriteLine($"Imie: {FirstName}\t\tnazwisko: {LastName}" +
                $"\t\twiek: {Age}");
        }
        public void View2Atribut() {
            Console.WriteLine($"Imie: {FirstName}\t\tnazwisko: {LastName}");
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
