using System;
using System.Collections.Generic;

namespace Sequence
{
    public abstract class Sequence
    {
        protected abstract uint GetNextElement();
        
        protected abstract void Reset();
        
        public IEnumerable<uint> GetSequence(uint length = 0, uint lowerRange = 0, uint upperRange = uint.MaxValue)
        {
            uint n = length;
            uint firstIndex = 0;
            uint tmp = GetNextElement();
            for (uint i = 0; (n == 0) ? (tmp <= upperRange) : (i < firstIndex + length); i++)
            {
                if (tmp < lowerRange)
                {
                    firstIndex++;
                }
                else
                    yield return tmp;
                tmp = GetNextElement();
            }
            Reset();
        }
        
        public void DisplaySequence(uint length = 0, uint lowerRange = 0, uint upperRange = uint.MaxValue)
        {
            foreach (int number in GetSequence(length, lowerRange, upperRange))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
    
    public class NaturalNumbers : Sequence
    {
        private uint _a = 0;
        protected override uint GetNextElement()
        {
            return _a++;
        }
        
        protected override void Reset()
        {
            _a = 0;
        }
    }

    public class Fibonacci : Sequence
    {
        private uint _a = 0;
        private uint _b = 0;
        protected override uint GetNextElement()
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
        
        protected override void Reset()
        {
            _a = 0;
            _b = 0;
        }
    }
}

