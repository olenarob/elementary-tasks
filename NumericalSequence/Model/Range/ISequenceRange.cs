namespace NumericalSequences
{
    public interface ISequenceRange
    {
        bool IsContinue(ulong nextElement, ulong index);
        bool IsReturn(ulong nextElement, ulong index);
    }
}
