using ArgumentsProcessor;
using System;

namespace AnalysisOfEnvelopes
{
    public class Controller
    {
        private PairOfEnvelopes model;
        private View view;

        public Controller(PairOfEnvelopes model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void Run()
        {
            string userAnswer;
            do
            {
                model.Envelope1 = GetEnvelopeFromUserInput(1);
                model.Envelope2 = GetEnvelopeFromUserInput(2);
                view.DisplayMessage(model.CheckInsertion());

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
