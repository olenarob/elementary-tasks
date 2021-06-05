namespace NumericalSequences
{
    public class NaturalNumbers : NumericalSequence
    {
        private ulong a = 1;

        public NaturalNumbers(ISequenceRange range) : base(range)
        {
        }

        protected override ulong GetNextElement()
        {
            return a++;
        }

        protected override void Reset()
        {
            a = 0;
        }
    }
}
