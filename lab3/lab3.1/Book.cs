using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Book
    {
        private string title;
        Person author { get; set; }
        DateTime datePublication { get; set; }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }




        public Book(string title, Person author, DateTime datePublication)
        {
            this.title = title;
            this.author = author;
            this.datePublication = datePublication;
        }

        public void View()
        {
            Console.Write($"\tTytul: {title} Autor: ");
            author.View2Atribut();
            Console.Write($"\t\tdata publikacji: {datePublication.ToShortDateString()}\n");
        }
    }
}
