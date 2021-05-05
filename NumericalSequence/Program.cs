using System;

namespace NumericalSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(args[0]);
            int m = int.Parse(args[1]);

            int lowerRange = (int)Math.Ceiling(Math.Sqrt(m));
            
            Sequence naturalNumbers = new NaturalNumbers();
            naturalNumbers.DisplaySequence(lowerRange, length: n);
            naturalNumbers.DisplaySequence();

            Sequence fibonacci = new Fibonaccy();
            fibonacci.DisplaySequence(length: n);
            fibonacci.DisplaySequence(13, 1000);
        }

        public abstract class Sequence
        {
            public abstract int CommonElement(int n);

            public void DisplaySequenceOfLength (int index, int length)
            {
                for (int i = index; i < index + length; i++)
                {
                    Console.Write($"{CommonElement(i)} ");
                }
                Console.WriteLine();
            }
            public void DisplaySequence(int lowerRange = 0, int upperRange = int.MaxValue, int length = 0)
            {
                int index = 0;
                int i = 0;
                bool flag = true;
                while (((length == 0) && (CommonElement(i) <= upperRange)) || (i < index + length))
                {
                    if (CommonElement(i) >= lowerRange)
                    {
                        if (flag)
                        {
                            index = i;
                            flag = false;
                        }
                        Console.Write($"{CommonElement(i)} ");
                    }
                    i++;
                }
                Console.WriteLine();
            }
        }
        public class NaturalNumbers : Sequence
        {
            public override int CommonElement (int n)
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
}
