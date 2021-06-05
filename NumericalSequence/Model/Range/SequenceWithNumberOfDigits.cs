using System;

namespace NumericalSequences
{
    public struct SequenceWithNumberOfDigits : ISequenceRange
    {
        private uint numberOfDigits;

        public SequenceWithNumberOfDigits(uint numberOfDigits)
        {
            this.numberOfDigits = numberOfDigits;
        }

        public bool IsContinue(uint nextElement, int index)
        {
            uint tmp = nextElement / (uint)Math.Pow(10, numberOfDigits);
            return tmp == 0;
        }

        public bool IsReturn(uint nextElement, int index)
        {
            int tmp = nextElement.ToString().Length;
            return tmp == numberOfDigits;
        }
    }
}
