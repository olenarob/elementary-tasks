namespace NumericalSequences
{
    public interface ISequenceView
    {
        void DisplayHelp();
        void DisplayTask();
        void DisplayMessage(string text);
        void DisplayNumber(ulong number);
    }
}
