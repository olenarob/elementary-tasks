using ArgumentsProcessor;
using Sequence;
using System;

namespace NumericalSequence
{
    class Program
    {
        static void Main(string[] args)
        {

            if (Argument.TryParse<uint>(args[0], 1, uint.MaxValue, out uint n) &&
                Argument.TryParse<uint>(args[1], 0, uint.MaxValue, out uint m))
            {
                uint minSqr = (uint)Math.Ceiling(Math.Sqrt(m));

                var naturalNumbers = new NaturalNumbers();
               
                foreach (int number in NaturalNumbers.GetSeriesOfLength(naturalNumbers, n, minSqr))
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();

                var naturalNumbers1 = new NaturalNumbers();
                foreach (int number in NaturalNumbers.GetSeriesInRange(naturalNumbers1, minSqr, m))
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();

                var fibonacci = new Fibonacci();
                foreach (int number in Fibonacci.GetSeriesOfLength(fibonacci, n))
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
                
                var fibonacci1 = new Fibonacci();
                foreach (int number in Fibonacci.GetSeriesInRange(fibonacci1, minSqr, m))
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
