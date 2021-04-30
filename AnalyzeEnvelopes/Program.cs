using ArgumentsProcessor;
using System;

namespace AnalyzeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[4];
            var parameters = new double[4];

            string desireToContinue;
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Please input parameter {i}: ");
                    args[i] = Console.ReadLine();
                    
                    parameters[i] = Argument.Parse(args[i]);
                }

                var envelope1 = new Envelope(parameters[0], parameters[1]);
                var envelope2 = new Envelope(parameters[2], parameters[3]);

                int smallEnvelope = 0;
                int bigEnvelope = 0;

                if (envelope1.CanBeInsertedInto(envelope2))
                {
                    smallEnvelope = 1;
                    bigEnvelope = 2;
                }
                else if (envelope2.CanBeInsertedInto(envelope1))
                {
                    smallEnvelope = 2;
                    bigEnvelope = 1;
                }

                if (smallEnvelope == 0)
                {
                    Console.WriteLine("None of the envelopes cannot be inserted into the other!");
                }
                else
                {
                    Console.WriteLine($"Envelope {smallEnvelope} can be inserted into envelope {bigEnvelope}");
                }

                Console.Write("Do you want to continue? ");
                desireToContinue = Console.ReadLine();
            }
            while (desireToContinue == "y");
        }
    }
}
