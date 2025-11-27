using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task1Temperature
    {
        public static void ConvertCelsiusToFahrenheit()
        {    
            Console.Clear();
            Console.WriteLine("Task 1: Celsius to Fahrenheit");
            double celsius;
            Console.WriteLine("Enter the temperature in degrees Celsius");
            while (true)
            {
                string? inputCelsius = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCelsius))
                {
                    Console.WriteLine("Error: Empty input. Please enter a value.");
                    continue;
                }
                if (!double.TryParse(inputCelsius, out celsius))
                {
                    Console.WriteLine("Error: Invalid input. Please enter a numeric value.");
                    continue;
                }
                break;
            }
    
            Console.WriteLine($"\n celsius:{celsius}°C= fahrenheit{Convert(celsius)}°F");

        }
        public static double Convert(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }
}