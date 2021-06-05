namespace NumericalSequences
{
    public class FibonacciNumbers : NumericalSequence
    {
        private ulong a = 0;
        private ulong b = 0;

        public FibonacciNumbers(ISequenceRange range): base(range)
        {
        }

        protected override ulong GetNextElement()
        {
            ulong c = a + b;
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
