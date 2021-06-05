using NumericalSequences;
using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new SequenceView();

            try
            {
                switch (args.Length)
                {
                    case 1:
                        view.DisplayTask8();
                        var range1 = new SequenceWithNumberOfDigits(uint.Parse(args[0]));
                        var model1 = new FibonacciNumbers(range1);
                        var controller1 = new SequenceController(model1, view);
                        controller1.DisplaySequence();
                        break;
                    case 2:
                        view.DisplayTask8();
                        var range2 = new SequenceInRange(int.Parse(args[0]), int.Parse(args[1]));
                        var model2 = new FibonacciNumbers(range2);
                        var controller2 = new SequenceController(model2, view);
                        controller2.DisplaySequence();
                        break;
                    default:
                        view.DisplayHelp();
                        break;
                }
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
