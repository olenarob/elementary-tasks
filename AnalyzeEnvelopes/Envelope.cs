namespace AnalyzeEnvelopes
{
    public class Envelope
    {
        private double _shortSide;
        private double _longSide;

        public Envelope(double a, double b)
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

        public bool CanBeInsertedInto(Envelope that)
        {
            if ((this._shortSide < that._shortSide) && (this._longSide < that._longSide))
            {
                return true;
            }
            return false;
        }
    }
}
