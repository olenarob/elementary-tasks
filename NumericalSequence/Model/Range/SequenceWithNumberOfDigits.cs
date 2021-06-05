using System;

namespace NumericalSequences
{
    public struct SequenceWithNumberOfDigits : ISequenceRange
    {
        private readonly ulong lowerRange;
        private readonly ulong upperRange;

        public SequenceWithNumberOfDigits(byte numberOfDigits)
        {
            byte maxNumberOfDigits = (byte)Math.Log10(ulong.MaxValue);
            if (numberOfDigits > maxNumberOfDigits)
            {
                throw new OverflowException($"Number of digits can not be more than {maxNumberOfDigits}");
            }
            
            this.lowerRange = (ulong)Math.Pow(10, numberOfDigits - 1);
            this.upperRange = (ulong)Math.Pow(10, numberOfDigits);
        }

        bool ISequenceRange.IsContinue(ulong nextElement, ulong index)
        {
            return nextElement <= upperRange;
        }

        bool ISequenceRange.IsReturn(ulong nextElement, ulong index)
        {
            return nextElement > lowerRange && nextElement <= upperRange;
        }
    }
}
