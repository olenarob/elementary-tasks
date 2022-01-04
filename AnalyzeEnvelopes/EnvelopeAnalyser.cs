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

            OnNewPairOfEnvelopes();
        }

        public int CheckInsertion()
        {
            int result = 0;

            if (Envelope1.IsInsertedInto(Envelope2))
            {
                result = -1;
            }
            else if (Envelope2.IsInsertedInto(Envelope1))
            {
                result = 1;
            }

            return result;
        }

        protected void OnNewPairOfEnvelopes()
        {
            NewPairOfEnvelopes?.Invoke();
        }
    }
}
