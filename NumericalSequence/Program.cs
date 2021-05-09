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
                naturalNumbers.DisplaySeries(n, minSqr);
                
                var naturalNumbers1 = new NaturalNumbers();
                naturalNumbers1.DisplaySeries(0, minSqr, m);

                var fibonacci = new Fibonacci();
                fibonacci.DisplaySeries(n);
                
                var fibonacci1 = new Fibonacci();
                fibonacci1.DisplaySeries(0, minSqr, m);
            }
        }
    }
}
