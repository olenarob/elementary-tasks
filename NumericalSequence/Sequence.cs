using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    
}

