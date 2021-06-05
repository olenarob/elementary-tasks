using System;

namespace NumericalSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new SequenceView();

            try
            {
                view.DisplayTask7();
                
                uint m = uint.Parse(args[2]);
                int minSqrt = (int)Math.Ceiling(Math.Sqrt(m));
                
                var range = new SequenceWithLength(uint.Parse(args[1]), minSqrt);
                var model = new NaturalNumbers(range);
                var controller = new SequenceController(model, view);
                controller.DisplaySequence();
            }
            catch (IndexOutOfRangeException)
            {
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
