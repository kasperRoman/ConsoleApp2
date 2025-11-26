using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task4
    {
        public static void SumRang()
        {
            Console.WriteLine("sum of numbers in a range");
                        int start, end;
            Console.WriteLine("Enter the start of the range:"); 
            while (true)
            {
                string? inputStart = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputStart))
                {
                    Console.WriteLine("Error: Empty input. Please enter a value.");
                    continue;
                }
                if (!int.TryParse(inputStart, out start))
                {
                    Console.WriteLine("Error: Invalid input. Please enter a numeric value.");
                    continue;
                }
                break;
            }
            Console.WriteLine("Enter the end of the range:");
            while (true)
            {
                string? inputEnd = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputEnd))
                {
                    Console.WriteLine("Error: Empty input. Please enter a value.");
                    continue;
                }
                if (!int.TryParse(inputEnd, out end))
                {
                    Console.WriteLine("Error: Invalid input. Please enter a numeric value.");
                    continue;
                }
                break;
            }
            int lower = Math.Min(start, end);
            int upper = Math.Max(start, end); 

            int sum = 0;
            for (int i = lower; i <= upper; i++)
            {
                sum += i;
            }
            Console.WriteLine($"Sum from {start} to {end} = {sum}");


        }
    }
}
