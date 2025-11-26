using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {

        public string Title { get; private set; }
        public string Author { get; private set; }

        private int _year;
        public int Year
        {
            get=> _year;
            set
            {
                if (value <0 || value >DateTime.Now.Year)
                    throw new ArgumentException("Year must be a valid positive number not greater than current year.");
                    _year = value;
                
            }
        }

        public Book(string title, string author, int year)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Author cannot be empty.");

            Title = title;
            Author = author;
            Year = year; 
        }
        public void PrintInfo()
        {
            Console.WriteLine($" \"{Title}\" by {Author}, published in {Year}");
        }

    }
}

