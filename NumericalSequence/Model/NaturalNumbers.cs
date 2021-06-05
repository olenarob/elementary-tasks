namespace NumericalSequences
{
    public class NaturalNumbers : NumericalSequence
    {
        private uint a = 0;

        public NaturalNumbers(ISequenceRange range) : base(range)
        {
        }

        protected override int GetNextElement()
        {
            return (int)a++;
        }

        protected override void Reset()
        {
            a = 0;
        }
    }
}
