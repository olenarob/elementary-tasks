using System;

namespace AnalyzeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] parameters = new double[4];
            int i = 0;

            foreach (string s in args)
            {
                parameters[i] = double.Parse(s);
                i++;
            }

            if (i == 0)
            {
                string s;
                for (i = 0; i < 4; i++)
                {
                    Console.Write($"Parameter{i}: ");
                    parameters[i] = double.Parse(Console.ReadLine());
                }
            }
           
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

            Console.WriteLine($"Envelope {smallEnvelope} can be inserted into envelope {bigEnvelope}");
            
            
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
