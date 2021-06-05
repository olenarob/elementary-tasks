using System;

namespace NumericalSequences
{
    public struct SequenceInRange : ISequenceRange
    {
        private readonly ulong lowerRange;
        private readonly ulong upperRange;

        public SequenceInRange(ulong lowerRange, ulong upperRange)
        {
            if (lowerRange > upperRange)
            {
                throw new ArgumentException("Upper range can not be less than lower range!");
            }
            
            this.lowerRange = lowerRange;
            this.upperRange = upperRange;
        }

        bool ISequenceRange.IsContinue(ulong nextElement, ulong index)
        {
            return nextElement <= upperRange;
        }

        bool ISequenceRange.IsReturn(ulong nextElement, ulong index)
        {
            return nextElement >= lowerRange;
        }
    }
}
