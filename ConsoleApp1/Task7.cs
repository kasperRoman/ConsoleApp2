using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Task7
    {
        public static void RunCalculator()
        {
            Calculator calc = new Calculator();

            while (true)
            {
                Console.WriteLine("\n=== Calculator ===");
                Console.WriteLine("1. Addition (+)");
                Console.WriteLine("2. Subtraction (-)");
                Console.WriteLine("3. Multiplication (*)");
                Console.WriteLine("4. Division (/)");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                string? choice = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Error: Empty input.");
                    continue;
                }
                string[] validChoices = { "1", "2", "3", "4", "5" };
                if (!validChoices.Contains(choice))
                {
                    Console.WriteLine("Error: Invalid choice.");
                    continue;
                }


                if (choice == "5")
                    break;


                double a = ReadDouble("Enter the first number: "); 
                double b = ReadDouble("Enter the second number: ");

  

                double result = choice switch
                {
                    "1" => calc.Add(a, b),
                    "2" => calc.Subtract(a, b),
                    "3" => calc.Multiply(a, b),
                    "4" => calc.Divide(a, b),
                    _ => double.NaN
                };

                if (double.IsNaN(result))
                    Console.WriteLine(" Calculation error.");
                else
                    Console.WriteLine($" Result: {result}");

            }
        }
        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);  
                string? input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out double number))
                {
                    Console.WriteLine("Error: Invalid number.");
                    continue;
                }
                return number;
            }
        }
    }
}
