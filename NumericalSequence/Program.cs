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
                naturalNumbers.DisplaySequence(n, minSqr);
                naturalNumbers.DisplaySequence(0, minSqr, m);

                var fibonacci = new Fibonacci();
                fibonacci.DisplaySequence(n);
                fibonacci.DisplaySequence(0, minSqr, m);
            }
        }
    }
}
