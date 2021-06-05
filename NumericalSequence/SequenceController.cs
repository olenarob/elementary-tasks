using System;

namespace NumericalSequences
{
    public class SequenceController
    {
        private NumericalSequence model;
        private SequenceView view;

        public SequenceController(NumericalSequence model, SequenceView view)
        {
            this.Model = model;
            this.view = view;
        }

        public NumericalSequence Model { get => model; set => model = value; }

        public void DisplaySequence()
        {
            foreach (int number in Model.GetSequence())
            {
                view.DisplayNumber(number);
            }
            view.DisplayMessage(Environment.NewLine);
        }
    }
}
