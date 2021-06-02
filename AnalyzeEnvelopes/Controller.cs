using ArgumentsProcessor;
using System;

namespace AnalysisOfEnvelopes
{
    public class Controller
    {
        private EnvelopeManager model;
        private View view;

        public Controller(EnvelopeManager envelopeManager, View view)
        {
            this.model = envelopeManager;
            this.view = view;

            model.NewEnvelope += ViewMsg;
        }

        private void ViewMsg()
        {
            view.DisplayMessage(model.CheckInsertion());
        }
        
        public void Run()
        {
            string userAnswer;
            do
            {
                var envelope1 = GetEnvelopeFromUserInput(1);
                var envelope2 = GetEnvelopeFromUserInput(2);
                model.SetEnvelopes(envelope1, envelope2);
                
                userAnswer = view.GetUserValue("Try again? (y/yes): ");
            }
            while (IfRepeat(userAnswer));
        }

        private static bool IfRepeat(string userAnswer)
        {
            return userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }
        private static Envelope GetEnvelopeFromUserInput(int envelopeIndex)
        {
            double side1 = Argument.GetValueFromUser($" first side of envelope {envelopeIndex}", double.Epsilon, double.MaxValue);
            double side2 = Argument.GetValueFromUser($"second side of envelope {envelopeIndex}", double.Epsilon, double.MaxValue);

            return new Envelope(side1, side2);
        }
    }
}
