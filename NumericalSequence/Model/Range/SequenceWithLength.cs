namespace NumericalSequences
{
    public struct SequenceWithLength : ISequenceRange
    {
        private uint length;
        private int lowerRange;
        private int firstIndex;

        public SequenceWithLength(uint length, int lowerRange)
        {
            this.length = length;
            this.lowerRange = lowerRange;
            this.firstIndex = 0;
        }

        bool ISequenceRange.IsContinue(int nextElement, int index)
        {
            return index < firstIndex + length;
        }

        bool ISequenceRange.IsReturn(int nextElement, int index)
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
