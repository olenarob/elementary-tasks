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
            view.DisplayMessage(Environment.NewLine);
            view.DisplayMessage(DisplayResult());
        }
        
        public void Run()
        {
            string userAnswer;
            do
            {
                model.SetEnvelopes(GetSidesOfEnvelopes());

                userAnswer = view.GetUserInput("Try again? (yes/no): ");
            }
            while (userAnswer.Equals("y", StringComparison.CurrentCultureIgnoreCase)
                || userAnswer.Equals("yes", StringComparison.CurrentCultureIgnoreCase));
        }

        private double[] GetSidesOfEnvelopes()
        {
            double[] sides = new double[4];
            
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    try
                    {
                        int sideIndex = i % 2 + 1;
                        int envelopeIndex = i / 2 + 1;
                        
                        double tmp = double.Parse(view.GetUserInput(
                            $"Please enter {sideIndex} side of envelope {envelopeIndex}: "));
                        
                        sides[i] = Validation.ValidateToPositive(tmp);
                    }
                    catch (Exception ex)
                    {
                        view.DisplayMessage(ex.Message);
                    }
                }
                while (sides[i] == 0);
            }
            
            return sides;
        }

        public string DisplayResult()
        {
            string result = "None of the envelopes cannot be inserted into the other.";
            
            switch (model.CheckInsertion())
            {
                case -1:
                    result = $"Envelope with sides ({model.Envelope1.ShortSide}, {model.Envelope1.LongSide}) can be inserted into envelope with sides ({model.Envelope2.ShortSide}, {model.Envelope2.LongSide}).";
                    break;
                case 1:
                    result = $"Envelope with sides ({model.Envelope2.ShortSide}, {model.Envelope2.LongSide}) can be inserted into envelope with sides ({model.Envelope1.ShortSide}, {model.Envelope1.LongSide}).";
                    break;
            }

            return result;
        }
    }
}
