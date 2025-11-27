using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task2Age
    {
        public static void RunAgeCheck()
        {
            Console.Clear();
            Console.WriteLine("=== Age Checker ===");

            int age = ReadAge();
            string category = GetAgeCategory(age);

            Console.WriteLine($"\nYou are: {category}");
        }

        private static int ReadAge()
        {
            int age;
            while (true)
            {
                Console.Write("Enter your age: ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Empty input.");
                    continue;
                }

                if (!int.TryParse(input, out age))
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                    continue;
                }

                if (age < 0 || age > 125)
                {
                    Console.WriteLine("Error: Age must be between 0 and 125.");
                    continue;
                }

                return age;
            }
        }

        public static string GetAgeCategory(int age)
        {
            if (age >= 0 && age <= 10)
                return "Child";

            if (age <= 17)
                return "Teenager";

            return "Adult";
        }
    }
}
