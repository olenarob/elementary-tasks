using System.Collections.Generic;

namespace NumericalSequences
{
    public abstract class NumericalSequence
    {
        private ISequenceRange range;

        protected NumericalSequence(ISequenceRange range)
        {
            this.range = range;
        }

        protected abstract int GetNextElement();

        protected abstract void Reset();

        public IEnumerable<int> GetSequence()
        {
            int tmp = GetNextElement();

            for (int i = 0; range.IsContinue(tmp, i); i++)
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
