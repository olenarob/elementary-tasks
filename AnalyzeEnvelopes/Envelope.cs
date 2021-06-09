using System;

namespace AnalysisOfEnvelopes
{
    public class Envelope
    {
        private double shortSide;
        private double longSide;
        
        public Envelope(double side1, double side2)
        {
            ShortSide = Math.Min(side1, side2);
            LongSide  = Math.Max(side1, side2);
        }

        public double ShortSide
        {
            get => shortSide;
            set
            {
                Validation.ValidateToPositive(value);
                shortSide = value;
            }
        }
        public double LongSide
        {
            get => longSide;
            set
            {
                Validation.ValidateToPositive(value);
                longSide = value;
            }
        }
    }
}
