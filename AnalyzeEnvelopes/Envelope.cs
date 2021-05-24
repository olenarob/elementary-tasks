namespace AnalyzeEnvelopes
{
    public class Envelope
    {
        private readonly double shortSide;
        private readonly double longSide;

        public Envelope(double side1, double side2)
        {
            if (side1 < side2)
            {
                shortSide = side1;
                longSide = side2;
            }
            else
            {
                shortSide = side2;
                longSide = side1;
            }
        }

        bool IsInsertedInto(Envelope that)
        {
            return (this.shortSide < that.shortSide) && (this.longSide < that.longSide);
        }

        public string CheckInsertion(Envelope that)
        {
            string result = "None of the envelopes cannot be inserted into the other.";
            
            if (this.IsInsertedInto(that))
            {
                result = $"Envelope with sides ({this.shortSide}, {this.longSide}) can be inserted into envelope with sides ({that.shortSide}, {that.longSide}).";
            }
            else if (that.IsInsertedInto(this))
            {
                result = $"Envelope with sides ({this.shortSide}, {this.longSide}) can be inserted into envelope with sides ({this.shortSide}, {this.longSide})."; 
            }
            
            return result;
        }
    }
}
