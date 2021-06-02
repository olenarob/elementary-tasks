using System;

namespace AnalysisOfEnvelopes
{
    public class EnvelopeManager
    {
        private Envelope[] envelopes;
        
        public event Action NewEnvelope;

        public void SetEnvelopes(params Envelope[] envelopes)
        {
            this.envelopes = envelopes;
            OnNewEnvelope();
        }

        public string CheckInsertion()
        {
            return CheckPairInsertion(0, 1);
        }

        private string CheckPairInsertion(int index1, int index2)
        {
            string result = "None of the envelopes cannot be inserted into the other.";

            if (IsInsertedInto(envelopes[index1], envelopes[index2]))
            {
                result = $"Envelope with sides ({envelopes[index1].ShortSide}, {envelopes[index1].LongSide}) can be inserted into envelope with sides ({envelopes[index2].ShortSide}, {envelopes[index2].LongSide}).";
            }
            else if (IsInsertedInto(envelopes[index2], envelopes[index1]))
            {
                result = $"Envelope with sides ({envelopes[index2].ShortSide}, {envelopes[index2].LongSide}) can be inserted into envelope with sides ({envelopes[index1].ShortSide}, {envelopes[index1].LongSide}).";
            }

            return result;
        }

        protected void OnNewEnvelope()
        {
            Action temp = NewEnvelope;
            if (temp != null) temp();
        }

        private static bool IsInsertedInto(Envelope envelope1, Envelope envelope2)
        {
            return (envelope1.ShortSide < envelope2.ShortSide) && (envelope1.LongSide < envelope2.LongSide);
        }
    }
}
