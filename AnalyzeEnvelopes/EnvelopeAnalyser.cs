using System;

namespace AnalysisOfEnvelopes
{
    public class EnvelopeAnalyser
    {
        private Envelope envelope1;
        private Envelope envelope2;

        public Envelope Envelope1 { get => envelope1; set => envelope1 = value; }
        public Envelope Envelope2 { get => envelope2; set => envelope2 = value; }

        public event Action NewPairOfEnvelopes;
        
        public void SetEnvelopes(double[] sides)
        {
            this.Envelope1 = new Envelope(sides[0], sides[1]);
            this.Envelope2 = new Envelope(sides[2], sides[3]);

            OnNewEnvelope();
        }

        public int CheckInsertion()
        {
            int result = 0;

            if (IsInsertedInto(Envelope1, Envelope2))
            {
                result = -1;
            }
            else if (IsInsertedInto(Envelope2, Envelope1))
            {
                result = 1;
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
            return (envelope1.ShortSide < envelope2.ShortSide) && (envelope1.LongSide < envelope2.LongSide); ;
        }
    }
}
