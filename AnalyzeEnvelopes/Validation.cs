using System;

namespace AnalysisOfEnvelopes
{
    public class Validation
    {
        public static double ValidateToPositive(double value)
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
