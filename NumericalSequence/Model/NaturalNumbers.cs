namespace NumericalSequences
{
    public class NaturalNumbers : NumericalSequence
    {
        private uint a = 0;

        public NaturalNumbers(ISequenceRange range) : base(range)
        {
        }

        protected override uint GetNextElement()
        {
            return a++;
        }
        protected override void Reset()
        {
            a = 0;
        }
    }
}
