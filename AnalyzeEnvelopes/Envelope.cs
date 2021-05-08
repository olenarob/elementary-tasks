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

        public bool CanBeInsertedInto(Envelope that, out int n1, out int n2)
        {
            if ((this._shortSide < that._shortSide) && (this._longSide < that._longSide))
            {
                n1 = 1;
                n2 = 2;
                return true;
            }
            else
            n1 = 0;
            n2 = 0;
            return false;
        }
    }
}
