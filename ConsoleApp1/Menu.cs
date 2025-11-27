using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Menu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==Main Menu==");
                Console.WriteLine("1. Convert celsius to fahrenheit");
                Console.WriteLine("2. Age Checker");
                Console.WriteLine("3. Multiplication Table ");
                Console.WriteLine("4. Sum numbers in a range ");
                Console.WriteLine("5. Book list ");
                Console.WriteLine("6.Min number ");
                Console.WriteLine("7.Calculator ");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");
                string? input = Console.ReadLine(); 
                switch (input)
                {
                    case "1": Task1Temperature.ConvertCelsiusToFahrenheit(); Pause(); break;
                    case "2": Task2Age.RunAgeCheck(); Pause(); break;
                    case "3": Task3MultiplicationTable.Show(); Pause(); break;
                    case "4": Task4SumRang.RunSumRange(); Pause(); break;
                    case "5": Task5BookList.ShowList(); Pause(); break;
                    case "6": Task6MinNumber.MinNumber(); Pause(); break;
                    case "7": Task7Calculator.RunCalculator(); Pause(); break;
                    case "0": Console.WriteLine("Goodbye!"); return;
                    default: Console.WriteLine("Invalid option."); Pause(); break;
                }
            }
        }
        private static void Pause()
        {
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
