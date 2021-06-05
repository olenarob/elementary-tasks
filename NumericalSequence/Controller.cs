namespace NumericalSequences
{
    class Controller
    {
        private NumericalSequence model;
        private View view;

        public Controller(NumericalSequence model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void DisplaySequence()
        {
            foreach (int number in model.GetSequence())
            {
                view.DisplayMessage($"{number} ");
            }
            view.DisplayMessage($"\n");
        }
    }
}
