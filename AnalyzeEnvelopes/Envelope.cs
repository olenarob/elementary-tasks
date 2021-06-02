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
            set { shortSide = Validate(value); }
        }

        public double LongSide
        {
            get { return longSide; }
            set { longSide = Validate(value); }
        }
        
        public Envelope(double side1, double side2)
        {
            Validate(side1);
            Validate(side2);
            
            shortSide = Math.Min(side1, side2);
            longSide  = Math.Max(side1, side2);
        }
        
        private static double Validate(double value)
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
