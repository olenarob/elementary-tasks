using System;
using System.Collections.Generic;

namespace Sequence
{
    public abstract class Sequence
    {
        public abstract uint GetNext();
                    
        public static IEnumerable<uint> GetSeries(Sequence s, uint length = 0,
                            uint lowerRange = 0, uint upperRange = uint.MaxValue)
        {
            uint n = length;
            uint j = 0;
            uint tmp;
            for (uint i = 0; i <= n + j; i++)
            {
                tmp = s.GetNext();
                if (tmp < lowerRange)
                {
                    j++;
                }
                else
                {
                    if (length == 0)
                    {
                        if (tmp <= upperRange)
                        {
                            n++;
                        }
                    }
                    yield return tmp;
                }
            }
        }
        public static void DisplaySeries(Sequence s, uint length = 0,
                            uint lowerRange = 0, uint upperRange = uint.MaxValue)
        {
            foreach (int number in GetSeries(s, length, lowerRange, upperRange))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
    public class NaturalNumbers : Sequence
    {
        private uint _a = 0;
        public override uint GetNext()
        {
            return _a++;
        }
    }
    
    public class Fibonacci : Sequence
    {
        private uint _a = 0;
        private uint _b = 0;
        public override uint GetNext()
        {
            uint c = _a + _b;
            if (c == 0)
            {
                _a = 1;
            }
            else
            {
                _a = _b;
                _b = c;
            }
            return c;
        }
    }
}

