using System.Collections.Generic;

namespace NumericalSequences
{
    public abstract class NumericalSequence
    {
        private readonly ISequenceRange range;

        protected NumericalSequence(ISequenceRange range)
        {
            this.range = range;
        }

        protected abstract ulong GetNextElement();

        protected abstract void Reset();

        public IEnumerable<ulong> GetSequence()
        {
            ulong tmp = GetNextElement();

            for (ulong i = 0; range.IsContinue(tmp, i); i++)
            {
                if (range.IsReturn(tmp, i))
                {
                    yield return tmp;
                }
                tmp = GetNextElement();
            }
            Reset();
        }
    }
}
