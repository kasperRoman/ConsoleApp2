using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task2
    {
        public static void SelectAgeCategory()
        {   
                Console.WriteLine("enter your age");
            int age;
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("enter your age");
                    continue;
                }
                if (!int.TryParse(input,out  age))
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }
                if (age > 125 || age <0 )
                {
                    Console.WriteLine("Error: Age must be between 0 and 125 .Please try again");
                    continue;
                }
                break;
                
            }
            if (age > 0 && age <= 10){
                Console.WriteLine("You are Child");
            }
            else if (age>10 && age < 18)
            {
                Console.WriteLine("You are teenager");
            }
            else
            {
                Console.WriteLine("You are adult");
            }

        }
    }
}
