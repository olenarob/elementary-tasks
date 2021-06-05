using System;

namespace NumericalSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();

            try
            {
                switch (args[0])
                {
                    case "1":
                        view.DisplayTask7();
                        uint m = uint.Parse(args[2]);
                        uint minSqrt = (uint)Math.Ceiling(Math.Sqrt(m));
                        var sequence = new SequenceWithLength(uint.Parse(args[1]), minSqrt);
                        var model1 = new NaturalNumbers(sequence);
                        var controller1 = new Controller(model1, view);
                        controller1.DisplaySequence();
                        break;
                    case "2":
                        view.DisplayTask8();
                        ISequenceRange sequence2;
                        if (args.Length == 3)
                        {
                            sequence2 = new SequenceInRange(uint.Parse(args[1]), uint.Parse(args[2]));
                        }
                        else
                        {
                            sequence2 = new SequenceWithNumberOfDigits(uint.Parse(args[1]));
                        }
                        NumericalSequence model2 = new Fibonacci(sequence2);
                        var controller2 = new Controller(model2, view);
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
                view.DisplayMessage($"\n");
                view.DisplayHelp();
            }
        }
    }
}
