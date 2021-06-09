using System;

namespace NumericalSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new NaturalNumbersView();

            try
            {
                ulong m = ulong.Parse(args[1]);
                ulong minSqrt = (ulong)Math.Ceiling(Math.Sqrt(m));
                
                var range = new SequenceWithLength(ulong.Parse(args[0]), minSqrt);
                var model = new NaturalNumbers(range);
                
                var controller = new SequenceController(model, view);
                controller.DisplaySequence();
            }
            catch (IndexOutOfRangeException)
            {
                view.DisplayTask();
                view.DisplayHelp();
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
                view.DisplayHelp();
            }
        }
    }
}
