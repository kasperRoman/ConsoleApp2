using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task8Student
    {
        public static void Run()
        {
            StudentManeger manager = new StudentManeger();
            manager.AddStudent("Roman", 22);
            manager.AddStudent("Iryna", 17);
            manager.AddStudent("Iryna", 16);
            manager.AddStudent("Andrii", 19);
            manager.AddStudent("Oksana", 25);
            manager.AddStudent("Iryna", 18);

            Console.WriteLine("All students:");
            foreach (Student student in manager.GetAllStudents())
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n =====Filter by age (>18)=====");
            foreach (Student s in manager.FilterByMinAge(18))
                Console.WriteLine(s);

            Console.WriteLine("\n=== Oldest Student ===");
            Student? oldest = manager.GetOldestStudent();
            Console.WriteLine(oldest != null ? oldest.ToString() : "No student found"); 
        }
    }
}
