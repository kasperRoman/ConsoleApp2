using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("На нуль ділити не можна.");
                return double.NaN;
            }
            return a / b;
        }
    }
}
