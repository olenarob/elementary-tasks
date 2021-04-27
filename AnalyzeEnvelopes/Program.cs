using System;

namespace AnalyzeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool flag = true;
            if (args.Length < 4)
            {
                flag = false;
                args = new string[4];
            }
            double[] parameters = new double[4];
            string desireToContinue;
            do
            {
                               
                for (int i = 0; i < 4; i++)
                {
                    if (flag == false)
                    {
                        Console.Write($"Please input parameter {i}: ");
                        args[i] = Console.ReadLine();
                    }
                    parameters[i] = new DoubleArgument().Parse(args[i]);


                }
                                
                //double[] parameters = new Arguments(4).Parse(args);

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
    /*
    public class Arguments
    {
        private int quantity;

        public Arguments (int quantity)
        {
            this.quantity = quantity;
        }
        
        
        
        
        public double[] Parse (string[] args)
        {
            var result = new double[quantity];
            
            // parsing logic of args
            for (int i = 0; i < quantity; i++)
            {
                try
                {
                    result[i] = double.Parse(args[i]);
                    if (result[i] <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Size of envelope must be greater than zero!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            return result;
        }
        
    }
    */
    public class DoubleArgument
    {
        
        private double _argument;
         
        
        
        public double Parse(string s)
        {
            double result = 0;
            // parsing logic of args
            
                try
                {
                    result = double.Parse(s);
                    if (result <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Side of envelope must be greater than zero!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
            return result;
        }

    }
}
