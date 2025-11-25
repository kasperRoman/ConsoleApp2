using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task3
    {
        public static void ShowMultiplicationTable()
        {
            Console.WriteLine("enter a number ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("enter a number ");
                    continue;
                }
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                for (int i = 1; i <= 10; i++)
                {
                    int result = number * i;
                    Console.WriteLine($"{number} x {i} = {result}");
                }
                break;
            }

        }
    }
}
