namespace AnalysisOfEnvelopes
{
    public class PairOfEnvelopes
    {
        public Envelope Envelope1 { get; set; }
        public Envelope Envelope2 { get; set; }

        public string CheckInsertion()
        {
            string result = "None of the envelopes cannot be inserted into the other.";

            if (IsInsertedInto(Envelope1, Envelope2))
            {
                result = $"Envelope with sides ({Envelope1.ShortSide}, {Envelope1.LongSide}) can be inserted into envelope with sides ({Envelope2.ShortSide}, {Envelope2.LongSide}).";
            }
            else if (IsInsertedInto(Envelope2, Envelope1))
            {
                result = $"Envelope with sides ({Envelope2.ShortSide}, {Envelope2.LongSide}) can be inserted into envelope with sides ({Envelope1.ShortSide}, {Envelope1.LongSide}).";
            }

            return result;
        }

        private static bool IsInsertedInto(Envelope envelope1, Envelope envelope2)
        {
            return (envelope1.ShortSide < envelope2.ShortSide) && (envelope1.LongSide < envelope2.LongSide);
        }
    }
}
