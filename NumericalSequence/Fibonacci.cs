namespace NumericalSequence
{
    public class Fibonacci : Sequence
    {
        private uint a = 0;
        private uint b = 0;
        protected override uint GetNextElement()
        {
            uint c = a + b;

            if (c == 0)
            {
                a = 1;
            }
            else
            {
                a = b;
                b = c;
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
