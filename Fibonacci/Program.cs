using NumericalSequences;
using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new FibonacciView();
            ISequenceRange range = default;
            
            try
            {
                switch (args.Length)
                {
                    case 1:
                        range = new SequenceWithNumberOfDigits(byte.Parse(args[0]));
                        break;
                    case 2:
                        range = new SequenceInRange(ulong.Parse(args[0]), ulong.Parse(args[1]));
                        break;
                }
                
                var model = new FibonacciNumbers(range);
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
