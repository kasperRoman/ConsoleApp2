using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task5BookList
    {
        public static void ShowList() {  
            Console.Clear();
            Console.WriteLine("Book List:");

            Book book1 = new Book("1984", "George Orwell", 1949);
            Book book2 = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
            Book book3 = new Book("Clean Code", "Robert C. Martin", 2008);

            book1.PrintInfo();
            book2.PrintInfo();
            book3.PrintInfo();

        }
        }
    }

