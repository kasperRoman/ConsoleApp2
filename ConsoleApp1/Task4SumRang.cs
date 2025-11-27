using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task4SumRang
    {
        public static void RunSumRange()
        {
            Console.Clear();
            int start = ReadNumber("Enter the start of the range:");
            int end = ReadNumber("Enter the end of the range:");
            int sum = CalculateSum(start, end);
            Console.WriteLine($"\nSum from {start} to {end} = {sum}");
        }
        private static int ReadNumber(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Error: Input cannot be empty. Please enter a valid number.");
                    continue;
                }
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Error: Invalid input. Please enter a numeric value.");
                    continue;
                }

                return number;
            }
        }
        private static int CalculateSum(int start, int end)
        {
            int lower = Math.Min(start, end);
            int upper = Math.Max(start, end);

            int sum = 0;
            for (int i = lower; i <= upper; i++)
            {
                sum += i;
            }

            return sum;
        }

    }
}
