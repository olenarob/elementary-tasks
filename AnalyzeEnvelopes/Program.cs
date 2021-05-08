using System;

namespace AnalyzeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengthOfSide = new double[4];

            bool repeat = true;

            while (repeat)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("Enter a side of envelope: ");

                    string input = Console.ReadLine();

                    // ToInt32 can throw FormatException or OverflowException.
                    try
                    {
                        lengthOfSide[i] = Convert.ToDouble(input);
                        if (lengthOfSide[i] <= 0)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Input string is not a sequence of digits.");
                        i--;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("The number cannot be less or equal to zero.");
                        i--;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The number cannot fit in an Double.");
                        i--;
                    }
                }

                var envelope1 = new Envelope(lengthOfSide[0], lengthOfSide[1]);
                var envelope2 = new Envelope(lengthOfSide[2], lengthOfSide[3]);

                int smallEnvelope;
                int bigEnvelope;

                if (envelope1.CanBeInsertedInto(envelope2, out smallEnvelope, out bigEnvelope) ||
                    (envelope2.CanBeInsertedInto(envelope1, out bigEnvelope, out smallEnvelope)))
                {
                    Console.WriteLine($"Envelope {smallEnvelope} can be inserted into envelope {bigEnvelope}.");
                }
                else
                {
                    Console.WriteLine("None of the envelopes cannot be inserted into the other.");
                }
                
                Console.Write("Go again? Y/N: ");
                string go = Console.ReadLine();
                if ((go.ToLower() != "y") && (go.ToLower() != "yes"))
                {
                    repeat = false;
                }
            }
        }
        
    }
}
