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

        bool ISequenceRange.IsContinue(int nextElement, int index)
        {
            uint tmp = (uint)(nextElement / Math.Pow(10, numberOfDigits));
            return tmp == 0;
        }

        bool ISequenceRange.IsReturn(int nextElement, int index)
        {
            uint tmp = (uint)nextElement.ToString().Length;
            return tmp == numberOfDigits;
        }
    }
}
