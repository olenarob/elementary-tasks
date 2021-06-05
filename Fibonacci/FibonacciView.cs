using NumericalSequences;
using System;

namespace Fibonacci
{
    class FibonacciView : ISequenceView
    {
        public void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("========================== Help =========================");
            Console.WriteLine("Usage: Fibonacci.exe <arg1> [<arg>2]");
            Console.WriteLine("mode 1: <arg1> - number of digits");
            Console.WriteLine("mode 2: <arg1> - lower range, <arg2> - upper range");
            Console.WriteLine();
        }

        public void DisplayTask()
        {
            Console.WriteLine();
            Console.WriteLine($"============== Task 8 Fibonacchi numbers ===============");
            Console.WriteLine("Output all numbers of Fibonacci that are in the specified");
            Console.WriteLine("range, or have a specified length (number of digits).");
            Console.WriteLine();
        }
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
        public void DisplayNumber(ulong number)
        {
            Console.Write($"{number} ");
        }
    }
}
