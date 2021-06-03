using System;
using System.Numerics;

namespace NumberToString
{
    class Controller
    {
        private NumberToString model;
        private View view;

        public Controller(NumberToString model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void Run(string[] args)
        {
            try
            {
                var number = BigInteger.Parse(args[0]);
                view.DisplayMessage($" {number:N0}");
                
                model.Number = number;
                view.DisplayMessage(model.ToString());
            }
            catch (IndexOutOfRangeException)
            {
                view.DisplayHelp();
            }
            catch (FormatException)
            {
                view.DisplayMessage("The input string is not a sequence of digit!");
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
            }
        }
    }
}
