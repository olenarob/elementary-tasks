namespace NumericalSequences
{
    public struct SequenceWithLength : ISequenceRange
    {
        private uint length;
        private uint lowerRange;
        int firstIndex;

        public SequenceWithLength(uint length, uint lowerRange)
        {
            this.length = length;
            this.lowerRange = lowerRange;
            this.firstIndex = 0;
        }

        public bool IsContinue(uint nextElement, int index)
        {
            return index < firstIndex + length;
        }

        public bool IsReturn(uint nextElement, int index)
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
