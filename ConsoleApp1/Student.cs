using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {

        public string StudentName { get; private set; }
        public int Age { get; private set; }

        public Student (string studentName, int age)
        {
            StudentName = studentName;
            Age = age;
        }
    }
}
