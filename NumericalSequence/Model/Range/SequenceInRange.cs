namespace NumericalSequences
{
    public struct SequenceInRange : ISequenceRange
    {
        private uint lowerRange;
        private uint upperRange;

        public SequenceInRange(uint lowerRange, uint upperRange)
        {
            this.lowerRange = lowerRange;
            this.upperRange = upperRange;
        }

        public bool IsContinue(uint nextElement, int index)
        {
            return nextElement <= upperRange;
        }

        public bool IsReturn(uint nextElement, int index)
        {
            return nextElement >= lowerRange;
        }
    }
}
