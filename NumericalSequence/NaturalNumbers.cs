namespace NumericalSequence
{
    public class NaturalNumbers : Sequence
    {
        private uint a = 0;
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
