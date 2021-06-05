namespace NumericalSequences
{
    public interface ISequenceRange
    {
        bool IsContinue(int nextElement, int index);
        bool IsReturn(int nextElement, int index);
    }
}
