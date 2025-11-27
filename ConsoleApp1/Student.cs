using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {

        public string StudentName { get; }
        public int Age { get; }

        public Student (string studentName, int age)
        {
            StudentName = studentName;
            Age = age;
        }
        public override string ToString()
        {
            return $" {StudentName} {Age}y/o";
        }
    }
}
