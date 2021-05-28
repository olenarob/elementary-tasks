using System;
using System.Collections.Generic;

namespace NumericalSequence
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
                {
                    yield return tmp;
                }

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
}
