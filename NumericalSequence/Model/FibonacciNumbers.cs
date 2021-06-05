namespace NumericalSequences
{
    public class FibonacciNumbers : NumericalSequence
    {
        private uint a = 0;
        private uint b = 0;

        public FibonacciNumbers(ISequenceRange range): base(range)
        {
        }

        protected override int GetNextElement()
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
            return (int)c;
        }
        protected override void Reset()
        {
            a = 0;
            b = 0;
        }
    }
}
