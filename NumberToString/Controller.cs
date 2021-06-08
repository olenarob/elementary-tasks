using System;
using System.Numerics;

namespace NumberToString
{
    public class Controller
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
              //  model.Number = number;
                
                view.DisplayBigNumber(number);
                view.DisplayMessage(model.ToString());
            }
            catch (IndexOutOfRangeException)
            {
                view.DisplayHelp();
            }
            catch (FormatException)
            {
                view.DisplayMessage("The input string is not a sequence of digits!");
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
            }
        }
    }
}
