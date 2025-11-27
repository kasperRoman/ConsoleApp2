using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Task7Calculator
    {
        public static void RunCalculator()
        {

            while (true)
            {
                Console.Clear();
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
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }
                string[] validChoices = { "1", "2", "3", "4", "5" };
                if (!validChoices.Contains(choice))
                {
                    Console.WriteLine("Error: Invalid choice.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }


                if (choice == "5")
                    break;

                double a = ReadDouble("Enter the first number: ");
                double b = ReadDouble("Enter the second number: ");

                double result = choice switch
                {
                    "1" => Calculator.Add(a, b),
                    "2" => Calculator.Subtract(a, b),
                    "3" => Calculator.Multiply(a, b),
                    "4" => Calculator.Divide(a, b),
                    _ => double.NaN
                };

                if (double.IsNaN(result))
                    Console.WriteLine(" Calculation error.");
                else
                    Console.WriteLine($" Result: {result}");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

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
