using System;

namespace AnalyzeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] parameters = new double[4];
            int i = 0;

            string desireToContinue;
            do
            {
                for (i = 0; i < 4; i++)
                {
                    try
                    {
                        if (args.Length >= 4)
                        {
                            parameters[i] = double.Parse(args[i]);
                            Console.WriteLine($"Parameter{i}: {parameters[i]}");
                        }
                        else
                        {
                            Console.Write($"Please input parameter{i}: ");
                            parameters[i] = double.Parse(Console.ReadLine());
                        }
                        if (parameters[i] <= 0)
                        {
                            throw new ArgumentOutOfRangeException("Size of envelope must be greater than zero!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        if (args.Length < 4)
                        {
                            i--;
                        }
                        else break;
                    }
                }

                args = new string[1];

                Envelope envelope1 = new Envelope(parameters[0], parameters[1]);
                Envelope envelope2 = new Envelope(parameters[2], parameters[3]);

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

    
    
    public class Envelope
    {
        private double _shortSide;
        private double _longSide;

        public Envelope (double a, double b)
        {
            if (a < b)
            {
                _shortSide = a;
                _longSide = b;
            }
            else
            {
                _longSide = a;
                _shortSide = b;
            }
        }

        public bool CanBeInsertedInto (Envelope that)
        {
            if ((this._shortSide < that._shortSide) && (this._longSide < that._longSide))
            {
                return true;
            }
            return false;
        }
    }
}
