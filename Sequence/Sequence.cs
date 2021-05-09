using System;
using System.Collections.Generic;

namespace Sequence
{
    public abstract class Sequence
    {
        public abstract uint GetNext();
                    
        public static IEnumerable<uint> GetSeriesOfLength(Sequence s, uint length, uint lowerRange = 0)
        {
            uint j = 0;
            uint tmp = s.GetNext();
            for (uint i = 0; i < length + j; i++)
            {
                if (tmp < lowerRange)
                {
                    j++;
                }
                else
                    yield return tmp;
                tmp = s.GetNext();
            }    
        }
        public static IEnumerable<uint> GetSeriesInRange(Sequence s, uint lowerRange, uint upperRange)
        {
            uint tmp = s.GetNext();
            
            while (tmp <= upperRange)
            {
                if (tmp >= lowerRange)
                {
                    yield return tmp;
                }
                tmp = s.GetNext();
            }
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

