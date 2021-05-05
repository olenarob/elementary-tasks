using System;

namespace Sequence
{
    public abstract class Sequence
    {
        public abstract int CommonElement(int n);

        public void DisplaySequenceOfLength(int length, int lowerRange = 0)
        {
            int i = 0;
            while (CommonElement(i) < lowerRange)
            {
                i++;
            }
            int firstIndex = i;

            for (i = firstIndex; i < firstIndex + length; i++)
            {
                Console.Write($"{CommonElement(i)} ");
            }
            Console.WriteLine();
        }
        public void DisplaySequenceInRange(int lowerRange, int upperRange)
        {
            int i = 0;
            while (CommonElement(i) <= upperRange)
            {
                if (CommonElement(i) >= lowerRange)
                {
                    Console.Write($"{CommonElement(i)} ");
                }
                i++;
            }
            Console.WriteLine();
        }
    }
    public class NaturalNumbers : Sequence
    {
        public override int CommonElement(int n)
        {
            return n switch
            {
                0 => 0,
                _ => (CommonElement(n - 1) + 1),
            };
        }
    }
    public class Fibonaccy : Sequence
    {
        public override int CommonElement(int n)
        {
            return n switch
            {
                0 => 0,
                1 => 1,
                _ => (CommonElement(n - 1) + CommonElement(n - 2)),
            };
        }
    }
}

