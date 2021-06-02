using System;

namespace AnalysisOfEnvelopes
{
    public class EnvelopeAnalyser
    {
        private Envelope envelope1;
        private Envelope envelope2;

        public event Action NewPairOfEnvelopes;
        
        public void SetEnvelopes(Envelope envelope1, Envelope envelope2)
        {
            this.envelope1 = envelope1;
            this.envelope2 = envelope2;
            
            OnNewEnvelope();
        }

        public string CheckInsertion()
        {
            string result = "None of the envelopes cannot be inserted into the other.";

            if (IsInsertedInto(envelope1, envelope2))
            {
                result = $"Envelope with sides ({envelope1.ShortSide}, {envelope1.LongSide}) can be inserted into envelope with sides ({envelope2.ShortSide}, {envelope2.LongSide}).";
            }
            else if (IsInsertedInto(envelope2, envelope1))
            {
                result = $"Envelope with sides ({envelope2.ShortSide}, {envelope2.LongSide}) can be inserted into envelope with sides ({envelope1.ShortSide}, {envelope1.LongSide}).";
            }

            return result;
        }

        protected void OnNewEnvelope()
        {
            Action temp = NewPairOfEnvelopes;
            if (temp != null)
            {
                temp();
            }
        }

        private static bool IsInsertedInto(Envelope envelope1, Envelope envelope2)
        {
            return (envelope1.ShortSide < envelope2.ShortSide) && (envelope1.LongSide < envelope2.LongSide);
        }
    }
}
