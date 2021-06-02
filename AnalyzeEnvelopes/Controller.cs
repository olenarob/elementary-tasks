using System;

namespace AnalysisOfEnvelopes
{
    public class Controller
    {
        private EnvelopeAnalyser model;
        private View view;

        public Controller(EnvelopeAnalyser model, View view)
        {
            this.model = model;
            this.view = view;

            this.model.NewPairOfEnvelopes += ViewMsg;
        }

        private void ViewMsg()
        {
            view.DisplayMessage("");
            view.DisplayMessage(model.CheckInsertion());
        }
        
        public void Run()
        {
            string userAnswer;
            do
            {
                model.SetEnvelopes(GetEnvelope(1), GetEnvelope(2));

                userAnswer = view.GetUserMessage("Try again? (y/yes): ");
            }
            while (userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase));
        }

        private Envelope GetEnvelope(int envelopeIndex)
        {
            double side1 = GetSideOfEnvelope(envelopeIndex, 1);
            double side2 = GetSideOfEnvelope(envelopeIndex, 2);

            return new Envelope(side1, side2);
        }

        private double GetSideOfEnvelope(int envelopeIndex, int sideIndex)
        {
            double side = 0;
            do
            {
                try
                {
                    side = Envelope.ValidateSide(double.Parse(view.GetUserMessage
                        ($"Please enter {sideIndex} side of envelope {envelopeIndex}: ")));
                }
                catch (Exception ex)
                {
                    view.DisplayMessage(ex.Message);
                }
            } while (side == 0);
            
            return side;
        }
    }
}
