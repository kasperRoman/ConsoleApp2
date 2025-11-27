using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTable
{
    internal class Menu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Multiplication Table === ");
                Console.WriteLine("1. Show Table");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1": MultiplicationTable.Show(); Pause(); break;
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
