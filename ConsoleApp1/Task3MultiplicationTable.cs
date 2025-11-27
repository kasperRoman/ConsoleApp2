using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task3MultiplicationTable
    {
        public static void Show()
        {
            int number = ReadNumber();
            PrintTable(number);
        }
        private static int ReadNumber()
        {
            while (true)
            {
                Console.Write("Enter a number: ");
                string? input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a valid number.");
                    continue;
                }
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }
                return number;
            }
        }
        private static void PrintTable(int number)
        {
            Console.WriteLine($"\nMultiplication Table for {number}:\n");
            for (int i = 1; i <= 10; i++)
            {
                int result = number * i;
                Console.WriteLine($"{number} x {i} = {result}");

            }
        }
    }
}
