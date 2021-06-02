using System;

namespace AnalysisOfEnvelopes
{
    public struct Envelope
    {
        private double shortSide;
        private double longSide;
        
        public double ShortSide
        {
            get { return shortSide; }
        }

        public double LongSide
        {
            get { return longSide; }
        }
        
        public Envelope(double side1, double side2)
        {
            ValidateSide(side1);
            ValidateSide(side2);
            
            shortSide = Math.Min(side1, side2);
            longSide  = Math.Max(side1, side2);
        }
        
        public static double ValidateSide(double value)
        {
            if ((value <= 0) || (value > double.MaxValue))
            {
                throw new OverflowException
                    ($"The side of envelope can not be less than zero or more than {double.MaxValue}!");
            }
            return value;
        }
    }
}
