using System;

namespace Sequence
{
    public abstract class Sequence
    {
        public abstract int CommonElement(int n);

        public void DisplaySequenceOfLength(int length, int lowerRange)
        {
            int firstIndex = 0;
            for (int i = 0; i < firstIndex + length; i++)
            {
                if (CommonElement(i) < lowerRange)
                {
                    firstIndex++;
                }
                else
                {
                    Console.Write($"{CommonElement(i)} ");
                }
            }
            Console.WriteLine();
        }
        public void DisplaySequenceInRange(int lowerRange, int upperRange)
        {
            for (int i = 0; CommonElement(i) <= upperRange; i++)
            {
                if (CommonElement(i) >= lowerRange)
                {
                    Console.Write($"{CommonElement(i)} ");
                }
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

