using ArgumentsProcessor;
using Sequence;
using System;

namespace NumericalSequence
{
    class Program
    {
        static void Main(string[] args)
        {

            if (Argument.TryParse<int>(args[0], 0, int.MaxValue, out int n) &&
                Argument.TryParse<int>(args[1], 0, int.MaxValue, out int m))
            {
                int minSqr = (int)Math.Ceiling(Math.Sqrt(m));

                var naturalNumbers = new NaturalNumbers();
                naturalNumbers.DisplaySequenceOfLength(n, minSqr);

                var fibonacci = new Fibonaccy();
                fibonacci.DisplaySequenceOfLength(n, 0);
                if (n < m)
                fibonacci.DisplaySequenceInRange(n, m);
            }
        }
    }
}
