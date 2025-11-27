using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StudentManeger
    {
        private readonly List<Student> _students = new();
        
        public void AddStudent (string name, int age)
        {
           _students.Add( new Student (name, age));
        }
        public List<Student> FilterByMinAge(int minAge)
        {
            return _students.Where(s => s.Age >= minAge).ToList();

        }
        public Student? GetOldestStudent()
        {
            if (_students.Count == 0)
                return null;
            return _students.OrderByDescending(s => s.Age).FirstOrDefault(); ; //сортує список студентів за спаданням віку та повертає першого студента
        }
        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }
}
