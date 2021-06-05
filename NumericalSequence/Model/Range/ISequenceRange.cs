namespace NumericalSequences
{
    public interface ISequenceRange
    {
        bool IsContinue(uint nextElement, int index);
        bool IsReturn(uint nextElement, int index);
    }
}
