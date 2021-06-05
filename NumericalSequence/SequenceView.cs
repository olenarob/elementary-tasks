using System;

namespace NumericalSequences
{
    public class SequenceView
    {
        public void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("======================== Help =======================");
            Console.WriteLine("Usage: NumericalSequence.exe <mode> <arg1> [<arg2>]");
            Console.WriteLine("mode: 1 - NaturalNumbers, 2 - Fibonacci");
        }

        public void DisplayTask7()
        {
            Console.WriteLine();
            Console.WriteLine($"============= Task 7 Numerical numbers =============");
            Console.WriteLine("Output through the comma series with length n, consisting of");
            Console.WriteLine("natural numbers, the square of which is no less the specified m.");
            Console.WriteLine("Input: length and value of minimum square.");
            Console.WriteLine("Output: string with a series of numbers.");
            Console.WriteLine();
        }

        public void DisplayTask8()
        {
            Console.WriteLine();
            Console.WriteLine($"================ Task 8 Fibonacchi =================");
            Console.WriteLine("Output all numbers of Fibonacci that are in the specified");
            Console.WriteLine("range, or have a specified length.");
            Console.WriteLine();
        }
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }
        public void DisplayNumber(int number)
        {
            Console.Write($"{number} ");
        }
        public string GetUserMessage(string text)
        {
            Console.WriteLine();
            Console.Write(text);
            return Console.ReadLine();
        }
    }
}
