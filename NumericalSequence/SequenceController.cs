using System;

namespace NumericalSequences
{
    public class SequenceController
    {
        private NumericalSequence model;
        private ISequenceView view;

        public SequenceController(NumericalSequence model, ISequenceView view)
        {
            this.Model = model;
            this.View = view;
        }

        public NumericalSequence Model { get => model; set => model = value; }
        public ISequenceView View { get => view; set => view = value; }

        public void DisplaySequence()
        {
            view.DisplayMessage(Model.GetType().Name);

            foreach (ulong number in Model.GetSequence())
            {
                View.DisplayNumber(number);
            }
            View.DisplayMessage(Environment.NewLine);
        }
    }
}
