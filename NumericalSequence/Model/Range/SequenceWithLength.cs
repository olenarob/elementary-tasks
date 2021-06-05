namespace NumericalSequences
{
    public struct SequenceWithLength : ISequenceRange
    {
        private readonly ulong length;
        private readonly ulong lowerRange;
        private ulong firstIndex;

        public SequenceWithLength(ulong length, ulong lowerRange)
        {
            this.length = length;
            this.lowerRange = lowerRange;
            this.firstIndex = 0;
        }

        bool ISequenceRange.IsContinue(ulong nextElement, ulong index)
        {
            return index < firstIndex + length;
        }

        bool ISequenceRange.IsReturn(ulong nextElement, ulong index)
        {
            bool result = (nextElement >= lowerRange);

            if (!result)
            {
                firstIndex++;
            }

            return result;
        }
    }
}
