using System;

namespace AnalizeEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            Envelope envelope1 = new Envelope(3.64592, 4.1588902627878);
            Envelope envelope2 = new Envelope(4.15889026278, 3.64592);

            Console.WriteLine(envelope1.CanBeInsertedIn(envelope2));
            Console.WriteLine(envelope2.CanBeInsertedIn(envelope1));
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

        public bool CanBeInsertedIn (Envelope that)
        {
            if ((this._shortSide < that._shortSide) && (this._longSide < that._longSide))
            {
                return true;
            }
            return false;
        }
    }
}
