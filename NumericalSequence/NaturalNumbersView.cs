using System;

namespace NumericalSequences
{
    public class NaturalNumbersView : ISequenceView
    {
        public void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("========================== Help =========================");
            Console.WriteLine("Usage: NumericalSequence.exe <length of sequence> <min square>");
            Console.WriteLine();
        }

        public void DisplayTask()
        {
            Console.WriteLine();
            Console.WriteLine($"============== Task 7 Numerical numbers ================");
            Console.WriteLine("Output through the comma series with length n, consisting of");
            Console.WriteLine("natural numbers, the square of which is no less the specified m.");
            Console.WriteLine("Input arguments: length and value of minimum square.");
            Console.WriteLine("Output: string with a series of numbers.");
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
