namespace NumericalSequences
{
    public class Fibonacci : NumericalSequence
    {
        private uint a = 0;
        private uint b = 0;

        public Fibonacci(ISequenceRange range): base(range)
        {
        }

        protected override uint GetNextElement()
        {
            uint c = a + b;
            switch (c)
            {
                case 0:
                    a = 1;
                    break;
                default:
                    a = b;
                    b = c;
                    break;
            }
            return c;
        }
        protected override void Reset()
        {
            a = 0;
            b = 0;
        }
    }
}
