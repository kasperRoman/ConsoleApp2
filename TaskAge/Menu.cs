using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAge
{
    static class Menu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==Main Menu==");
                Console.WriteLine("1. Age Checker");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1": AgeChecker.RunAgeCheck(); Pause(); break;
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
