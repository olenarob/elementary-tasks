namespace NumericalSequences
{
    public struct SequenceInRange : ISequenceRange
    {
        private int lowerRange;
        private int upperRange;

        public SequenceInRange(int lowerRange, int upperRange)
        {
            this.lowerRange = lowerRange;
            this.upperRange = upperRange;
        }

        bool ISequenceRange.IsContinue(int nextElement, int index)
        {
            return nextElement <= upperRange;
        }

        bool ISequenceRange.IsReturn(int nextElement, int index)
        {
            return nextElement >= lowerRange;
        }
    }
}
