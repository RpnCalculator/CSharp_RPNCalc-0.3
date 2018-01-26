using System;

namespace Csd.Calculator
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var calc = new RPNCalculator();
            calc.WriteLine("Enter values followed by operation symbols: ");
            calc.Run(Console.In);
        }
    }
}
