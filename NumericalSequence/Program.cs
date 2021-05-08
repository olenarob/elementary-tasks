using Sequence;
using System;

namespace NumericalSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(args[0]);
            int m = int.Parse(args[1]);

            int minSqr = (int)Math.Ceiling(Math.Sqrt(m));

            var naturalNumbers = new NaturalNumbers();
            naturalNumbers.DisplaySequenceOfLength(n, minSqr);

            var fibonacci = new Fibonaccy();
            fibonacci.DisplaySequenceOfLength(length: n);
            fibonacci.DisplaySequenceInRange(n, m);
        }
    }
}
