using ArgumentsProcessor;
using System;

namespace AnalyzeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            double c;
            double d;

            string userAnswer;

            do
            {
                a = Argument.GetValueFromUser<double>("first side of envelope 1", Double.Epsilon, Double.MaxValue);
                b = Argument.GetValueFromUser<double>("second side of envelope 1", Double.Epsilon, Double.MaxValue);
                var envelope1 = new Envelope(a, b);

                c = Argument.GetValueFromUser<double>("first side of envelope 2", Double.Epsilon, Double.MaxValue);
                d = Argument.GetValueFromUser<double>("second side of envelope 2", Double.Epsilon, Double.MaxValue);
                var envelope2 = new Envelope(c, d);
                
                Console.WriteLine(envelope1.CheckInsertion(envelope2));
                                
                Console.Write("Go again? Y/N: ");
                userAnswer = Console.ReadLine();
            }
            while (userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                   || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase));
        }
        
    }
}
