using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Person
    {
        private string firstName, lastName;
        private int age;

        //właściwości pól

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        /*        public Person(string firstName, string lastName, int age)
                {
                    this.firstName = firstName;
                    this.lastName = lastName;
                    this.age = age;
                }
        */


        public virtual void View()
        {
            Console.WriteLine($"Imie: {FirstName}\t\tnazwisko: {LastName}" +
                $"\t\twiek: {Age}");
        }
        public void View2Atribut()
        {
            Console.WriteLine($"{FirstName} {LastName}");
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
