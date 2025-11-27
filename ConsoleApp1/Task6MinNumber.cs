using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task6MinNumber
    {
        public static void MinNumber()
        {    
            Console.Clear();
            int[] numbers = {12,5, 8, 3, 20, -4, 7 };   
            int minNumber = numbers.Min();
            Console.WriteLine($"The minimum number in the array [{string.Join(" ,",numbers)}]   is: {minNumber}");
        }
    }
}
